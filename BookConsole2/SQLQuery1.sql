SELECT Authors.Name, Books.Title 
FROM Books INNER JOIN Authors 
ON Books.Id = Authors.Id


SELECT Books.Title, Genres.GenresOfBook
FROM Books
INNER JOIN BookGenres
ON Books.Id = BookGenres.BookId
INNER JOIN Genres
ON Genres.Id = BookGenres.BookId
 

SELECT Books.Title,
       BookGenres.BookId, 
       Genres.GenreOfBook 
FROM BookGenres 
INNER JOIN Genres ON BookGenres.GenreId = Genres.Id
INNER JOIN Books ON BookGenres.BookId = Books.Id
ORDER BY BookId


SELECT Authors.Name,
       Books.Title,
       Genres.GenreOfBook
FROM BookGenres 
INNER JOIN Genres ON BookGenres.GenreId = Genres.Id
INNER JOIN Books ON BookGenres.BookId = Books.Id
INNER JOIN Authors ON Books.AuthorId = Authors.Id
ORDER BY BookId



SELECT Authors.Name,
       Books.Title,
       Genres.GenreOfBook
FROM BookGenres 
INNER JOIN Genres ON BookGenres.GenreId = Genres.Id
INNER JOIN Books ON BookGenres.BookId = Books.Id
INNER JOIN Authors ON Books.AuthorId = Authors.Id
--WHERE GenreOfBook='Literary'
ORDER BY BookId