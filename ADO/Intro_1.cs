using Microsoft.Data.SqlClient;
using System.Text;



namespace _01_ConnectedMode
{
    internal class Program
    {


        static void ReadData(SqlCommand command)
        {
            Console.OutputEncoding = Encoding.UTF8;
            SqlDataReader reader = command.ExecuteReader();
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




        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string connectionString = @"Data Source = (localDB)\MSSQLLocalDb; 
                                        Initial Catalog = SportShop;
                                        Integrated Security = true; TrustServerCertificate=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            
            //1
            string cmdText1 = $@"select * from Clients";
            //2
            string cmdText2 = $@"select * from Employees";
            //3
            string cmdText3 = $@"select * from Salles AS S
                        JOIN Employees AS E ON S.EmployeeId = E.id
                        WHERE E.FullName = 'Михальчук Руслана Романівна'";
            //4
            Console.WriteLine("Enter sum of Salles: ");
            int sum = int.Parse(Console.ReadLine());

            string cmdText4 = $@"select * from Salles
                         WHERE Price > {sum}";
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