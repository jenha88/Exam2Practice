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

namespace PP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var client = new HttpClient())
            {
                string jsonData = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon").Result;
                List<string> Pokemon = JsonConvert.DeserializeObject<List<string>>(jsonData);

                foreach (var item in Pokemon)
                {
                    lstbox.Items.Add(item);
                }
            }


        }

        private void lstbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pokemon selecteditem = (Pokemon)lstbox.SelectedItem;
            using (var client = new HttpClient())
            {
                string jsonDate=client
            }
        } 
    }

}
