using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.NHibernate;
using NHibernate.Linq;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class FurnitureController : Controller
    {
        private IFurnitureRepository repository;
        public int pageSize = 4;

        public FurnitureController(IFurnitureRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string section, int page = 1)
        {
            FurnituresListViewModel model = new FurnituresListViewModel
            {
                Furnitures = repository.Furnitures
                .OrderBy(f => f.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = section == null ?
                    repository.Furnitures.Count() :
                    repository.Furnitures.Where(f => f.Section == section).Count()
                },
                CurrentSection = section
            };
            return View(model);
        }


        public FileContentResult GetImage(int Id)
        {
            Furniture furniture = repository.Furnitures
            .FirstOrDefault(f => f.Id == Id);

            if (furniture != null)
            {
                return File(furniture.ImageData, furniture.ImageMimeType);
            }
            else
            {
                return null;
            }
        }



    }
}