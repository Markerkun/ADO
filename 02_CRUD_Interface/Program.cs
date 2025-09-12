using System.Text;
using System.Xml.Linq;
using System.Xml;


namespace _02_CRUD_Interface
{

    internal class Program
    {
        static void Main(string[] args)
        {

            string connection = @"Data Source = DESKTOP-1LCG8OH\SQLEXPRESS; 
                                        Initial Catalog = Sales;
                                        Integrated Security = true; 
                                        TrustServerCertificate=True;";

            using (SalesDB db = new SalesDB(connection)) { 
            
            }


        }
    }
}