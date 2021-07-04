using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWebApp.ViewModels;

namespace BookWebApp.Controllers
{
    public class TestController : BaseController
    {
        public ActionResult Products()
        {
            var viewModel = new ProductsViewModel();

            viewModel.BookList = Repository.GetProducts();
            viewModel.Init(Repository);

            return View(viewModel);
        }

        public ActionResult _Book()
        {
            var viewModel = new ProductsViewModel();

            viewModel.BookList = Repository.GetProducts();
            viewModel.Init(Repository);

            return PartialView(viewModel);
        }

        [HttpPost]
        public ActionResult _Book(int id)
        {
            var viewModel = new ProductsViewModel();
            viewModel.BookList = Repository.GetFilteredBooks(id);
            viewModel.Init(Repository);

            return PartialView(viewModel);

        }
    }
}