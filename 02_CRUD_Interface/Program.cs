using Microsoft.Data.SqlClient;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace _02_CRUD_Interface
{

    class SalesDB: IDisposable
    {
        private SqlConnection connection;

        public SalesDB(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        public void Create_As_Insert(Sale sale)
        {
            string cmdText = $@"INSERT INTO Products
                              VALUES ('{sale.ProductId}', 
                                      '{sale.Price}',
                                       {sale.Quantity}, 
                                       {sale.EmployeeId}, 
                                      '{sale.ClientId}', 
                                       {sale.SaleDate})";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.CommandTimeout = 5;

            int rows = command.ExecuteNonQuery();
            Console.WriteLine(rows + " rows affected!");
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            string connection = @"Data Source = DESKTOP-1LCG8OH\SQLEXPRESS; 
                                        Initial Catalog = Sales;
                                        Integrated Security = true; 
                                        TrustServerCertificate=True;";


        }
    }
}