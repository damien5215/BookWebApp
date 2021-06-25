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
    public class ProductsViewModel : BooksBaseViewModel
    {
        public int AuthorId { get; set; }

        public IList<Book> BookList { get; set; }

        public ProductsViewModel()
        {

        }
    }
}