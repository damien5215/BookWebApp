using System;
using System.Collections.Generic;
using System.Linq;
//using BookConsole2.Models;
using BookShared.Data;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Diagnostics;

namespace BookConsole2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                context.Database.Log = (message) => Debug.WriteLine(message);
                var booksQuery = from b in context.Books select b;

                var books = booksQuery
                    .Include(b => b.Author)
                    .ToList();

                Console.WriteLine("Number of Books: {0}", books.Count);
                Console.WriteLine();

                foreach (var book in books)
                {
                    Console.WriteLine(book.DisplayText);
                }
                Console.WriteLine();
                Console.WriteLine();

                var booksQuery2 = from b in context.BookGenres select b;

                var books2 = booksQuery2
                    .Include(b => b.Book)
                    .Where(b => b.Genre.GenreOfBook == "Literary")
                    //.Where(b => b.Book.Title.Contains("The"))
                    .ToList();

                Console.WriteLine("Number of Books: {0}", books2.Count);
                Console.WriteLine();

                foreach (var book in books2)
                {
                    Console.WriteLine(book.Book.Author.Name + " - " + book.Book.Title);
                }



                //.Include(b => b.Book.Author)



                //var books = context.Books
                //    .Include(b => b.Author)
                //    .Include(b => b.Genres.Select(a => a.Genre))
                //    .Include(b => b.Genres.Select(a => a.Fiction))
                //    .ToList();

                //foreach (var book in books)
                //{
                //    var genreFictionNames = book.Genres
                //        //.Select(a => $"{a.Genre.GenreOfBook} - {a.Fiction.Name}")
                //        .Select(a => $"{a.Genre.GenreOfBook}")
                //        .ToList();

                //    var genreFictionDisplayText = string.Join(", ", genreFictionNames);

                //    Console.WriteLine(book.DisplayText);
                //    Console.WriteLine(genreFictionDisplayText);
                //    Console.WriteLine();
                //}
                Console.ReadLine();
            }
        }
    }
}
