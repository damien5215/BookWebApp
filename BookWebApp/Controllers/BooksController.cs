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
            var books = Context.Books      
                    .Include(b => b.Author)
                    .OrderBy(b => b.Author.Name)
                    .ToList();

            return View(books);
        }

        public ActionResult Detail(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = Context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genres.Select(c => c.Genre))
                    .Include(b => b.Genres.Select(c => c.Fiction))
                    .Where(b => b.Id == id)
                    .SingleOrDefault();

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
            viewModel.Init(Context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(BooksAddViewModel viewModel)
        {
            var book = viewModel.Book;
            book.AddGenre(viewModel.GenreId, viewModel.FictionId);
            Context.Books.Add(book);
            Context.SaveChanges();

            return RedirectToAction("Detail", new { id = book.Id });
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = Context.Books
                .Where(cb => cb.Id == id)
                .SingleOrDefault();

            if (book == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BooksEditViewModel()
            {
                Book = book
            };
            viewModel.Init(Context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(BooksEditViewModel viewModel)
        {
            var book = viewModel.Book;

            Context.Entry(book).State = EntityState.Modified;
            Context.SaveChanges();

            return RedirectToAction("Detail", new { id = book.Id });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = Context.Books
                .Include(cb => cb.Author)
                .Where(cb => cb.Id == id)
                .SingleOrDefault();

            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var book = new Book() { Id = id };
            Context.Entry(book).State = EntityState.Deleted;
            Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}