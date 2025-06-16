using Microsoft.EntityFrameworkCore;
using BookManagementSystem.Models;

namespace BookManagementSystem.Data;

public class BookManagementContext : DbContext
{
    public BookManagementContext
    (DbContextOptions<BookManagementContext> options)
    : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure many-to-many relationship
            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookID, bg.GenreID });
                
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookID);
                
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreID);
                
            // Configure one-to-many relationship
            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Book)
                .WithMany(b => b.Stocks)
                .HasForeignKey(s => s.BookId);
    }

}