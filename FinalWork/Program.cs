// See https://aka.ms/new-console-template for more information
using DataAccesShop;
using DataAccesShop.Entities;
using Microsoft.EntityFrameworkCore;


BookShopDbContext NBS = new BookShopDbContext();



Console.WriteLine("Good day :) \n0.Hello");
int choice = int.Parse(Console.ReadLine());
do
{
    Console.WriteLine("\n1.EXIT\n2.Add book\n3.Delete book\n4.Update book\n5.Show all books\n6.Set discount\n7.Aside book for a buyer\n8.Find book by title\n9.Find book by author\n10.Find book by gener\n11.Show new books\n12.Show popular books");
    choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Console.WriteLine("Exiting...");
            break;
        case 2:
            Console.WriteLine("Enter title, authorId, publisherId, pages, genreId, year, price, priceForSale");
            string title = Console.ReadLine();
            int authorId = int.Parse(Console.ReadLine());
            int publisherId = int.Parse(Console.ReadLine());
            int pages = int.Parse(Console.ReadLine());
            int genreId = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            decimal price = decimal.Parse(Console.ReadLine());
            decimal priceForSale = decimal.Parse(Console.ReadLine());
            Book book = NBS.CreateBook(title, authorId, publisherId, pages, genreId, year, price, priceForSale);
            NBS.AddBook(book);
            NBS.SaveChanges();
            break;
        case 3:
            Console.WriteLine("Enter book id to delete");
            int idToDelete = int.Parse(Console.ReadLine());
            NBS.DeleteBook(idToDelete);
            NBS.SaveChanges();
            break;
        case 4:
            Console.WriteLine("Enter id, title, authorId, publisherId, pages, genreId, year, price, priceForSale to update");
            int idToUpdate = int.Parse(Console.ReadLine());
            string newTitle = Console.ReadLine();
            int newAuthorId = int.Parse(Console.ReadLine());
            int newPublisherId = int.Parse(Console.ReadLine());
            int newPages = int.Parse(Console.ReadLine());
            int newGenreId = int.Parse(Console.ReadLine());
            int newYear = int.Parse(Console.ReadLine());
            decimal newPrice = decimal.Parse(Console.ReadLine());
            decimal newPriceForSale = decimal.Parse(Console.ReadLine());
            NBS.UpdateBook(idToUpdate, newTitle, newAuthorId, newPublisherId, newPages, newGenreId, newYear, newPrice, newPriceForSale);
            NBS.SaveChanges();
            break;
        case 5:
            NBS.ShowAllBooks();
            break;
        case 6:
            Console.WriteLine("Enter book id and discount percentage");
            int idForDiscount = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());
            NBS.SetDiscount(idForDiscount, discount);
            NBS.SaveChanges();
            break;
        case 7:
            Console.WriteLine("Enter book id, client name, client surname");
            int bookId = int.Parse(Console.ReadLine());
            string clientName = Console.ReadLine();
            string clientSurname = Console.ReadLine();
            Client client = new Client { FullName = clientName + ' ' + clientSurname };
            NBS.AsideForBuyer(bookId, client);
            NBS.SaveChanges();
            break;
        case 8:
            Console.WriteLine(
                "Enter title to find book");
            string titleToFind = Console.ReadLine();
            NBS.FindBooksByTitle(titleToFind);
            break;
        case 9:
            Console.WriteLine("Enter author name to find book");
            string authorToFind = Console.ReadLine();
            NBS.FindBooksByAuthor(authorToFind);
            break;
        case 10:
            Console.WriteLine("Enter genre name to find book");
            string genreToFind = Console.ReadLine();
            NBS.FindBooksByGenre(genreToFind);
            break;
        case 11:
            var booksNew = NBS.ShowNewBooks(); 
            if (booksNew == null)
            {
                Console.WriteLine("No new books found.");
                break;
            }
            foreach (var b in booksNew)
            {
                Console.WriteLine(b);
            }
            break;
        case 12:
            var booksPopular = NBS.ShowPopularBooks();
            foreach (var b in booksPopular)
            {
                Console.WriteLine(b);
            }
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

} while (choice != 1);
	