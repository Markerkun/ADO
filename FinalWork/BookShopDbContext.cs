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
using FinalWork.Entities;

namespace FinalWork
{
    internal class BookShopDbContext : DbContext
    {

        void FindBookByName(string name)
        {
            var books = this.Set<Book>()
                .Where(b => b.Title.Contains(name))
                .ToList();
            foreach (var book in books)
            {
                book.ToString();
            }
        }
        void FindBooksByAuthor(string authorName)
        {
            var books = this.Set<Book>()
                .Where(b => b.Author.Name.Contains(authorName) || b.Author.Surname.Contains(authorName))
                .ToList();
            foreach (var book in books)
            {
                book.ToString();
            }
        }
        void FindBooksByGenre(string genreName)
        {
            var books = this.Set<Book>()
                .Where(b => b.Genre.Name.Contains(genreName))
                .ToList();
            foreach (var book in books)
            {
                book.ToString();
            }
        }






        public BookShopDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial Catalog = MusicalShop;
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
                .WithMany(c => c.Authors)
                .HasForeignKey(a => a.CountryId);


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




        }
        public DbSet<Author> Authors { get; set; }
    }
}
