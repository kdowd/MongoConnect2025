using System.Diagnostics;
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
using MongoConnect.Models;
using MongoConnect;

namespace MongoConnect
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // whoa!  
            Environment.SetEnvironmentVariable("NAME", "dave");
            EnvReader.Load("D:\\Users\\091275\\source\\repos\\MongoConnect\\.env");

            // Access the environment variables  
            string? apiKey = Environment.GetEnvironmentVariable("API_KEY");
            string? databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            string? debug = Environment.GetEnvironmentVariable("DEBUG");

            // Output the values  
            Console.WriteLine($"API Key: {apiKey ?? "Not Set"}");
            Console.WriteLine($"Database URL: {databaseUrl ?? "Not Set"}");
            Console.WriteLine($"Debug Mode: {debug ?? "Not Set"}");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MongoHelper mongoHelper = new MongoHelper();
            mongoHelper.Connector_Click();
            MyDG.ItemsSource = mongoHelper.students;


            // for debug only
            //List<Student> temp = mongoHelper.students;
            //temp.ForEach(PrintStudents);

        }

        private void PrintStudents(Student s)
        {
            Debug.WriteLine(s.FirstName);
            Debug.WriteLine(s.LastName);
            Debug.WriteLine(s.Email);

        }


    }
}
