using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private IFurnitureRepository repository;

        public CartController(IFurnitureRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, long id, string returnUrl)
        {
            Furniture furniture = repository.Furnitures
                .FirstOrDefault(f => f.Id == id);
            if (furniture != null)
            {
                cart.AddItem(furniture, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, long id, string returnUrl)
        {
            Furniture furniture = repository.Furnitures
                .FirstOrDefault(f => f.Id == id);

            if (furniture != null)
            {
                cart.RemoveLine(furniture);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                cart.Clear();
                return View("OrderCompleted");
            }
            else
            {
                return View(shippingDetails);
            }
        }



	}
}