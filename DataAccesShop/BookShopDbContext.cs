using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccesShop.Entities;
using DataAccesShop.Helpers;

namespace DataAccesShop
{
    public class BookShopDbContext : DbContext
    {
        public Book CreateBook(string title, int authorId, int publisherId, int pages, int genreId, int year, decimal price, decimal priceForSale)
        {
            var book = new Book
            {
                Title = title,
                AuthorId = authorId,
                PublisherId = publisherId,
                Pages = pages,
                GenreId = genreId,
                Year = year,
                Price = price,
                PriceForSale = priceForSale
            };
            return book;
        }
        public Book AddBook(Book book)
        {
            var addedBook = this.Books.Add(book);
            return addedBook.Entity;
        }
        public void DeleteBook(int id)
        {
            var book = this.Books.Find(id);
            if (book != null)
            {
                this.Books.Remove(book);
            }
        }
        public void UpdateBook(int id, string title, int authorId, int publisherId, int pages, int genreId, int year, decimal price, decimal priceForSale)
        {
            var book = this.Books.Find(id);
            if (book != null)
            {
                book.Title = title;
                book.AuthorId = authorId;
                book.PublisherId = publisherId;
                book.Pages = pages;
                book.GenreId = genreId;
                book.Year = year;
                book.Price = price;
                book.PriceForSale = priceForSale;
            }
        }

        public void SetDiscount(int id, int discount)
        {
            var book = this.Books.Find(id);
            if (book != null)
            {
                book.Discount = discount;
                book.PriceForSale = book.Price - (book.Price * discount / 100);
            }
        }

        public void AsideForBuyer(int bookId, Client client)
        {
            var book = this.Books.Find(bookId);
            if (book != null)
            {
                if (book.Clients == null)
                {
                    book.Clients = new List<Client>();
                }
                book.Clients.Add(client);
            }
        }

        public void ShowAllBooks()
        {
            var books = this.Set<Book>().Include(b=>b.Author).Include(b=>b.Genre).Include(b=>b.NextChapter).Include(b => b.Publisher).ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book);
                Console.WriteLine("\n--------------------\n");
            }
        }







        public void FindBooksByTitle(string name)
        {
            var books = this.Set<Book>()
                .Where(b => b.Title.Contains(name))
                .ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        public void FindBooksByAuthor(string authorName)
        {
            var books = this.Set<Book>()
                .Where(b => b.Author.Name.Contains(authorName) || b.Author.Surname.Contains(authorName))
                .ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        public void FindBooksByGenre(string genreName)
        {
            var books = this.Set<Book>()
                .Where(b => b.Genre.Name.Contains(genreName))
                .ToList();
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        public List<Book> ShowNewBooks()
        {
            var books = this.Set<Book>()
                .Where(b => b.Year >= DateTime.Now.Year - 1)
                .ToList();
            return books;
        }

        public List<Book> ShowPopularBooks()
        {
            var books = this.Set<Book>()
                .OrderByDescending(b => b.Clients.Count)
                .Take(10)
                .ToList();
            return books;
        }


       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog = BookShop;
                                        Integrated Security=True;
                                        Connect Timeout=5;
                                        Encrypt=False;Trust Server Certificate=False;
                                        Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                .Property(a => a.Name)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .Property(a => a.Surname)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Author>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Authors);

            modelBuilder.Entity<Author>()
                .HasMany(a => a.Followers)
                .WithMany(f => f.FollowedAuthors);


            modelBuilder.Entity<Country>()
                .Property(c => c.Name)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Publisher>()
                .Property(p => p.Name)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .HasMaxLength(20)
                .IsRequired();


            modelBuilder.Entity<Book>()
                .Property(b => b.Title)
                .IsRequired();

            modelBuilder.Entity<Book>()
                .HasOne(b => b.NextChapter)
                .WithMany()
                .HasForeignKey(b => b.NextChapterId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherId);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Genre)
                .WithMany(g => g.Books)
                .HasForeignKey(b => b.GenreId);
            
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Clients)
                .WithMany(c => c.Books);


            modelBuilder.Entity<Client>()
                .Property(c => c.FullName)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.Email)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Books)
                .WithMany(b => b.Clients);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.FollowedAuthors)
                .WithMany(a => a.Followers);


            modelBuilder.SeedPublishers();
            modelBuilder.SeedAuthor();
            modelBuilder.SeedGenres();
            modelBuilder.SeedCountries();
            modelBuilder.SeedBooks();
            modelBuilder.SeedClients();



        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}
