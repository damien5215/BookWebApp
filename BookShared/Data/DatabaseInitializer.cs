using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookShared.Models;

namespace BookShared.Data   //namespace BookShared
{
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context) 
        {
            // This code was copied to BookShared.Migrations.Configuration

            //var author1 = new Author()
            //{
            //    Name = "Stephen Fry",
            //    DOB = "12/04/1961"
            //};
            //var author2 = new Author()
            //{
            //    Name = "Sylvia Plath",
            //    DOB = "12/04/1940"
            //};
            //var author3 = new Author()
            //{
            //    Name = "Jean Paul Sartre",
            //    DOB = "21/06/1905"
            //};
            //var author4 = new Author()
            //{
            //    Name = "Haruki Murakami",
            //    DOB = "21/06/1965"
            //};
            //var author5 = new Author()
            //{
            //    Name = "Simone De Beauvoir",
            //    DOB = "21/10/1908"
            //};
            //var author6 = new Author()
            //{
            //    Name = "Evelyn Waugh",
            //    DOB = "21/11/1906"
            //};
            //var author7 = new Author()
            //{
            //    Name = "Bret Easton Ellis",
            //    DOB = "21/06/1970"
            //};

            //var genre1 = new Genre()
            //{
            //    GenreOfBook = "Literary"
            //};
            //var genre2 = new Genre()
            //{
            //    GenreOfBook = "General"
            //};
            //var genre3 = new Genre()
            //{
            //    GenreOfBook = "Comedy"
            //};
            //var genre4 = new Genre()
            //{
            //    GenreOfBook = "Philosophy"
            //};
            //var genre5 = new Genre()
            //{
            //    GenreOfBook = "Horror"
            //};

            //var fiction1 = new Fiction()
            //{
            //    Name = "Fiction"
            //};
            //var fiction2 = new Fiction()
            //{
            //    Name = "Non-Ficiton"
            //};

            //var book1 = new Book()
            //{
            //    Author = author1,
            //    Title = "The Liar",
            //    Description = "A funny and semi-autbiographical novel",
            //    Img = "https://images-eu.ssl-images-amazon.com/images/I/517wgjUz25L._SY291_BO1,204,203,200_QL40_ML2_.jpg",
            //    Price = 7.99M
            //};
            //book1.AddGenre(genre2, fiction1);
            //book1.AddGenre(genre3, fiction1);

            //var book2 = new Book()
            //{
            //    Author = author1,
            //    Title = "The Stars Tennis Balls",
            //    Description = "The count of monte cristo for the dot com generation.",
            //    Img = "https://images-eu.ssl-images-amazon.com/images/I/41BYWJWE9XL._SY291_BO1,204,203,200_QL40_ML2_.jpg",
            //    Price = 7.99M
            //};
            //book2.AddGenre(genre2, fiction1);

            //var book3 = new Book()
            //{
            //    Author = author2,
            //    Title = "The Bell Jar",
            //    Description = "The Bell Jar is the only novel written by the American writer and poet Sylvia Plath.",
            //    Img = "https://images-eu.ssl-images-amazon.com/images/I/41MSk1PGEdL._SY291_BO1,204,203,200_QL40_ML2_.jpg",
            //    Price = 7.99M
            //};
            //book3.AddGenre(genre1, fiction1);

            //var book4 = new Book()
            //{
            //    Author = author3,
            //    Title = "Nausea",
            //    Description = "Nausea is a philosophical novel by the existentialist philosopher Jean-Paul Sartre, published in 1938.",
            //    Img = "https://images-na.ssl-images-amazon.com/images/I/41Clc+YZi8L._SY344_BO1,204,203,200_.jpg",
            //    Price = 7.99M
            //};
            //book4.AddGenre(genre1, fiction1);
            //book4.AddGenre(genre4, fiction1);

            //var book5 = new Book()
            //{
            //    Author = author4,
            //    Title = "After Dark",
            //    Description = "Set in metropolitan Tokyo over the course of one night, characters include Mari Asai, a 19-year-old student, who is spending the night reading in a Denny's.",
            //    Img = "https://images-na.ssl-images-amazon.com/images/I/41v1AhR499L._SX322_BO1,204,203,200_.jpg",
            //    Price = 4.99M
            //};
            //book5.AddGenre(genre2, fiction1);
            //book5.AddGenre(genre5, fiction1);

            //var book6 = new Book()
            //{
            //    Author = author5,
            //    Title = "She Came to Stay",
            //    Description = "She Came to Stay is a novel written by French author Simone de Beauvoir first published in 1943. The novel is a fictional account of her and Jean-Paul Sartre's relationship with Olga Kosakiewicz and Wanda Kosakiewicz.",
            //    Img = "https://images-na.ssl-images-amazon.com/images/I/514QVA1EMAL._SX326_BO1,204,203,200_.jpg",
            //    Price = 9.99M
            //};
            //book6.AddGenre(genre2, fiction1);
            //book6.AddGenre(genre4, fiction1);

            //var book7 = new Book()
            //{
            //    Author = author5,
            //    Title = "The Prime Of Life",
            //    Description = "The author recalls her life in Paris in the formative years of 1929 to 1944, telling of her relationship with Jean-Paul Sartre and of Parisian intellectual life of the 1930s and 1940s.",
            //    Img = "https://images-eu.ssl-images-amazon.com/images/I/51h5RFk0DyL._SY291_BO1,204,203,200_QL40_ML2_.jpg",
            //    Price = 11.99M
            //};
            //book7.AddGenre(genre4, fiction2);

            //var book8 = new Book()
            //{
            //    Author = author6,
            //    Title = "Brideshead Revisited",
            //    Description = "The novel follows, from the 1920s to the early 1940s, the life and romances of the protagonist Charles Ryder, most especially his friendship with the Flytes, a family of wealthy English Catholics who live in a palatial mansion called Brideshead Castle.",
            //    Img = "https://images-eu.ssl-images-amazon.com/images/I/41pLGQzW5pL._SY291_BO1,204,203,200_QL40_ML2_.jpg",
            //    Price = 7.99M
            //};
            //book8.AddGenre(genre1, fiction1);

            //var book9 = new Book()
            //{
            //    Author = author7,
            //    Title = "American Psycho",
            //    Description = "The story is told in the first person by Patrick Bateman, a serial killer and Manhattan investment banker.",
            //    Img = "https://images-eu.ssl-images-amazon.com/images/I/41-YBbvWkhL._SY291_BO1,204,203,200_QL40_ML2_.jpg",
            //    Price = 7.99M
            //};
            //book9.AddGenre(genre2, fiction1);
            //book9.AddGenre(genre3, fiction1);

            //context.Books.Add(book1);
            //context.Books.Add(book2);
            //context.Books.Add(book3);
            //context.Books.Add(book4);
            //context.Books.Add(book5);
            //context.Books.Add(book6);
            //context.Books.Add(book7);
            //context.Books.Add(book8);
            //context.Books.Add(book9);

            //context.SaveChanges();
        }
    }
}
