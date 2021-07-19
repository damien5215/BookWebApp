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

        public ActionResult ProductsTest()
        {
            return View();
        }

        
        public ActionResult _ProductsTestBooks()
        {
            var viewModel = new ProductsTestViewModel();
            viewModel.BookList = Repository.GetProducts();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult _ProductsTestBooks(string searchString)
        {
            var viewModel = new ProductsTestViewModel();

            // search by "Book Title"
            viewModel.BookList = Repository.GetFilteredBooksString(searchString);

            // search by "Author Name"
            if (viewModel.BookList.Count == 0) 
            { 
                viewModel.BookList = Repository.GetFilteredBooksString2(searchString);
            }

            // search by "Genre"
            if (viewModel.BookList.Count == 0)
            {
                viewModel.BookGenreList = Repository.GetFilteredBooksString3(searchString);
                viewModel.IsGenre = true;
            }

            return PartialView(viewModel);
        }
    }
}