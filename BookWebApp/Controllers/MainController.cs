using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShared.Data;
using BookWebApp.ViewModels;

namespace BookWebApp.Controllers
{
    public class MainController : BaseController
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Products()
        {
            var viewModel = new ProductsViewModel();

            viewModel.BookList = Repository.GetProducts();
            viewModel.Init(Repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Products(ProductsViewModel viewModel)
        {
            int authorID = viewModel.AuthorId;

            viewModel.BookList = Repository.GetFilteredBooks(authorID);
            viewModel.Init(Repository);

            return View(viewModel);
        }

        public ActionResult Extra()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}