using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookShared.Models;

namespace BookShared.Data
{
    public class Context : DbContext
    {
        //public Context()
        //{
            //Database.SetInitializer(new DatabaseInitializer());
        //}
        public DbSet<Book> Books { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Fiction> Fictions { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Cart> Carts { get; set; }

    }
}