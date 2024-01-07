using System;
using System.Collections.Generic;

namespace App.cms.ViewModels
{
    public class OneToMayImageViewModel(List<(Guid Id, string Url)> images, Guid idObject, string linkPropertyName)
    {
        /// <summary>
        /// Список уже сущевствующих картинок
        /// </summary>
        public List<(Guid Id, string Url)> Images { get; set; } = images;

        /// <summary>
        /// Id объекта к которому привязывается картинка
        /// </summary>
        public Guid IdObject { get; set; } = idObject;

        /// <summary>
        /// Имя связанного свойства
        /// </summary>
        public string LinkPropertyName { get; set; } = linkPropertyName;
    }
}
