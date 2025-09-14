using Microsoft.Data.SqlClient;

namespace _02_CRUD_Interface
{
    public class SalesDB : IDisposable
    {
        private SqlConnection connection;

        public SalesDB(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
        }
        public void CreateAsInsert(Sale sale)
        {
            string cmdText = $@"INSERT INTO Salles
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
            connection.Close();
        }
        private List<Sale> GetProductsByQuery(SqlDataReader reader)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            List<Sale> products = new List<Sale>();
            while (reader.Read())
            {
                products.Add(
                    new Sale()
                    {
                        Id = (int)reader[0],
                        ProductId = (int)reader[0],
                        Price = (string)reader[1],
                        EmployeeId = (int)reader[2],
                        Quantity = (int)reader[3],
                        ClientId = (int)reader[4],
                        SaleDate = (string)reader[5]
                    });
            }
            reader.Close();
            return products;
        }

        public List<Sale> Read_Get_All()
        {
            string cmdText = $@"select * from Products";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return GetProductsByQuery(reader);
        }
    }
}