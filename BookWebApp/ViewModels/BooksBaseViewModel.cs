using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookShared.Data;
using BookShared.Models;

namespace BookWebApp.ViewModels
{
    public abstract class BooksBaseViewModel
    {
        public Book Book { get; set; } = new Book();
        public SelectList AuthorSelectListItems { get; set; }

        /// Initializes the view model.
        public virtual void Init(Repository repository)
        {
            AuthorSelectListItems = new SelectList(
                repository.GetAuthorList(),
                "Id", "Name");
        }
    }
}