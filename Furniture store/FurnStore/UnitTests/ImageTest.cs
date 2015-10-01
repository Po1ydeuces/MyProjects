using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Moq;
using Domain.Abstract;
using System.Collections.Generic;
using WebUI.Controllers;
using System.Web.Mvc;

namespace UnitTests
{
    [TestClass]
    public class ImageTest
    {
        [TestMethod]
        public void Can_Retrieve_Image_Data()
        {
            // Организация - создание объекта Game с данными изображения
            Furniture furniture = new Furniture
            {
                Id = 2,
                Name = "Мебель1",
                Description = "Описание",
                Section = "Раздел",
                Price = 200,
                ImageData = new byte[] { },
                ImageMimeType = "image/png"
            };

            // Организация - создание имитированного хранилища
            Mock<IFurnitureRepository> mock = new Mock<IFurnitureRepository>();
            mock.Setup(m => m.Furnitures).Returns(new List<Furniture>
            {
            new Furniture { Id = 1, Name = "Мебель1", Description = "Описание", Section = "Раздел", Price = 100 ,
                ImageData = new byte[] { }, ImageMimeType = "image/png"},
            new Furniture { Id = 2, Name = "Мебель2", Description = "Описание", Section = "Раздел", Price = 100,
                ImageData = new byte[] { }, ImageMimeType = "image/png"},
            });

            // Организация - создание контроллера
            FurnitureController controller = new FurnitureController(mock.Object);

            // Действие - вызов метода действия GetImage()
            ActionResult result = controller.GetImage(2);

            // Утверждение
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(furniture.ImageMimeType, ((FileResult)result).ContentType);
        }

        [TestMethod]
        public void Cannot_Retrieve_Image_Data_For_Invalid_ID()
        {
            // Организация - создание имитированного хранилища
            Mock<IFurnitureRepository> mock = new Mock<IFurnitureRepository>();
            mock.Setup(m => m.Furnitures).Returns(new List<Furniture>
            {
            new Furniture { Id = 1, Name = "Мебель1", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 2, Name = "Мебель2", Description = "Описание", Section = "Раздел", Price = 100},
            });

            // Организация - создание контроллера
            FurnitureController controller = new FurnitureController(mock.Object);

            // Действие - вызов метода действия GetImage()
            ActionResult result = controller.GetImage(10);

            // Утверждение
            Assert.IsNull(result);
        }
    }
}
