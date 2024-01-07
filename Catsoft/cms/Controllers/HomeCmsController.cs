using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using App.cms.Controllers.Attributes;
using App.cms.EntityFrameworkPaginateCore;
using App.cms.FilesHandlers;
using App.cms.Models;
using App.cms.Repositories.CmsModels;
using App.cms.Repositories.File;
using App.cms.Repositories.Image;
using App.cms.Repositories.TextResource;
using App.cms.StaticHelpers;
using App.cms.ViewModels;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ImageModel = App.cms.Models.ImageModel;

namespace App.cms.Controllers
{
    public abstract class HomeCmsController<TContext> : CommonCmsController<TContext>
        where TContext : CatsoftContext
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ICmsCmsModelRepository _cmsCmsModelRepository;
        private readonly CmsOptions _cmsOptions;
        private readonly IFileHandler _fileHandler;
        private readonly ICmsFilesRepository _filesRepository;
        private readonly ICmsImageModelRepository _imageRepository;
        private readonly TextResourceRepository _textResourceRepository;
        private readonly TypesOptions _typesOptions;

        public HomeCmsController(TContext catsoftContext,
            IWebHostEnvironment appEnvironment,
            CmsOptions cmsOptions,
            TypesOptions typesOptions,
            ICmsImageModelRepository imageRepository,
            ICmsFilesRepository filesRepository,
            ICmsCmsModelRepository cmsCmsModelRepository,
            TextResourceRepository textResourceRepository,
            IFileHandler fileHandler) : base(catsoftContext)
        {
            _appEnvironment = appEnvironment;
            _cmsOptions = cmsOptions;
            _typesOptions = typesOptions;
            _imageRepository = imageRepository;
            _filesRepository = filesRepository;
            _cmsCmsModelRepository = cmsCmsModelRepository;
            _fileHandler = fileHandler;
            _textResourceRepository = textResourceRepository;

            ContextShared.SharedContext = catsoftContext;
        }

        [Authorize]
        public async Task<IActionResult> GetList(string type, int page = 0, string sorted = null, string filter = null)
        {
            var t = GetTypeByName(type);

            CheckRole(t);

            if (CheckIsSingle(t))
            {
                return RedirectToAction("EditFirst", new { type });
            }

            ViewBag.Type = t;
            ViewBag.NameType = type;
            ViewBag.Page = page;
            dynamic dynamicObject = Activator.CreateInstance(t);
            var set = GetDbSet(CatsoftContext, dynamicObject);

            var includeSets = Provider(ReflectionHelper.InsertInclude<ShowTitleAttribute>(set, t), dynamicObject);

            var localFilter = filter;
            if (string.IsNullOrEmpty(localFilter))
            {
                localFilter = CookieHelper.GetFilter(HttpContext);
            }
            else
            {
                CookieHelper.SetFilter(localFilter, HttpContext);
            }

            var pageResult = await Paginate(dynamicObject, includeSets, t, page + 1, 20, null, localFilter);
            var result = ProviderPage(dynamicObject, pageResult);
            var sortedSet = result.Results;
            ViewBag.PageCount = result.PageCount;

            _cmsCmsModelRepository.ResetCountByType(type);

            return View(sortedSet);
        }

        private bool CheckIsSingle(Type type)
        {
            return type.GetCustomAttribute<SingleObjectAttribute>() != null;
        }

        // ReSharper disable once UnusedParameter.Local
        private IQueryable<T> Provider<T>(IQueryable<IEntity> list, T dynamicObject) where T : ISortFilterEntity<T>
        {
            return list.Cast<T>();
        }

        // ReSharper disable once UnusedParameter.Local
        private Page<T> ProviderPage<T>(T objectType, Page<T> page) where T : ISortFilterEntity<T>
        {
            return page;
        }

        public Task<Page<T>> Paginate<T>(T objectType, IQueryable<T> list, Type type, int pageNumber, int pageSize,
            string sorteds = null, string filter = null)
            where T : ISortFilterEntity<T>
        {
            var filters = objectType.GetDefaultFilters(filter) ?? new Filters<T>();

            var sorted = objectType.GetDefaultSorted() ?? new Sorts<T>();
            //TODO Сортировка отвалилась чего-то
            //sorted.Add(true, arg => (arg as IEntity).DateCreated, true);

            return list.PaginateAsync(pageNumber, pageSize, sorted, filters);
        }

