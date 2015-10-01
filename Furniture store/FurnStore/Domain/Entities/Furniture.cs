using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Furniture
    {
        [HiddenInput(DisplayValue = false)]
        public virtual long Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public virtual string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание для товара")]
        public virtual string Description { get; set; }

        [Display(Name = "Раздел")]
        [Required(ErrorMessage = "Пожалуйста, введите название раздела")]
        public virtual string Section { get; set; }

        [Display(Name = "Цена")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public virtual int Price { get; set; }

        [Required(ErrorMessage = "Пожалуйста, выберите изображение для товара")]
        public virtual byte[] ImageData { get; set; }
        public virtual string ImageMimeType { get; set; }



    }

    public class FurnitureMap : ClassMap<Furniture>
    {
        public FurnitureMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Description);
            Map(x => x.Price);
            Map(x => x.Section);
            Map(x => x.ImageData)
                .Column("ImageData")
                .CustomSqlType("varbinary(MAX)")
                .Length(int.MaxValue);
            Map(x => x.ImageMimeType);


        }
    }
}