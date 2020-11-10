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
    public class BooksEditViewModel : BooksBaseViewModel
    {
        // This property enables model binding to be able to bind the "id"
        // route parameter value to the "Book.Id" model property.
        public int Id
        {
            get { return Book.Id; }
            set { Book.Id = value; }
        }
    }
}