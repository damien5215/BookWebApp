using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookShared.Models;
using System.Data.Entity;

namespace BookShared.Data
{
    public class Repository
    {
        private Context _context = null;

        public Repository(Context context) 
        {
            _context = context;
        }

        public IList<Book> GetBooks() 
        {
            return _context.Books
                    .Include(b => b.Author)
                    .OrderBy(b => b.Author.Name)
                    .ToList();
        }

        public IList<Book> GetProducts()
        {
            return _context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genres.Select(c => c.Genre))    
                    .OrderBy(b => b.Author.Name)
                    .ToList();
        }

        // FOR TESTING
        public IList<BookGenre> GetBookGenres()   
        {
            return _context.BookGenres
                    .Include(b => b.Genre)
                    .Include(b => b.Book)
                    .Include(b => b.Book.Author)
                    .ToList();
        }

        // FOR TESTING
        public IList<BookGenre> GetBookGenres2(int id)
        {
            return _context.BookGenres
                    .Include(b => b.Genre)
                    .Include(b => b.Book)
                    .Include(b => b.Book.Author)
                    .Where(b => b.Genre.Id == id)
                    .ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genres.Select(c => c.Genre))
                    .Include(b => b.Genres.Select(c => c.Fiction))
                    .Where(b => b.Id == id)
                    .SingleOrDefault();
        }

        public Book GetBookEdit(int id)
        {
            return _context.Books
                .Where(cb => cb.Id == id)
                .SingleOrDefault();
        }

        public IList<Genre> GetGenreList() 
        {
            return _context.Genres
                .OrderBy(a => a.GenreOfBook)
                .ToList();
        }

        public IList<Fiction> GetFictionList()
        {
            return _context.Fictions
                .OrderBy(r => r.Name)
                .ToList();
        }

        public IList<Author> GetAuthorList()
        {
            return _context.Authors
                .OrderBy(r => r.Name)
                .ToList();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void EditBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteBook(int id) 
        {
            var book = new Book() { Id = id };
            _context.Entry(book).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
