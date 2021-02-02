# BookWebApp: ASP.NET, MVC, CRUD web app with EF database (code-first).

This app is adapted from a Treehouse project - 
https://github.com/treehouse-projects/dotnet-comic-book-library-manager

I followed a 4-hour tutorial and adapted the project for books (Fiction/Non-Fiction) rather than comic books.

It contains a CRUD console app and a CRUD web app. The two projects share the class files via a class library.

Adapting the project taught me more about Entity Framework 6, Connection Strings, Database Initializers, LINQ statements, CRUD functionality, Dispose Method, etc.

This web-app is not live at the moment but all of the code works as it should. To see how I built it please look at my dev blog - http://www.text.damienasp.com/007.html
 
- [x] 20/11/2020 - Added "base controller" and put database context and dispose code inside of base controller.
- [x] 26/11/2020 - Add repository and move EF database queries from controller to repository.


NOTES : Intro 1

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

NOTES : Intro 2

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

NOTES: Entity Framework and Databases 1

The "ProjectsV13" LocalDB instance is created specifically for SQL Server Data Tools and shouldn't be used for application development. "True".

The "MSSQLLocalDB" LocalDB instance should be used for application development.

MSSQLLocalDB is the LocalDB default instance name used by SQL Server 2014 and 2016 (versions 12 and 13 respectively).

Which of the following commands will list the available LocalDB instances? "sqllocaldb info".

Being able to list the available LocalDB instances is helpful when you need to debug Entity Framework database connection issues.

Getting started with Entity Framework is expensive as you must purchase a commercial license for SQL Server. "False.

Fortunately, we can target a free, developer-centric version of SQL Server named LocalDB, which is installed by default when you install Visual Studio Community.

---------------------------------------------------------------

NOTES: Entity Framework and Databases 2

When using the Code First workflow, adding a database connection string—whose name matches the name of our context class—to our app's configuration file allows us to customize the name of the generated database.

Using this option makes it possible to change the location or name of the database without having to rewrite our code, which is especially helpful when deploying applications into other environments.

During development, which of the following database initializer classes can be used to drop and create the database every time that a change to the model is made? "DropCreateDatabaseModelChanges".

Since the database is dropped (i.e. deleted) before it's created again, this database initializer should not be used once an application has gone into production in order to prevent data loss.

When using the Code First workflow, EF compiles a list of the entities and their properties, and for each property, characteristics such as its data type and nullability into the EDMX. "Conceptual Model".

The Storage Model describes how data is stored in the database and the Conceptual-Storage Mappings describe how the Conceptual Model maps to the Storage Model.

By default, when using the Code First workflow, the first time that we access one of the context's DbSet properties, EF will "check if the database exists, and it doesn't exist, it'll create it".

By default, Entity Framework uses the CreateDatabaseIfNotExists database initializer.

Visual Studio's SQL Server Object Explorer window can be used to view a SQL Server LocalDB database's tables and data.

The SQL Server Object Explorer window also exposes a set of commands that allow you to create new databases and add tables to existing databases.

When using the Code First workflow, EF adds every entity property as a table column. "False".

EF only adds table columns for entity properties that have a setter—public, protected, or private.

For the entity property public string Name { get; set; }, what SQL Server column data type would EF use for the table column? "nvarchar(MAX)"

The "MAX" part within the parentheses indicates that the column can contain a string as large as the maximum allowed size—which is a very large string, 2GB or approximately a billion characters.

When EF detects an existing database, it queries the EDMX from the "MigrationHistory" table and compares the current, in-memory model to the model stored in the database and throws an exception if they aren't compatible when using the default CreateDatabaseIfNotExists database initializer. "True"

The DropCreateDatabaseAlways and DropCreateDatabaseIfModelChanges database initializers allow you to customize this behavior.

During development, which of the following database initializer classes can be used to drop and create the database every time that a change to the model is made? "DropCreateDatabaseModelChanges".

Since the database is dropped (i.e. deleted) before it's created again, this database initializer should not be used once an application has gone into production in order to prevent data loss.

When EF creates your database, it includes a table named "MigrationHistory" that contains a compressed version of the EDMX for the model that was used to create the database.

---------------------------------------------------------------

NOTES: Entity Data Model

When an instance of entity "A" can be associated with one or more instances of entity "B" and an instance of entity "B" can also be associated with one or more instances of entity "A", those entities are said to be in a "Many-to-Many" relationship.

Representing a Many-to-Many relationship in the database requires either an implicit or explicit bridge table.

When defining a many-to-many relationship without defining an explicit bridge entity class, Entity Framework will automatically add an "implicit" bridge table to the database in order to store the relationship data.

Defining an explicit Many-to-Many bridge entity class allows you to include additional properties beyond the properties that are needed to define the relationship. "True"

These additional properties are often referred to as "payload".

The Required data annotation attribute can be used on nullable entity properties to make their associated database table columns not allow nulls.

The Include method can be used in a LINQ query to load related data. "True". 

Using the Include method to load related data is known as "eager" loading.

"Navigation" properties allow you to define relationships between entities.

"Seeding" your database is the process of initially populating your database with data.

Sometimes the seed data is fake or dummy data that enables the development or testing of the system; sometimes it's data that needs to be present in order for the system to operate correctly.

You can override the DbContext class "OnModelCreating" method in order to customize EF's conventions or use EF's fluent API to refine your model.

It's possible to rely completely upon the fluent API to refine your model and not use any data annotation attributes in your entity classes.

---------------------------------------------------------------

NOTES: LINQ Queries

The behavior of LINQ to Entities queries not executing until they're enumerated—either by using a loop or by calling a method on the query like ToList or Count—is called "Deferred Execution".

Deferred execution allows queries to be executed more than once or to be combined or extended before they're executed.































