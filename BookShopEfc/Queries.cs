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
        var list = ctx.Books
            .Where(book => book.Id < 10)
            .Select(book => new
            {
                book.Id,
                book.Title,
                book.Price
            }).ToList();
        printer.PrintList(list);
    }

    // Ex2: Find the reviews for book with id 42, and print them out
    [Fact]
    public void Ex2()
    {
        List<Review> reviews = ctx.Reviews
            .Where(rev => rev.Book.Id == 42)
            .ToList();
        printer.PrintList(reviews);
    }

    // Ex3: Find the reviews for book with id 42, and print out only Rating and VoterName
    [Fact]
    public void Ex3()
    {
        var reviews = ctx.Reviews
            .Where(rev => rev.Book.Id == 42)
            .Select(rev => new
            {
                rev.Rating,
                rev.VoterName
            }).ToList();
        printer.PrintList(reviews);
    }

    // Ex4: What are the categories for the book with id 31? 
    [Fact]
    public void Ex4()
    {
        var categories = ctx.Category
            .Where(cat => cat.Books.Any(book => book.Id == 31))
            .ToList();

        printer.PrintList(categories);
    }

    // Ex5: How many books were published in 2020? 
    [Fact]
    public void Ex5()
    {
        List<Book> booksIn2020 = ctx.Books
            .Where(book => book.PublishDate.Year == 2020)
            .ToList();
        printer.WriteLine($"Books published in 2020: {booksIn2020.Count}");
    }

    // Ex6: Who wrote the book with title "Dreamers and Wanderers"?
    [Fact]
    public void Ex6()
    {
        List<string> names = ctx.Writes
            .Where(writes => writes.Book.Title == "Dreamers and Wanderers")
            .Select(w => w.Author.Name)
            .ToList();
        printer.PrintJson(names);
    }

    // Ex7: How many books has author "Michael Lawson" written, or co-written?
    [Fact]
    public void Ex7()
    {
        int count = ctx.Writes
            .Count(w => w.Author.Name == "Michael Lawson");
        printer.WriteLine(count.ToString());
    }

    [Fact]
    public void LetsSeeWhatHappens()
    {
        Book single = ctx.Books
            .Include(book => book.Categories)
            .Include(book => book.PriceOffer)
            .Include(book => book.WrittenBy)
            .ThenInclude(writes => writes.Author)
            .Include(book => book.Reviews).First();
    }

    [Fact] // What are the categories of book with id 15?
    public void Ex2_1()
    {
        List<Category> categories = ctx.Books
            .Where(book => book.Id == 15)
            .SelectMany(book => book.Categories)
            .ToList();
        printer.PrintList(categories);
    }

    [Fact] // Print the names of the authors of the book named ”A World Apart”?
    public void Ex2_2()
    {
        var list = ctx.Books
            .Where(book => book.Title == "A World Apart")
            .SelectMany(book => book.WrittenBy)
            .Select(writes => new
            {
                writes.Author.Name
            }).ToList();
        
        printer.PrintList(list);
    }

    [Fact] // Find the book with name ”Beyond the Dark Woods”,
           // and print out the following attributes:
           // Book::Title, PriceOffer::NewPrice, PriceOffer::PromotionalText.
    public void Ex2_3()
    {
        var single = ctx.Books
            // .Where(book => book.Title == "Beyond the Dark Woods")
            .Select(book => new
            {
                book.Title,
                ActualPrice = book.PriceOffer != null ? book.PriceOffer.NewPrice : book.Price,
                PromotionalText = book.PriceOffer != null ? book.PriceOffer.PromotionalText : null,
            })
            .ToList();
        printer.PrintList(single);
    }

    [Fact] // How many reviews are there for the book with title ”The Last Ember”?
    public void Ex2_4()
    {
        int count = ctx.Reviews
            .Count(review => review.Book.Title == "The Last Ember");
        
        printer.WriteLine(count.ToString());
    }

    [Fact] // Print the titles of the books written by ”Emily Hart”.
    public void Ex2_5()
    {
    }
}