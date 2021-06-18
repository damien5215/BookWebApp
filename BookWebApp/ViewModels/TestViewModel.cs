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
    public class TestViewModel : BooksBaseViewModel
    {
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public SelectList GenreSelectListItems { get; set; }

        public TestViewModel()
        {

        }

        public override void Init(Repository repository)
        {
            base.Init(repository);

            GenreSelectListItems = new SelectList(
                repository.GetGenreList(),
                "Id", "GenreOfBook");

        }

    }
}