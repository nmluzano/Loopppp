using Newtonsoft.Json;
using RestSharp;
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

namespace ForeachLoop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowTodo();
        }
        private void ShowTodo()
        {
            var Client = new RestClient("http://techslides.com/demos/country-capitals.json");

            var request = new RestRequest("", Method.GET);

            IRestResponse response = Client.Execute(request);

            var content = response.Content;

            var data = JsonConvert.DeserializeObject<Country>(content);

            List<string> countries = new List<string>() { "," };
            List<string> names = new List<string>();

            int ctr = 1;
            foreach (string country in countries)
            {
                names.Add(ctr + " " + country);
                ctr = ctr + 1;
            }
            lstCountry.ItemsSource = names;
        }

        private class Country
        {
        }
    }
}
