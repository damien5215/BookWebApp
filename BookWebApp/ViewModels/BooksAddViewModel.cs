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
    public class BooksAddViewModel : BooksBaseViewModel
    {
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Display(Name = "Fiction")]
        public int FictionId { get; set; }

        public SelectList GenreSelectListItems { get; set; }
        public SelectList FictionSelectListItems { get; set; }

        public BooksAddViewModel()
        {
            
        }

        /// Initializes the view model.
        public override void Init(Repository repository)
        {
            base.Init(repository);

            GenreSelectListItems = new SelectList(
                repository.GetGenreList(),
                "Id", "GenreOfBook");

            FictionSelectListItems = new SelectList(
                repository.GetFictionList(),
                "Id", "Name");
        }
    }
}





// Set the book default values.
//Book.IssueNumber = 1;
//Book.PublishedOn = DateTime.Today;