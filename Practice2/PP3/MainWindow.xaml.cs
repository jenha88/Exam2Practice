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

namespace PP3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbBox.Items.Clear();
            for (int i = 1; i <=34 ; i++)
            {
                string url = $"https://rickandmortyapi.com/api/character?page={i}";

                using (var client=new HttpClient())
                {

                    string jsonData = client.GetStringAsync(url).Result;
                    RandM api = JsonConvert.DeserializeObject<RandM>(jsonData);
                    foreach (Character item in api.results)
                    {
                        cbBox.Items.Add(item);
                    }

                }
                
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Character selecteditem = (Character)cbBox.SelectedItem;
            imgBox.Source = new BitmapImage(new Uri(selecteditem.image));
            lbName.Content = selecteditem.name;
        }
    }
}
