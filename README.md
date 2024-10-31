# Book Shop Entity Framework Core Exercises

The purpose of this repository is to train some simple EFC LINQ queries. 

I have a Queries class, with a number of unit test methods, each test is an exercise.

I have the DbContext, called BookShopContext, with defined DbSets for the entities.

You clone the repository, and then you probably need to change the Data Source path to the absolute path of the bookstore.db file.

I.e., you update the following in ImdbContext:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source = bookstore.db");
}
```

To something like:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source = C:\MyDrive\Projects\BookShopEfc\BookShopEfc\bookstore.db");
}
```

Here is the entity class diagram:

![diagram]()
