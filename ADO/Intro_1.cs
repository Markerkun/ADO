using Microsoft.Data.SqlClient;
using System.Text;



namespace _01_ConnectedMode
{
    internal class Program
    {


        static void Main(string[] args)
        {

            string connectionString = @"Data Source = (localDB)\MSSQLLocalDb; 
                                        Initial Catalog = SportShop;
                                        Integrated Security = true; TrustServerCertificate=True";

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //1
            string cmdText = $@"select * from Clients";

            SqlCommand command = new SqlCommand(cmdText, sqlConnection);

            //2
            cmdText = $@"select * from Employees";
            command = new SqlCommand(cmdText, sqlConnection);

            //3
            cmdText = $@"select * from Salles AS S
                        JOIN Employees AS E ON S.EmployeeId = E.id
                        WHERE E.FullName = 'Михальчук Руслана Романівна'";
            command = new SqlCommand(cmdText, sqlConnection);

            //4
            Console.WriteLine("Enter sum of Salles: ");
            int sum = int.Parse(Console.ReadLine());

            cmdText = $@"select * from Salles
                         WHERE Price > {sum}";
            command = new SqlCommand(cmdText, sqlConnection);

            //5
            cmdText = $@"select top 1 S.Price from Clients AS C
                        JOIN Salles AS S ON C.id = S.ClientId
                        WHERE C.FullName = 'Романчук Людмила Степанівна'
                        ORDER BY S.Price desc";
            command = new SqlCommand(cmdText, sqlConnection);

            cmdText = $@"select top 1 S.Price from Clients AS C
                        JOIN Salles AS S ON C.id = S.ClientId
                        WHERE C.FullName = 'Романчук Людмила Степанівна'
                        ORDER BY S.Price asc";
            command = new SqlCommand(cmdText, sqlConnection);

            //6
            cmdText = $@"select S.SaleDate from Employees AS E
                        JOIN Sales AS S ON E.id = S.EmployeeId
                        ORDER BY S.SaleDate asc";
            command = new SqlCommand(cmdText, sqlConnection);




        }
    }
}