        [Authorize]
        public IActionResult Delete(string type, Guid id)
        {
            var t = GetTypeByName(type);

            CheckRole(t);

            if (CheckIsSingle(t))
            {
                return RedirectToAction("EditFirst", new { type });
            }

            dynamic dynamicObject = Activator.CreateInstance(t);
            Delete(dynamicObject, id);

            return RedirectToAction("GetList", new { type });
        }

        // ReSharper disable once UnusedParameter.Local
        private void Delete<T>(T dynamicObject, Guid id) where T : Entity<T>
        {
            var set = CatsoftContext.Set<T>().AsQueryable();

            var first = set.FirstOrDefault(w => w.Id == id);

            if (first == null)
            {
                return;
            }

            CatsoftContext.Remove(first);
            CatsoftContext.SaveChanges();
        }

        [Authorize]
        public IActionResult Details(string type, Guid id)
        {
            var t = GetTypeByName(type);
            CheckRole(t);

            dynamic dynamicObject = Activator.CreateInstance(t);

            ViewBag.Type = t;
            ViewBag.NameType = type;

            return View(GetObject(dynamicObject, id));
        }

        private T GetObject<T>(T type, Guid id) where T : Entity<T>
        {
            var set = CatsoftContext.Set<T>().AsQueryable();
            // при переходе с 3 на 8 сказали что это не нужно, что они автоматически включают этот объект
            // но оно все равно не подгружает даже 1 связанный объект

            var classes = type.GetType().GetProperties().Where(w =>
                (w.PropertyType.IsClass || w.PropertyType.IsArray) &&
                w.PropertyType != _typesOptions.String &&
                w.GetCustomAttribute<NotMappedAttribute>() == null);

            var classesSet = classes.Aggregate(set, (current, property) =>
            {
                var ccc = current.Include(property.Name);

                // if (property.PropertyType.IsArray ||
                //     property.PropertyType.GetInterfaces().Any(w => w == _typesOptions.Enumerable))
                // {
                //     var types = property.PropertyType.GenericTypeArguments;
                //
                //     foreach (var type2 in types)
                //     {
                //         ccc = type2.GetProperties()
                //             .Where(w => (w.PropertyType.IsClass || w.PropertyType.IsArray) && w.PropertyType != _typesOptions.String)
                //             .Aggregate(ccc, (cc, pro) =>
                //             {
                //                 var a = cc.Include($"{property.Name}.{pro.Name}");
                //                 return a;
                //             });
                //     }
                // }

                return ccc;
            });

            return classesSet.FirstOrDefault(w => w.Id == id);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(string type)
        {
            var t = GetTypeByName(type);
            CheckRole(t);

            if (CheckIsSingle(t))
            {
                return RedirectToAction("EditFirst", new { type });
            }

            dynamic dynamicObject = Activator.CreateInstance(t);
            ViewBag.NameType = type;

            return View(dynamicObject);
        }

        [HttpGet]
        [Authorize]
        public IActionResult EditFirst(string type)
        {
            var t = GetTypeByName(type);
            CheckRole(t);
            dynamic dynamicObject = Activator.CreateInstance(t);
            var first = GetObjectToFirstEdit(dynamicObject);

            if (first == null)
            {
                return NotFound();
            }

            return RedirectToAction("Edit", new { type, id = first.Id });
        }

        // ReSharper disable once UnusedParameter.Local
        private T GetObjectToFirstEdit<T>(T type) where T : Entity<T>
        {
            var first = CatsoftContext.Set<T>().FirstOrDefault();
            return first;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(string type, Guid id)
        {
            var t = GetTypeByName(type);
            CheckRole(t);
            dynamic dynamicObject = Activator.CreateInstance(t);
            ViewBag.NameType = type;
            ViewBag.Type = t;

            return View(GetObject(dynamicObject, id));
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit()
        {
            var keys = Request.Form.Keys?.Select(w => w.ToLower()).Select(w =>
            {
                if (w.StartsWith("model."))
                {
                    return w.Substring(6);
                }

                return w;
            }).ToList() ?? new List<string>();

            if (!keys.Contains("type") || !keys.Contains("id"))
            {
                RedirectToAction("GetList", new { type = "PreOrder" });
            }

            var typeName = Request.Form["type"];
            var id = Request.Form["id"];
            var type = GetTypeByName(typeName);
            CheckRole(type);
            var properties = type.GetProperties();
            dynamic newObject = Activator.CreateInstance(type);
            var editObject = GetObject(newObject, Guid.Parse(id));

            var existsProperties = properties.Where(w =>
            {
                var propertyName = w.Name.ToLower();
                return propertyName != "id" && keys.Contains(propertyName);
            });

            foreach (var key in existsProperties)
            {
                var value = Request.Form.ContainsKey(key.Name) ? Request.Form[key.Name] : Request.Form["model." + key.Name];
                var strValue = value.ToString();

                //TODO Костыль ебаный
                if (key.PropertyType == _typesOptions.Bool && strValue == "true,false")
                {
                    strValue = "true";
                }

                var typeConvert = key.PropertyType;
                if (typeConvert.IsGenericType && typeConvert.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (!string.IsNullOrEmpty(value.FirstOrDefault()))
                    {
                        typeConvert = Nullable.GetUnderlyingType(typeConvert);

                        object changedType;

                        if (typeConvert == typeof(Guid))
                        {
                            changedType = Guid.Parse(strValue);
                        }
                        else
                        {
                            changedType = Convert.ChangeType(strValue, typeConvert);
                        }

                        key.SetValue(editObject, changedType);
                    }
                    else
                    {
                        key.SetValue(editObject, null);
                    }
                }
                else
                {
                    if (key.PropertyType.IsEnum)
                    {
                        key.SetValue(editObject, Enum.Parse(key.PropertyType, strValue));
                    }
                    else
                    {
                        var changedType = Convert.ChangeType(strValue, key.PropertyType);

                        key.SetValue(editObject, changedType);
                    }
                }
            }

            CatsoftContext.Update(editObject);
            CatsoftContext.SaveChanges();

            return CheckIsSingle(type)
                ? RedirectToAction("EditFirst", new { type = typeName })
                : RedirectToAction("GetList", new { type = typeName });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create()
        {
            var keys = Request.Form.Keys?.Select(w => w.ToLower()).Select(w =>
            {
                if (w.StartsWith("model."))
                {
                    return w.Substring(6);
                }

                return w;
            }).ToList() ?? new List<string>();

            if (!keys.Contains("type"))
            {
                RedirectToAction("GetList", new { type = "PreOrder" });
            }

            var typeName = Request.Form["type"];
            var type = GetTypeByName(typeName);
            CheckRole(type);

            if (CheckIsSingle(type))
            {
                return RedirectToAction("EditFirst", new { type });
            }

            var properties = type.GetProperties();
            var newObject = Activator.CreateInstance(type);

            var existsProperties = properties.Where(w =>
            {
                var propertyName = w.Name.ToLower();
                return keys.Contains(propertyName);
            });

            foreach (var key in existsProperties)
            {
                var value = Request.Form.ContainsKey(key.Name) ? Request.Form[key.Name] : Request.Form["model." + key.Name];

                var strValue = value.ToString();

                //TODO Костыль ебаный
                if (key.PropertyType == _typesOptions.Bool && strValue == "true,false")
                {
                    strValue = "true";
                }

                var typeConvert = key.PropertyType;
                if (typeConvert.IsGenericType && typeConvert.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (!string.IsNullOrEmpty(value.FirstOrDefault()))
                    {
                        typeConvert = Nullable.GetUnderlyingType(typeConvert);

                        object changedType = null;

                        if (typeConvert == typeof(Guid))
                        {
                            changedType = Guid.Parse(strValue);
                        }
                        else
                        {
                            changedType = Convert.ChangeType(strValue, typeConvert);
                        }

                        key.SetValue(newObject, changedType);
                    }
                }
                else if (typeConvert.IsEnum)
                {
                    key.SetValue(newObject, Enum.Parse(typeConvert, strValue));
                }
                else
                {
                    var changedType = Convert.ChangeType(strValue, key.PropertyType);

                    key.SetValue(newObject, changedType);
                }
            }

            CatsoftContext.Add(newObject);
            CatsoftContext.SaveChanges();

            return RedirectToAction("GetList", new { type = typeName });
        }


        private void CheckRole(Type type)
        {
            var cmsObject = CatsoftContext.CmsModels.FirstOrDefault(w => w.Class == type.FullName);
            var currentUserName = User.Claims.FirstOrDefault()?.Subject.Name;
            var currentUser = CatsoftContext.AdminModels.FirstOrDefault(w => w.Login == currentUserName);

            if (currentUser == null || cmsObject == null || (currentUser.Role != cmsObject.Role && currentUser.Role == AdminRoles.SuperUser))
            {
                var message = _textResourceRepository.GetByTag("You don\'t have rights to manage this object");
                throw new Exception(message);
            }
        }

        private Type GetTypeByName(string name)
        {
            return Type.GetType(_cmsOptions.AppName + "." + name) ?? Type.GetType(name);
        }

        // ReSharper disable once UnusedParameter.Local
        private static IQueryable<T> GetDbSet<T>(DbContext dbContext, T type)
            where T : class
        {
            return dbContext.Set<T>()?.AsQueryable();
        }

        #region Воин начало

        public enum DirectionSort
        {
            Asc,
            Desc
        }

        public IQueryable<IEntity> AddOrder<T, TE>(IQueryable<IEntity> list, T typeObject, TE propertyTypeObject,
            string propertyName, DirectionSort desc) where T : IEntity
        {
            var orderExpression = GetExpression(typeObject, propertyTypeObject, propertyName);
            IQueryable<T> c;

            switch (desc)
            {
                case DirectionSort.Asc:
                    c = ((IQueryable<T>)list).OrderBy(orderExpression);
                    break;
                case DirectionSort.Desc:
                    c = ((IQueryable<T>)list).OrderByDescending(orderExpression);
                    break;
                default:
                    c = ((IQueryable<T>)list).OrderBy(orderExpression);
                    break;
            }

            return c as IQueryable<IEntity>;
        }

        public Expression<Func<T, TE>> GetExpression<T, TE>(T typeObject, TE propertyTypeObject, string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T), "member");
            var member = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda<Func<T, TE>>(member, parameter);
            return lambda;
        }

        #endregion

        #region FileWork

        [HttpPost]
        public Guid AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile == null)
            {
                return Guid.Empty;
            }

            var entity = _fileHandler.Handle(uploadedFile);
            return entity.Id;
        }

