using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShared.Models
{
    public class Book
    {
        public Book() 
        {
            Genres = new List<BookGenre>();
        }
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string test { get; set; } // delete

        public Author Author { get; set; }
        public ICollection<BookGenre> Genres { get; set; }

        public string DisplayText 
        {
            get 
            {
                return $"{Author?.Name} - {Title}";
            }
        }

        public void AddGenre(Genre genre, Fiction fiction)
        {
            Genres.Add(new BookGenre()
            {
                Genre = genre,
                Fiction = fiction
            });
        }

        public void AddGenre(int genreId, int fictionId)
        {
            Genres.Add(new BookGenre()
            {
                GenreId = genreId,
                FictionId = fictionId
            });
        }
    }
}
