using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace PP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            
            InitializeComponent();
            cbBox.Items.Add("All");
            cbBox.SelectedIndex = 0;
            using (var client= new HttpClient())
            {
                string jsonData = client.GetStringAsync("https://api.chucknorris.io/jokes/categories").Result;
                List<string> Joke = JsonConvert.DeserializeObject<List<string>>(jsonData);

                foreach (var item in Joke)
                {
                    cbBox.Items.Add(item);
                }

            }

        }

        private void btb_Click(object sender, RoutedEventArgs e)
        {
            string s = cbBox.SelectedItem.ToString();

            if (s=="all")
            {
                using(var client= new HttpClient())
                {
                    string jsonData = client.GetStringAsync("https://api.chucknorris.io/jokes/random?category="+ s).Result;
                    Joke api = JsonConvert.DeserializeObject<Joke>(jsonData);

                    txtbox.Text = api.value;
                }
       

            }
            else
            {
                using(var client= new HttpClient())
                {
                    string jsonData = client.GetStringAsync("https://api.chucknorris.io/jokes/random?" + s).Result;
                    Joke api = JsonConvert.DeserializeObject<Joke>(jsonData);

                    txtbox.Text = api.value;
                }
                 
            }
        }

       
    }
}
