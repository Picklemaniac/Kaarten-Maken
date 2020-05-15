using System;
using System.Collections.Generic;
using System.Data;
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
        DBCards database = new DBCards();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Kaarten_Click(object sender, RoutedEventArgs e)
        {
            DataView cardlist = database.GetCards(Categorie.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "").ToLower(), ((Button)sender).Tag.ToString());

            Kaarten.SelectedValuePath = "text";
            Kaarten.DisplayMemberPath = "text";
            Kaarten.ItemsSource = cardlist;
        }
    }
}
