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
    public class TotalCostViewModel : BooksBaseViewModel
    {
        public Decimal TotalCost { get; set; }

        public TotalCostViewModel(Decimal totalCost)
        {
            TotalCost = totalCost;
        }
    }
}