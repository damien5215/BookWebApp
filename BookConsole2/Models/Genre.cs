using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookConsole2.Models
{
    public class Genre
    {
        public Genre()
        {
            Books = new List<BookGenre>();
        }
        public int Id { get; set; }
        public string GenreOfBook { get; set; }

        public ICollection<BookGenre> Books { get; set; }
    }
}
