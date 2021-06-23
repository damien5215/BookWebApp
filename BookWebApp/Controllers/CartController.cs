using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using BookShared.Data;
using System.Net;
using BookWebApp.ViewModels;
using BookShared.Models;

namespace BookWebApp.Controllers
{
    public class CartController : BaseController
    {
        //public ActionResult Cart()
        //{
        //    var books = Repository.GetCart();
        //    return View(books);
        //}

        public ActionResult _Cart()
        {
            var books = Repository.GetCart();
            return View(books);
        }

        public ActionResult _TotalCost()
        {
            var books = Repository.GetCart();

            decimal x1 = 0M;

            foreach (var item in books)
            {
                x1 += (item.Quantity * item.Book.Price);
            }
            ViewBag.TotPrice = x1;

            return View();
        }

        public ActionResult Add(int? id) 
        {
            var book = Repository.GetBook((int)id);
            var cart = Repository.GetCartCheck((int)id);
            var cartList = Repository.GetCart();

            if (cart == null)
            {
                var cart1 = new Cart()
                {
                    Id = (cartList.Count + 1),
                    Book = book,
                    Quantity = 1
                };
                
                Repository.AddCart(cart1);

                return RedirectToAction("Products", "Books");
            }
            else
            {
                cart.Quantity++;
                Repository.EditCart(cart);
                return RedirectToAction("Products", "Books");
            }
        }

        public ActionResult Delete(int id)
        {
            var cart = Repository.GetCartCheckDelete(id);

            if (cart.Quantity > 1)
            {
                cart.Quantity--;
                Repository.EditCart(cart);
                return RedirectToAction("Products", "Books");
            }
            else 
            {
                Repository.DeleteCart(id);
                return RedirectToAction("Products", "Books");
            }
        }

        //public ActionResult Delete(int id)
        //{
        //    Repository.DeleteCart(id);

        //    return RedirectToAction("Products2", "Books");
        //}
    }
}