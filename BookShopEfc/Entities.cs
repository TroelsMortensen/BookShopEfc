namespace BookShopEfc;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public DateOnly PublishDate { get; set; }
    public decimal Price { get; set; }
    
    public PriceOffer? PriceOffer { get; set; } // Reference navigation property

    public List<Review> Reviews { get; set; } = []; // Collection navigation property
    
    public List<Category> Categories { get; set; } = []; // Collection navigation property
    
    public List<Writes> WrittenBy { get; set; } = []; // Collection navigation property
}

public class PriceOffer
{
    public int Id { get; set; }
    public decimal NewPrice { get; set; }
    public string PromotionalText { get; set; } = null!;
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}

public class Review
{
    public int Id { get; set; }
    public int Rating { get; set; }
    public string VoterName { get; set; } = null!;
    public string? Comment { get; set; }
    
    public int BookId { get; set; } // Foreign key property
    public Book Book { get; set; } = null!; // Reference navigation property
}

public class Category
{
    public string Name { get; set; } = null!;
    
    public List<Book> Books { get; set; } = []; // Collection navigation property
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public List<Writes> Writes { get; set; } = []; // Collection navigation property
}

public class Writes
{
    public int Order { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
}