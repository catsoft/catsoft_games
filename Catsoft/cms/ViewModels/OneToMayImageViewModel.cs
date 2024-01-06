using System;
using System.Collections.Generic;

namespace App.CMS.ViewModels
{
    public class OneToMayImageViewModel
    {
        /// <summary>
        /// Список уже сущевствующих картинок
        /// </summary>
        public List<(Guid Id, string Url)> Images { get; set; }

        /// <summary>
        /// Id объекта к которому привязывается картинка
        /// </summary>
        public Guid IdObject { get; set; }

        /// <summary>
        /// Имя связанного свойства
        /// </summary>
        public string LinkPropertyName { get; set; }

        public OneToMayImageViewModel(List<(Guid Id, string Url)> images, Guid idObject, string linkPropertyName)
        {
            Images = images;
            IdObject = idObject;
            LinkPropertyName = linkPropertyName;
        }
    }
}
