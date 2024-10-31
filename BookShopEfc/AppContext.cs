using Microsoft.EntityFrameworkCore;

namespace BookShopEfc;

public class AppContext : DbContext
{
    public DbSet<Book> Books => Set<Book>();
    public DbSet<PriceOffer> PriceOffers => Set<PriceOffer>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Writes> Writes => Set<Writes>();
    public DbSet<Category> Category => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source = bookstore.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasKey(c => c.Name);

        modelBuilder.Entity<Writes>()
            .HasKey(w => new { w.BookId, w.AuthorId });
    }
}