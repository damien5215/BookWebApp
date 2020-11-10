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
    public class BooksController : Controller
    {
        
        private Context _context = null;
        public BooksController()
        {
            _context = new Context();
        }

        public ActionResult Index()
        {
            var books = _context.Books      
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

            var book = _context.Books
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
            viewModel.Init(_context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(BooksAddViewModel viewModel)
        {
            var book = viewModel.Book;
            book.AddGenre(viewModel.GenreId, viewModel.FictionId);
            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Detail", new { id = book.Id });
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = _context.Books
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
            viewModel.Init(_context);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(BooksEditViewModel viewModel)
        {
            var book = viewModel.Book;

            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Detail", new { id = book.Id });
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var book = _context.Books
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
            _context.Entry(book).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        private bool _disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;

            base.Dispose(disposing);
        }
    }
}