        [HttpGet]
        public IActionResult AddFile(Guid id, Guid idFileProperty)
        {
            var fileViewModel = new FileViewModel
            {
                Id = idFileProperty,
                FileId = id
            };

            return View("File", fileViewModel);
        }

        public IActionResult RemoveFile(Guid id, Guid idFileProperty)
        {
            var fileViewModel = new FileViewModel
            {
                Id = idFileProperty
            };

            _fileHandler.Remove(_filesRepository.Get(id));

            _filesRepository.Remove(id);

            return View("File", fileViewModel);
        }

        #endregion

        #region ImageWork

        [HttpPost]
        public Guid AddImage(IFormFile uploadedImage)
        {
            if (uploadedImage == null)
            {
                return Guid.Empty;
            }

            var entity = _fileHandler.Handle(uploadedImage);

            return entity.Id;
        }

        [HttpGet]
        public IActionResult AddImage(Guid id, string idImageProperty)
        {
            var image = _imageRepository.Get(id);

            var imageViewModel = new ImageViewModel
            {
                ImageId = id,
                PropertyName = idImageProperty,
                Url = image?.Url
            };

            return View("Image", imageViewModel);
        }

        [HttpPost]
        public IActionResult RemoveImage(Guid id, string idImageProperty)
        {
            var imageViewModel = new ImageViewModel();
            imageViewModel.PropertyName = idImageProperty;

            _fileHandler.Remove(_imageRepository.Get(id));

            _imageRepository.Remove(id);

            return View("Image", imageViewModel);
        }

