using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using App.cms.Controllers.Attributes;
using App.cms.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using ImageModel = App.Models.ImageModel;

namespace App.cms.StaticHelpers
{
    public static class ReflectionHelper
    {
        public static string GetNameProperty(PropertyInfo info)
        {
            var attr = info.GetCustomAttribute<DisplayNameAttribute>();
            return attr == null ? info.Name : attr.DisplayName;
        }

        public static string GetValuePropertyAsString(PropertyInfo info, dynamic dynamicObject)
        {
            if (dynamicObject is IEntity entity)
            {
                var valueFromObject = entity.GetValueFromNameProperty(info.Name);

                if (valueFromObject != null)
                {
                    return valueFromObject;
                }
            }

            try
            {
                var value = info.GetValue(dynamicObject, null);
                return value?.ToString();
            }
            catch
            {
                return "";
            }
        }

        public static string GetValuePropertyAsTitle(PropertyInfo info, dynamic dynamicObject)
        {
            if (dynamicObject is IEntity entity)
            {
                var valueFromObject = entity.GetTitleFromNameProperty(info.Name);

                if (valueFromObject != null)
                {
                    return valueFromObject;
                }
            }

            try
            {
                var value = info.GetValue(dynamicObject, null);

                return (value as IEntity)?.Title;
            }
            catch
            {
                return "Объект";
            }
        }

        public static string GetValuePropertyAsLink(PropertyInfo info, dynamic dynamicObject)
        {
            if (dynamicObject is IEntity entity)
            {
                var valueFromObject = entity.GetLinkFromNameProperty(info.Name);

                if (valueFromObject != null)
                {
                    return valueFromObject;
                }
            }

            try
            {
                var value = info.GetValue(dynamicObject, null);
                return $"/HomeCms/Details?type={info.Name}&id={(value as IEntity)?.Id}";
            }
            catch
            {
                return "HomeCms/GetList?type=PreOrder";
            }
        }

        public static IEnumerable<PropertyInfo> GetPropertiesInList(Type type)
        {
            return type.GetProperties().Where(w =>
                w.GetCustomAttribute<ShowAttribute>() == null || w.GetCustomAttribute<ShowAttribute>().ShowInList);
        }

        public static IEnumerable<PropertyInfo> GetPropertiesInDetails(Type type)
        {
            return type.GetProperties().Where(w =>
                w.GetCustomAttribute<ShowAttribute>() == null || w.GetCustomAttribute<ShowAttribute>().ShowInDetails);
        }

        public static IEnumerable<PropertyInfo> GetPropertiesInEdit(Type type)
        {
            return type.GetProperties().Where(w =>
                w.GetCustomAttribute<ShowAttribute>() == null || w.GetCustomAttribute<ShowAttribute>().ShowInEdit);
        }

        public static IEnumerable<PropertyInfo> GetPropertiesInCreate(Type type)
        {
            return type.GetProperties().Where(w =>
                w.GetCustomAttribute<ShowAttribute>() == null || w.GetCustomAttribute<ShowAttribute>().ShowInCreate);
        }

        public static IEnumerable<PropertyInfo> GetPropertiesInView(Type type, ViewDataDictionary viewDataDictionary)
        {
            if (viewDataDictionary.TryGetValue("isEditing", out var value) && (bool)value)
            {
                return GetPropertiesInEdit(type);
            }

            if (viewDataDictionary.TryGetValue("isCreating", out value) && (bool)value)
            {
                return GetPropertiesInCreate(type);
            }

            if (viewDataDictionary.TryGetValue("isListing", out value) && (bool)value)
            {
                return GetPropertiesInList(type);
            }

            if (viewDataDictionary.TryGetValue("isDetailing", out value) && (bool)value)
            {
                return GetPropertiesInDetails(type);
            }

            return type.GetProperties();
        }

        public static IQueryable<IEntity> InsertInclude<T>(IQueryable<IEntity> query, Type type)
            where T : Attribute
        {
            var showTitles = type.GetProperties().Where(w => w.GetCustomAttribute<T>() != null);

            return showTitles.Aggregate(query, (current, property) => current.Include(property.Name));
        }

        public static bool IsHtml(PropertyInfo info)
        {
            var type = info.GetCustomAttribute<DataTypeAttribute>();
            return type?.DataType == DataType.Html;
        }

        public static bool IsImageUrl(PropertyInfo info)
        {
            var type = info.GetCustomAttribute<DataTypeAttribute>();
            return type?.DataType == DataType.ImageUrl;
        }

        public static bool IsImage(Type info)
        {
            return info == typeof(ImageModel);
        }

        public static bool IsArray(PropertyInfo info)
        {
            var interfaces = info.PropertyType.GetInterfaces().ToList();
            return interfaces.Contains(typeof(IQueryable<>)) || interfaces.Contains(typeof(IEnumerable<>)) ||
                   interfaces.Contains(typeof(IList<>))
                   || interfaces.Contains(typeof(IList));
        }
    }
}