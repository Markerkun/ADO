using Microsoft.Data.SqlClient;
using System.Text;



namespace _01_ConnectedMode
{
    internal class Program
    {


        void ReadData(SqlCommand command)
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

        void GetAllClients(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Clients";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            ReadData(command);  
        }
        
        void GetAllSellers(SqlConnection sqlConnection)
        {
            string cmdText = $@"select * from Employee";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            ReadData(command);
        }
        
        void GetSellsWithSeller(SqlConnection sqlConnection, string Surname, string FirstName, string SecondName)
        {
            string cmdText = $@"select * from Selles AS S
                        JOIN Employees AS E ON S.EmployeeId = E.id
                        WHERE E.FullName = '{Surname + ' ' + FirstName + ' ' + SecondName}'";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            ReadData(command);
        }

        void GetSellsMoreThan(SqlConnection sqlConnection, int num)
        {
            string cmdText = $@"select * from Salles
                                WHERE Price > {num}";


            SqlCommand command = new SqlCommand(cmdText, sqlConnection);
            ReadData(command);
        }



         void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string connectionString = @"Data Source = (localDB)\MSSQLLocalDb; 
                                        Initial Catalog = SportShop;
                                        Integrated Security = true; TrustServerCertificate=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            
            //1
                        //2
            
            //3
            
            //4
            Console.WriteLine("Enter sum of Salles: ");
            int num = int.Parse(Console.ReadLine());
            GetSellsMoreThan(sqlConnection, num);



            //5
            string cmdText5 = $@"select top 1 S.Price from Clients AS C
                        JOIN Salles AS S ON C.id = S.ClientId
                        WHERE C.FullName = 'Романчук Людмила Степанівна'
                        ORDER BY S.Price desc";

            string cmdText6 = $@"select top 1 S.Price from Clients AS C
                        JOIN Salles AS S ON C.id = S.ClientId
                        WHERE C.FullName = 'Романчук Людмила Степанівна'
                        ORDER BY S.Price asc";

            //6
            string cmdText7 = $@"select S.SaleDate from Employees AS E
                        JOIN Sales AS S ON E.id = S.EmployeeId
                        ORDER BY S.SaleDate asc";



            SqlCommand command = new SqlCommand(cmdText1, sqlConnection);

            ReadData(command);




            sqlConnection.Close();

        }
    }
}