﻿using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class NavController : Controller
    {
        private IFurnitureRepository repository;

        public NavController(IFurnitureRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu(string section = null, bool horizontalNav = false)
        {
            ViewBag.SelectedSection = section;

            IEnumerable<string> sections = repository.Furnitures
                .Select(f => f.Section)
                .Distinct()
                .OrderBy(x => x);

            return PartialView("FlexMenu", sections);
        }

	}
}