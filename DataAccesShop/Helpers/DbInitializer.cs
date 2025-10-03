using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FinalWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccesShop.Helpers
{
    internal static class DbInitializer
    {

        public static void SeedPublishers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
            {
                new Publisher { Id = 1, Name = "Scribner" },
                new Publisher { Id = 2, Name = "Penguin Books" },
                new Publisher { Id = 3, Name = "HarperCollins" },
                new Publisher { Id = 4, Name = "Simon & Schuster" },
                new Publisher { Id = 5, Name = "Hachette Book Group" }

         });
        }

        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country { Id = 1, Name = "USA" },
                new Country { Id = 2, Name = "UK" },
                new Country { Id = 3, Name = "Canada" },
                new Country { Id = 4, Name = "Australia" },
                new Country { Id = 5, Name = "Germany" }

            });
        }
        public static void SeedAuthor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author { Id = 1, Name = "Scott", Surname = "Fitzgerald", CountryId = 1 },
                new Author { Id = 2, Name = "George", Surname = "Orwell", CountryId = 2 },
                new Author { Id = 3, Name = "Harper", Surname = "Lee" , CountryId = 3},
                new Author { Id = 4, Name = "J.D.", Surname = "Salinger" , CountryId = 4},
                new Author { Id = 5, Name = "F. Scott", Surname = "Fitzgerald" , CountryId = 5}

         });
        }
        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre { Id = 1, Name = "Fiction" },
                new Genre { Id = 2, Name = "Science Fiction" },
                new Genre { Id = 3, Name = "Fantasy" },
                new Genre { Id = 4, Name = "Mystery" },
                new Genre { Id = 5, Name = "Romance" }
         });
        }

        

        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book { Id = 1, Title = "The Great Gatsby", Year = 1925, Price = 10.99m, AuthorId = 1, GenreId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "1984", Year = 1949, Price = 8.99m, AuthorId = 2, GenreId = 2, PublisherId = 2 },
                new Book { Id = 3, Title = "To Kill a Mockingbird", Year = 1960, Price = 12.99m, AuthorId = 3, GenreId = 1, PublisherId = 3 },
                new Book { Id = 4, Title = "The Catcher in the Rye", Year = 1951, Price = 9.99m, AuthorId = 4, GenreId = 1, PublisherId = 4 },
                new Book { Id = 5, Title = "Brave New World", Year = 1932, Price = 11.99m, AuthorId = 2, GenreId = 2, PublisherId = 5 }

            });
        }

        public static void SeedClients(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(new Client[]
            {
                new Client { Id = 1, FullName = "George Paterson", PhoneNumber = "+12345678901234", Email = "User123@gmail.com" }

            });
        }
    }
}
