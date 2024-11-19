using Microsoft.EntityFrameworkCore;
using Xunit.Abstractions;

namespace BookShopEfc;

public class Queries(ITestOutputHelper printer)
{
    private BookShopContext ctx = new();

    // Example
    [Fact]
    public void ExampleOnHowToPrintStuff()
    {
        Book b = new()
        {
            Id = 1,
            Price = 25.0m,
            Title = "My Book",
            PublishDate = new DateOnly(2024, 10, 31)
        };
        printer.PrintObject(b);

        printer.WriteLine("\n\n=========\n\n");

        Book b1 = new()
        {
            Id = 2,
            Price = 37m,
            Title = "My other book",
            PublishDate = new DateOnly(2024, 10, 21)
        };
        List<Book> list = [b, b1];
        printer.PrintList(list);
    }

    // Ex1: Find the books with id less than 10 and print out id, title, price
    [Fact]
    public void Ex1()
    {
    }

    // Ex2: Find the reviews for book with id 42, and print them out
    [Fact]
    public void Ex2()
    {
    }

    // Ex3: Find the reviews for book with id 42, and print out only Rating and VoterName
    [Fact]
    public void Ex3()
    {
    }

    // Ex4: What are the categories for the book with id 31? 
    [Fact]
    public void Ex4()
    {
    }
    
    // Ex5: How many books were published in 2020? 
    [Fact]
    public void Ex5()
    {
    }

    // Ex6: Who wrote the book with title "Dreamers and Wanderers"?
    [Fact]
    public void Ex6()
    {

    }
    
    // Ex7: How many books has author "Michael Lawson" written, or co-written?
    [Fact]
    public void Ex7()
    {

    }
}