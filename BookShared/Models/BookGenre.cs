﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShared.Models
{
    public class BookGenre
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
        public int FictionId { get; set; }

        public Book Book { get; set; }
        public Genre Genre { get; set; }
        public Fiction Fiction { get; set; }
    }
}
