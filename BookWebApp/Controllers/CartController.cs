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
        public ActionResult Cart()
        {
            var books = Repository.GetCart();
            return View(books);
        }

        //Parital View
        public ActionResult _Cart2()
        {
            var books = Repository.GetCart();
            return View(books);
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

                //return RedirectToAction("Cart");
                return RedirectToAction("Products", "Books");
            }
            else
            {
                cart.Quantity++;
                Repository.EditCart(cart);
                //return RedirectToAction("Cart");
                return RedirectToAction("Products", "Books");
            }
        }

        public ActionResult Delete(int id)
        {
            Repository.DeleteCart(id);
            
            //return RedirectToAction("Cart");
            return RedirectToAction("Products", "Books");
        }

        public ActionResult Test() 
        {
            var book = Repository.GetBooks();
            
            ViewBag.TotalBooks = book.Count;

            return View();
        }
    }
}