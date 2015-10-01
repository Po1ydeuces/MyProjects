using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Models
{
    public class FurnituresListViewModel
    {
        public IEnumerable<Furniture> Furnitures { get; set; }

        public PagingInfo PagingInfo { get; set; }
        public string CurrentSection { get; set; }
    }
}