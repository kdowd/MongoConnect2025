using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MongoDB.Driver;
using MongoDB.Bson;


using System.Diagnostics;
namespace MongoConnect.Models
{
    public class MongoHelper
    {
        private const string connectionUri = "mongodb+srv://yourHero:Am2eYVCi3inHegGA@bse2024.jon1dt4.mongodb.net/?retryWrites=true&w=majority&appName=BSE2024";
        public List<Student> students { get; private set; } = new List<Student>(); // Initialize the field
        public MongoHelper() { }

        public void Connector_Click()
        {

            var settings = MongoClientSettings.FromConnectionString(connectionUri);
            // use latest stable  API
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);


            // and connect to the Mongo server
            var client = new MongoClient(settings);

            try
            {

                // which DB do we want
                var _database = client.GetDatabase("kdowd");
                // and which collection of documents
                IMongoCollection<Student> collection = _database.GetCollection<Student>("employees");


                // save in Data Collection
                students = collection.AsQueryable().ToList<Student>();


                // Debug - should get a number back
                MessageBox.Show(students.Count.ToString());


            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Problems");
                Debug.WriteLine(ex);
            }

        }
    }
}











