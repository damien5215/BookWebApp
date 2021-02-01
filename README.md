# BookWebApp: ASP.NET, MVC, CRUD web app with EF database (code-first).

This app is adapted from a Treehouse project - 
https://github.com/treehouse-projects/dotnet-comic-book-library-manager

I followed a 4-hour tutorial and adapted the project for books (Fiction/Non-Fiction) rather than comic books.

It contains a CRUD console app and a CRUD web app. The two projects share the class files via a class library.

Adapting the project taught me more about Entity Framework 6, Connection Strings, Database Initializers, LINQ statements, CRUD functionality, Dispose Method, etc.

This web-app is not live at the moment but all of the code works as it should. To see how I built it please look at my dev blog - http://www.text.damienasp.com/007.html
 
- [x] 20/11/2020 - Added "base controller" and put database context and dispose code inside of base controller.
- [x] 26/11/2020 - Add repository and move EF database queries from controller to repository.


NOTES

Entity Framework translates LINQ queries into the appropriate SQL statements, so that they can be executed against a database.

Databases allow us to persist data across application starts and user sessions. 

Persisting data across application starts and user sessions allows users to create, update, or delete data on one day, and return on another day and still see the changes that they had previously made.

Entity Framework is an open source "Object-Relational Mapper" or ORM framework.

Using an ORM allows us to interact with our application's data using C# code.

Entities in Entity Framework are just plain old C# (or class) objects—or POCOs.

POCO classes don't inherit or depend on any framework-specific base class; they're just regular classes.

Databases that store data in tables are known as "Relational" databases.

SQL Server is a relational database that is commonly used with EF.

---------------------------------------------------------------

The context class contains a collection of "DbSet" properties, one property for each entity that you need to write queries for.

The Entity Framework DbContext class implements the "IDisposable" interface which provides a mechanism for releasing unmanaged resources, through its single method, Dispose.

Describing the shape of your data by defining entities, properties on those entities, and the relationships between entities, is known as "Data Modelling".

Data modeling is often the first step in database design and object-oriented programming, though it's almost always an activity that continues throughout the development process as your understanding of the requirements evolves.

All communication from our application to the database flows through the "Context" class.

The context can be used to retrieve entities from the database, persist new and changed entities to the database, and even to remove entities from the database.

The context class is our gateway to the database—all communication from our application to the database flows through the context.

When using the Code First workflow, your entity class names will by default become the database table names—either the singular or plural versions depending on how EF is configured.

While this is the default convention, it can be overridden using data annotation attributes or the fluent API.

Entity class "key" properties (properties that are mapped to primary key columns in the database) can be named using the following conventions: Id, ID, {ClassName}Id, {ClassName}ID.

Which workflow would you use if you want to use the visual EF Designer to define your model and you don't have an existing database? "Model First".

When you make changes to your model using the EF Designer, EF will drop and create the database.

Which workflows can be used with an existing database? "Database First and Code First".

The Database First workflow was created to be used with existing databases and the Code First workflow provides an option to generate your entity and context classes from an existing database as a one-time operation.

Which workflow allows you to define your model by writing code for your entity and context classes? "Code First".

Using the Code First workflow allows you to define and manipulate the data persistence for your applications in a very natural way—as you write the C# code for the app itself.

---------------------------------------------------------------




















