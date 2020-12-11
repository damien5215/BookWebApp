# BookWebApp: ASP.NET, MVC, CRUD web app with EF database (code-first).

This app is adapted from a Treehouse project - 
https://github.com/treehouse-projects/dotnet-comic-book-library-manager

I followed a 4-hour tutorial and adapted the project for books (Fiction/Non-Fiction) rather than comic books.

It contains a CRUD console app and a CRUD web app. The two projects share the class files via a class library.

Adapting the project taught me more about Entity Framework 6, Connection Strings, Database Initializers, LINQ statements, CRUD functionality, Dispose Method, etc.

This web-app is not live at the moment but all of the code works as it should. To see how I built it please look at my dev blog - http://www.text.damienasp.com/007.html
 
- [x] 20/11/2020 - Added "base controller" and put database context and dispose code inside of base controller.
- [x] 26/11/2020 - Add repository and move EF database queries from controller to repository.
