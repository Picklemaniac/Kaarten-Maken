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

namespace Kaarten_Maken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Rode_Kaarten_Click(object sender, RoutedEventArgs e)
        {
            Get_Cards(Categorie.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "").ToLower(), "rood");
        }

        private void Gele_Kaarten_Click(object sender, RoutedEventArgs e)
        {
            Get_Cards(Categorie.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""), "geel");
        }

        private void Blauwe_Kaarten_Click(object sender, RoutedEventArgs e)
        {
            Get_Cards(Categorie.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""), "blauw");
        }
    }
}
