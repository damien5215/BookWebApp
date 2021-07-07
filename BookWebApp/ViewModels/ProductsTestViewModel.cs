using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShared.Data;
using BookShared.Models;
using System.ComponentModel.DataAnnotations;

namespace BookWebApp.ViewModels
{
    public class ProductsTestViewModel : BooksBaseViewModel
    {
        public bool IsGenre { get; set; }

        public IList<Book> BookList { get; set; }
        public IList<BookGenre> BookGenreList { get; set; }

        public ProductsTestViewModel()
        {

        }
    }
}