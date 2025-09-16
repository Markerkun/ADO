using Microsoft.Data.SqlClient;
using System.Text;



namespace _01_ConnectedMode
{
    internal class Program
    {


        static void ReadData(SqlCommand command)
        {
            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;

            //// відображається назви всіх колонок таблиці
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($" {reader.GetName(i),14}");
            }
            Console.WriteLine("\n---------------------------------------------------------------------------------------------------------------------");

            //////// відображаємо всі значення кожного рядка
            while (reader.Read())
            {

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($" {reader[i],14} ");
                }
                Console.WriteLine();
            }

            reader.Close();
        }

        static void GetAllClients(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Clients";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            ReadData(command);  
        }

        static void GetAllSellers(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Employee";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            ReadData(command);
        }

        static void GetSellsWithSeller(SqlConnection sqlConnection, string Surname, string FirstName, string SecondName)
        {
            string cmdText = $@"select * from Selles AS S
                        JOIN Employees AS E ON S.EmployeeId = E.id
                        WHERE E.FullName = '{Surname + ' ' + FirstName + ' ' + SecondName}'";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            ReadData(command);
        }

        static void GetSellsMoreThan(SqlConnection sqlConnection, int num)
        {
            string cmdText = $@"select * from Salles
                                WHERE Price > {num}";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            ReadData(command);
        }

        static void GetMostExpensiveAndСheapest(SqlConnection sqlConnection, string Surname, string FirstName, string SecondName)
        {
            string cmdText = $@"select top 1 S.Price from Clients AS C
                        JOIN Salles AS S ON C.id = S.ClientId
                        WHERE C.FullName = '{Surname + ' ' + FirstName + ' ' + SecondName}'
                        ORDER BY S.Price desc";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            ReadData(command);

            cmdText = $@"select top 1 S.Price from Clients AS C
                        JOIN Salles AS S ON C.id = S.ClientId
                        WHERE C.FullName = '{Surname + ' ' + FirstName + ' ' + SecondName}'
                        ORDER BY S.Price asc";


            command = new SqlCommand(cmdText, sqlConnection);
            ReadData(command);
        }

        static void GetFirstSell(SqlConnection sqlConnection, string Surname, string FirstName, string SecondName)
        {
            string cmdText = $@"select top 1 S.SaleDate from Employees AS E
                                JOIN Sales AS S ON E.id = S.EmployeeId
                                WHERE E.FullName = '{Surname + ' ' + FirstName + ' ' + SecondName}'
                                ORDER BY S.SaleDate asc";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            ReadData(command);
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string connectionString = @"Data Source = DESKTOP-0CAJU0C\SQLEXPRESS; 
                                        Initial Catalog = SportShop;
                                        Integrated Security = true; TrustServerCertificate=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //1
            GetAllClients(sqlConnection);

            //2
            GetAllSellers(sqlConnection);

            //3
            Console.WriteLine("Enter Full Name of Seller (Surname FirstName SecondName): ");
            string[] fullName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            GetSellsWithSeller(sqlConnection, fullName[0], fullName[1], fullName[2]);

            //4
            Console.WriteLine("Enter sum of Salles: ");
            int num = int.Parse(Console.ReadLine());
            GetSellsMoreThan(sqlConnection, num);

            //5
            Console.WriteLine("Enter Full Name of Client (Surname FirstName SecondName): ");
            fullName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            GetMostExpensiveAndСheapest(sqlConnection, fullName[0], fullName[1], fullName[2]);

            //6
            Console.WriteLine("Enter Full Name of Seller (Surname FirstName SecondName): ");
            fullName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            GetFirstSell(sqlConnection, fullName[0], fullName[1], fullName[2]);

            sqlConnection.Close();
        }
    }
}