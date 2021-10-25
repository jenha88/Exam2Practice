using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace PP5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Game> G = new List<Game>();
        private List<Game> g;
        public MainWindow()
        {
            InitializeComponent();

            var line = File.ReadAllLines("all_games.csv").Skip(1);
            foreach (var item in line)
            {
                G.Add(new Game(item));
            }
            PopulateCB(G);
            PopulateLB(G);
        }
        private void PopulateCB(List<Game> gg)
        {
            cbBox.Items.Add("All");
            cbBox.SelectedIndex = 0;
            foreach (var item in gg)
            {
                if (!cbBox.Items.Contains(item.platform))
                {
                    cbBox.Items.Add(item.platform);
                }
            }

        }
        private void PopulateLB(List<Game> gMs)
        {
            lstbox.Items.Clear();
            foreach (var item in gMs)
            {
                lstbox.Items.Add(item);
            }
        }

        List<Game> FilterGame(List<Game> F)
        {
            string f = cbBox.SelectedValue.ToString();
            List<Game> g = new List<Game>();
            foreach (var item in F)
            {
                if (f.ToLower() == "all")
                {
                    g.Add(item);
                }
                else if (item.platform.Contains(f))
                {
                    g.Add(item);
                }
            }
            return g;
        }

        private void btbExport_Click(object sender, RoutedEventArgs e)
        {
            string jj = JsonConvert.SerializeObject(g, Formatting.Indented);
            File.WriteAllText("games.json", jj);

            MessageBox.Show("You have successfully exported the file! ( •̀ ω •́ )✧");
        }

        private void lstbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game selected = (Game)lstbox.SelectedItem;
            window w = new window();
            w.SetupWindow(selected);
            w.ShowDialog();

        }

        private void cbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            g = FilterGame(G);
            PopulateLB(g);
        }
    }
}
