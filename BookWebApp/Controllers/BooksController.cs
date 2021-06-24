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
            //ValidateBook(viewModel.Book);

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

        //private void ValidateBook(Book book)
        //{
        //    // If there aren't any "SeriesId" and "IssueNumber" field validation errors...
        //    if (ModelState.IsValidField("ComicBook.SeriesId") &&
        //        ModelState.IsValidField("ComicBook.IssueNumber"))
        //    {
        //        // Then make sure that the provided issue number is unique for the provided series.
        //        if (_comicBooksRepository.ComicBookSeriesHasIssueNumber(
        //                comicBook.Id, comicBook.SeriesId, comicBook.IssueNumber))
        //        {
        //            ModelState.AddModelError("ComicBook.IssueNumber",
        //                "The provided Issue Number has already been entered for the selected Series.");
        //        }
        //    }
        //}
        
        public ActionResult Home()
        {
            return View();
        }


        public ActionResult Products()    
        {
            var viewModel = new ProductsViewModel();

            viewModel.AuthorList = Repository.GetAuthorList();
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


        public ActionResult Links()
        {
            return View();
        }

        public ActionResult Test()
        {
            var viewModel = new TestViewModel();

            viewModel.BookGenreList = Repository.GetBookGenres();
            viewModel.Init(Repository);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Test(TestViewModel viewModel)
        {
            int id = viewModel.GenreId;

            viewModel.BookGenreList = Repository.GetBookGenres2(id);
            viewModel.Init(Repository);

            return View(viewModel);
        }
    }
}