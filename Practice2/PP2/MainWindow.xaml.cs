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
                string jsonData = client.GetStringAsync("https://pokeapi.co/api/v2/pokemon?offset=0&limit=1118").Result;
                list call = JsonConvert.DeserializeObject<list>(jsonData);

                foreach (var item in call.results)
                {
                    lstbox.Items.Add(item);
                }
            }


        }
        
        private void btbFront_Click(object sender, RoutedEventArgs e)
        {
            detail P = (detail)lstbox.SelectedItem;

            using (var client= new HttpClient())
            {
                string JJ = client.GetStringAsync(P.url).Result;
                Pokemon PP = JsonConvert.DeserializeObject<Pokemon>(JJ);
                image.Source = new BitmapImage(new Uri(PP.sprites.front_default));


            }


        }
        private void btbBack_Click(object sender, RoutedEventArgs e)
        {
            detail P = (detail)lstbox.SelectedItem;
            using (var client= new HttpClient())
            {
                string bb = client.GetStringAsync(P.url).Result;
                Pokemon PP = JsonConvert.DeserializeObject<Pokemon>(bb);
                image.Source = new BitmapImage(new Uri(PP.sprites.back_default));
            }
        }
        //what happens when the user select a pokemon in the listbox 
        private void lstbox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            detail P = (detail)lstbox.SelectedItem;
            using (var client = new HttpClient())
            {

                string JsonData = client.GetStringAsync(P.url).Result; //getting the url info from the class 
                Pokemon PP = JsonConvert.DeserializeObject<Pokemon>(JsonData);
                image.Source = new BitmapImage(new Uri(PP.sprites.front_default)); //pulls up the image from the class 
                txtheight.Text = PP.height;
                txtweight.Text = PP.weight;


            }
        }

        
    }

}
