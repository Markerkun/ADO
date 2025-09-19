using System.Text;
using System.Xml.Linq;
using System.Xml;
using DataAcces.Models;
using DataAcces;
using System.Configuration;

    
namespace _02_CRUD_Interface
{

    internal class Program
    {
        static void Main(string[] args)
        {

            string connection = @"Data Source = (localDB)\MSSQLLocalDb; 
                                        Initial Catalog = Sales;
                                        Integrated Security = true; 
                                        TrustServerCertificate=True;";

            using (SalesDB db = new SalesDB(connection)) {

                db.CreateAsInsert(new Sale()
                {
                    ProductId = 2,
                    Price = 200,
                    Quantity = 2,
                    EmployeeId = 1,
                    ClientId = 1,
                    SaleDate =new DateTime(2000,5,7)
                });

                Console.WriteLine("-------------------");

                string date = "2024-06-10";

                List<Sale> sales = db.Read_Get_AllSallesForDate(date);
                foreach (var sale in sales)
                {
                    Console.WriteLine(sale);
                }

                Console.WriteLine("-------------------");

                List<Clients> clients = db.Get_ClientSaleByName("Ярощук Іван Петрович");
                foreach (var client in clients)
                {
                    Console.WriteLine(client);
                }

                Console.WriteLine("-------------------");

                List<Employees> employees = db.Get_Employees();
                db.DeleteEmployee(3);

                Console.WriteLine("-------------------");

                clients = db.Get_Clients();
                db.DeleteClient(2);

                Console.WriteLine("-------------------");

                db.GetBestEmployee().ToString();


            }


        }
    }
}