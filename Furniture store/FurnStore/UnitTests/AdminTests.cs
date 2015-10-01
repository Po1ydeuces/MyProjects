using Domain.Abstract;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebUI.Controllers;

namespace UnitTests
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_Contains_All_Furnitures()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IFurnitureRepository> mock = new Mock<IFurnitureRepository>();
            mock.Setup(m => m.Furnitures).Returns(new List<Furniture>
            {
            new Furniture { Id = 1, Name = "Мебель1", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 2, Name = "Мебель2", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 3, Name = "Мебель3", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 4, Name = "Мебель4", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 5, Name = "Мебель5", Description = "Описание", Section = "Раздел", Price = 100},
            });

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Действие
            List<Furniture> result = ((IEnumerable<Furniture>)controller.Index().
            ViewData.Model).ToList();

            // Утверждение
            Assert.AreEqual(result.Count(), 5);
            Assert.AreEqual("Мебель1", result[0].Name);
            Assert.AreEqual("Мебель2", result[1].Name);
            Assert.AreEqual("Мебель3", result[2].Name);
        }

        [TestMethod]
        public void Cannot_Edit_Nonexistent_Furn()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IFurnitureRepository> mock = new Mock<IFurnitureRepository>();
            mock.Setup(m => m.Furnitures).Returns(new List<Furniture>
            {
            new Furniture { Id = 1, Name = "Мебель1", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 2, Name = "Мебель2", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 3, Name = "Мебель3", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 4, Name = "Мебель4", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 5, Name = "Мебель5", Description = "Описание", Section = "Раздел", Price = 100},
            });

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Действие
            Furniture result = controller.Edit(6).ViewData.Model as Furniture;
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IFurnitureRepository> mock = new Mock<IFurnitureRepository>();

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Организация - создание объекта Game
            Furniture furniture = new Furniture 
                    { Id = 1, Name = "Мебель1", Description = "Описание", Section = "Раздел", Price = 100 };

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(furniture);

            // Утверждение - проверка того, что к хранилищу производится обращение
            mock.Verify(m => m.UpdateFurniture(furniture));

            // Утверждение - проверка типа результата метода
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Организация - создание имитированного хранилища данных
            Mock<IFurnitureRepository> mock = new Mock<IFurnitureRepository>();

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Организация - создание объекта Game
            Furniture furniture = new Furniture { Id = 1, Name = "Мебель1", Description = "Описание", Section = "Раздел", Price = 100 };
    
            // Организация - добавление ошибки в состояние модели
            controller.ModelState.AddModelError("error", "error");

            // Действие - попытка сохранения товара
            ActionResult result = controller.Edit(furniture);

            // Утверждение - проверка того, что обращение к хранилищу НЕ производится 
            mock.Verify(m => m.UpdateFurniture(It.IsAny<Furniture>()), Times.Never());

            // Утверждение - проверка типа результата метода
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Furnitures()
        {
            // Организация - создание объекта Game
            Furniture furniture = new Furniture { Id = 1, Name = "Мебель1", Description = "Описание", Section = "Раздел", Price = 100 };

            // Организация - создание имитированного хранилища данных
            Mock<IFurnitureRepository> mock = new Mock<IFurnitureRepository>();
            mock.Setup(m => m.Furnitures).Returns(new List<Furniture>
    {
            new Furniture { Id = 1, Name = "Мебель1", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 2, Name = "Мебель2", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 3, Name = "Мебель3", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 4, Name = "Мебель4", Description = "Описание", Section = "Раздел", Price = 100},
            new Furniture { Id = 5, Name = "Мебель5", Description = "Описание", Section = "Раздел", Price = 100},
    });

            // Организация - создание контроллера
            AdminController controller = new AdminController(mock.Object);

            // Действие - удаление игры
            controller.Delete(furniture);

            // Утверждение - проверка того, что метод удаления в хранилище
            // вызывается для корректного объекта Game
            mock.Verify(m => m.DeleteFurniture(furniture));
        }

    }
}
