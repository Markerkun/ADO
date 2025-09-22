using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _02_CRUD_Interface;

namespace _03_SQLInjections
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        SalesDB db;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["SalesDBConnection"].ConnectionString;

            db = new SalesDB(connectionString);

        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.Get_Sales();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.Get_Clients(); 
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.Get_Employees();
        }

    }
}