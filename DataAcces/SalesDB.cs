using DataAcces.Models;
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
                              VALUES ({sale.ProductId}, 
                                      {sale.Price},
                                       {sale.Quantity}, 
                                       {sale.EmployeeId}, 
                                      {sale.ClientId}, 
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
        private List<Sale> GetSallesByQuery(SqlDataReader reader)
        {
            List<Sale> salles = new List<Sale>();
            while (reader.Read())
            {
                salles.Add(
                    new Sale()
                    {
                        Id = (int)reader[0],
                        ProductId = (int)reader[1],
                        Price = (int)reader[2],
                        EmployeeId = (int)reader[3],
                        Quantity = (int)reader[4],
                        ClientId = (int)reader[5],
                        SaleDate = (DateTime)reader[6]
                    });
            }
            reader.Close();
            return salles;
        }
        
        private List<Employees> GetEmployeesByQuery(SqlDataReader reader)
        {
            List<Employees> employees = new List<Employees>();
            while (reader.Read())
            {
                employees.Add(
                    new Employees()
                    {
                        Id = (int)reader[0],
                        FullName = (string)reader[1],
                        HireDate = (string)reader[2],
                        Gender = (string)reader[3],
                        Salary = (int)reader[4]
                    });
            }
            reader.Close();
            return employees;
        }
        private List<Clients> GetClientsByQuery(SqlDataReader reader)
        {
            List<Clients> clients = new List<Clients>();
            while (reader.Read())
            {
                clients.Add(
                    new Clients()
                    {
                        Id = (int)reader[0],
                        FullName = (string)reader[1],
                        Email = (string)reader[2],
                        Phone = (string)reader[3],
                        PercentSale = (int)reader[4],
                        Gender = (string)reader[5],
                        Subscribe = (byte)reader[6]
                    });
            }
            reader.Close();
            return clients;
        }

        public List<Sale> Read_Get_AllSallesForDate(string Date)
        {
            string cmdText = $@"select * from Salles
                                WHERE Salles.SaleDate between('{Date}' AND GETDATE())";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return GetSallesByQuery(reader);
        }

        public List<Employees> Get_Employees()
        {
            string cmdText = $@"select * from Employees";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return GetEmployeesByQuery(reader);
        }
        public List<Clients> Get_Clients()
        {
            string cmdText = $@"select * from Clients";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return GetClientsByQuery(reader);
        }

        public List<Clients> Get_ClientSaleByName(string Fullname)
        {
            string cmdText = $@"select TOP 1 * from Clients AS C
                                JOIN Salles AS S ON C.Id = S.ClientId
                                WHERE C.FullName = @name
                                ORDER BY S.SaleDate DESC";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlParameter parameter = new SqlParameter
            {
                ParameterName = "name",
                SqlDbType = System.Data.SqlDbType.NVarChar,
                Value = Fullname
            };
            command.Parameters.Add(parameter);

            SqlDataReader reader = command.ExecuteReader();
            return GetClientsByQuery(reader);
        }

        public void DeleteEmployee(int id)
        {
            string cmdText = $@"delete Employees where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }
        public void DeleteClient(int id)
        {
            string cmdText = $@"delete Clients where Id = {id}";

            SqlCommand command = new SqlCommand(cmdText, connection);
            command.ExecuteNonQuery();
        }

        public Employees GetBestEmployee()
        {
            string cmdText = $@"select E.FullName, SUM(S.Prise) AS 'Sum of sales'from Employees AS E
                                JOIN Salles AS S ON S.EmployeeId = E.Id
                                GROUP BY S.EmployeeId";
            SqlCommand command = new SqlCommand(cmdText, connection);
            SqlDataReader reader = command.ExecuteReader();
            return GetEmployeesByQuery(reader).FirstOrDefault()!;
        }

    }
}