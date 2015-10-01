using Domain.Abstract;
using Domain.Entities;
using Domain.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using NHibernate.Linq;

namespace WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IFurnitureRepository repository;
        public AdminController(IFurnitureRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Furnitures);
        }

        public ViewResult Edit(int id)
        {
            Furniture furniture = repository.Furnitures
            .FirstOrDefault(f => f.Id == id);
            return View(furniture);
        }

        public ViewResult Create()
        {
            return View("Edit", new Furniture());
        }


        [HttpPost]
        public ActionResult Edit(Furniture furniture, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    furniture.ImageMimeType = image.ContentType;
                    furniture.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(furniture.ImageData, 0, image.ContentLength);
                }

                if (furniture.Id != 0)
                    repository.UpdateFurniture(furniture);
                else
                    repository.CreateFurniture(furniture);
                TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", furniture.Name);
                return RedirectToAction("Index");
            }
            else
            {
                return View(furniture);
            }
        }

        [HttpPost]
        public ActionResult Delete(Furniture furniture)
        {
            Furniture deletedFurniture = repository.DeleteFurniture(furniture);
            if (deletedFurniture != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" был удален",
                    deletedFurniture.Name);
            }
            return RedirectToAction("Index");
        }



    }
}