        #endregion


        //Регион для добавления изображения в связи один ко многим

        #region ManyImageWork

        [HttpPost]
        public List<Guid> AddOneToManyImageModel(IFormFileCollection uploadedImageModel, string propertyName, Guid id)
        {
            var guids = new List<Guid>();

            var formFiles = uploadedImageModel.GetFiles("uploadedImageModel");

            foreach (var formFile in formFiles)
            {
                if (formFile != null && !string.IsNullOrEmpty(propertyName))
                {
                    var entity = _fileHandler.Handle(formFile) as ImageModel;

                    var property = _typesOptions.Image.GetProperty(propertyName);
                    property?.SetValue(entity, id);

                    _imageRepository.Update(entity);

                    guids.Add(entity.Id);
                }
            }

            return guids;
        }

        [HttpGet]
        public IActionResult AddOneToManyImageModel(Guid id, string propertyName)
        {
            var image = _imageRepository.Get(id);

            var imageViewModel = new OneToManySingleImage
            {
                Id = id,
                LinkPropertyName = propertyName,
                Url = image?.Url
            };

            return View("OneToManySingleImage", imageViewModel);
        }

        public IActionResult RemoveOneToManyImage(Guid id)
        {
            _fileHandler.Remove(_imageRepository.Get(id));

            _imageRepository.Remove(id);

            return new OkResult();
        }

        #endregion
    }
}