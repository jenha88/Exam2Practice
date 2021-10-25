using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace HW6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Wine> W = new List<Wine>();
        private List<Wine> w;
        public MainWindow()
        {
            InitializeComponent();
            using (var client= new HttpClient())
            {
                string jsonData = client.GetStringAsync("http://pcbstuou.w27.wh-2.com/webservices/3033/api/Wine/Reviews?number=100").Result;
                List<Wine> sake = JsonConvert.DeserializeObject<List<Wine>>(jsonData);

                foreach (var item in sake)
                {
                    W.Add(item);
                }

            }
            PopluateCB(W);
   
            

        }
        private void PopulateLB(List<Wine>bop)
        {
            lstBox.Items.Clear();
            foreach (var item in bop)
            {
                lstBox.Items.Add(item);
            }

        }
        private void PopluateCB(List<Wine> pop)
        {
            cbBox.Items.Add("All");
            cbBox.SelectedIndex = 0;
            
            foreach (var item in pop)
            {
                if (!cbBox.Items.Contains(item.country))
                {
                    cbBox.Items.Add(item.country);
                }
            }


        }
        List<Wine> FilterPrice (List<Wine> fill)
        {
            double p = 0;
            string pp = txtPrice.Text;
            List<Wine> w = new List<Wine>();

            if (double.TryParse(pp, out p) == false)
            {
                MessageBox.Show("This isn't a number! Try again!");
            }
            foreach (var item in fill)
            {
                if (item.price<=p)
                {
                    w.Add(item);
                }
            }
            return w;
        }
       private List<Wine>FilterCB(List<Wine> box)
        {

            string sip = cbBox.SelectedItem.ToString();
            List<Wine> w = new List<Wine>();
            foreach (var item in box)
            {
                if (sip.ToLower()=="all")
                {
                    w.Add(item);
                }
                else if (item.country.Contains(sip))
                {
                    w.Add(item);
                }
            }
            return w;
        }
      
        private void btbPush_Click(object sender, RoutedEventArgs e)
        {
           w= FilterPrice(W);
            w = FilterCB(W);
            PopulateLB(w);


        }

        private void btbExport_Click(object sender, RoutedEventArgs e)
        {
            string jj = JsonConvert.SerializeObject(w, Formatting.Indented);
            File.WriteAllText("wines.json", jj);

            MessageBox.Show("Yay the file successfully exported! O(∩_∩)O");


        }
    }
}
