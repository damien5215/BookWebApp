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
    public class BooksController : BaseController
    {
        public ActionResult Index()
        {
            var books = Repository.GetBooks();
            return View(books);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = Repository.GetBook((int)id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        public ActionResult Add()
        {
            var viewModel = new BooksAddViewModel();

            //Pass the Context class to the view model "Init" method.
            viewModel.Init(Repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(BooksAddViewModel viewModel)
        {
            var book = viewModel.Book;
            book.AddGenre(viewModel.GenreId, viewModel.FictionId);
            Repository.AddBook(book);

            return RedirectToAction("Detail", new { id = book.Id });
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = Repository.GetBook((int)id);

            if (book == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BooksEditViewModel()
            {
                Book = book
            };
            viewModel.Init(Repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(BooksEditViewModel viewModel)
        {
            var book = viewModel.Book;
            Repository.EditBook(book);

            return RedirectToAction("Detail", new { id = book.Id });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = Repository.GetBook((int)id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Repository.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}