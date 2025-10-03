// See https://aka.ms/new-console-template for more information
using FinalWork;
using FinalWork.Entities;
using Microsoft.EntityFrameworkCore;


BookShopDbContext NewBookStore = new BookShopDbContext();


NewBookStore.SaveChanges();
foreach (var item in NewBookStore.Books)
{
    Console.WriteLine(item);
}

NewBookStore.ShowAllBooks();
Console.WriteLine();
var books = NewBookStore.Books.Include(b => b.Author).Include(b=>b.Genre).ToList(); 
foreach (var book in books)
{
    Console.WriteLine(book);
}

//NewBookStore.AddBook(new Book
//{
//    Title = "The Great Gatsb",
//    Author = new Author { Name = "Scott", Surname = "Fitzgerald" },
//    Publisher = new Publisher { Name = "Scribner" },
//    Pages = 180,
//    Genre = new Genre { Name = "Fiction" },
//    Year = 1925,
//    Price = 10.99m,
//    PriceForSale = 8.99m
//});

//NewBookStore.FindBookByName("The Great Gatsb");

//NewBookStore.UpdateBook(1, price: 9.99m, priceForSale: 7.99m);

//NewBookStore.FindBookByName("The Great Gatsb");

//NewBookStore.DeleteBook(1);



