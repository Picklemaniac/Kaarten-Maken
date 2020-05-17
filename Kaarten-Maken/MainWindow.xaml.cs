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
        string kleur;
        string categorie;

        DBCards database = new DBCards();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Getcards()
        {
            DataView cardlist = database.GetCards(categorie, kleur);
            Kaarten.SelectedValuePath = "text";
            Kaarten.DisplayMemberPath = "text";
            Kaarten.ItemsSource = cardlist;
        }

        private void Kaarten_Click(object sender, RoutedEventArgs e)
        {
            categorie = Categorie.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "").ToLower();
            kleur = ((Button)sender).Tag.ToString();
            Getcards();
        }

        private void Add_Card_Click(object sender, RoutedEventArgs e)
        {
            categorie = Categorie.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "").ToLower();

            if (kleur == null || Card_Content.Text == "")
            {
                MessageBox.Show("Selecteer eerst een kleur en voeg text in.");
            }
            else
            {
                database.NewCard(categorie, kleur, Card_Content.Text);
            }   

            Getcards();
        }

        private void Kaarten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dr = (DataRowView)Kaarten.SelectedItem;
            if (dr != null)
            {
                Card_Content.Text = dr["text"].ToString();
            }
        }

        private void Delete_Card_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dr = (DataRowView)Kaarten.SelectedItem;
            if (dr != null)
            {
                MessageBoxResult r = MessageBox.Show("Weet u zeker dat u de kaart  '" + Card_Content.Text + "' wilt verwijderen?",
            "Verwijderen",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

                if (r == MessageBoxResult.Yes)
                {
                    database.DeleteCard(Card_Content.Text);
                    Getcards();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Selecteer alstublieft eerst een kaart");
            }

        }

        private void Edit_Card_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dr = (DataRowView)Kaarten.SelectedItem;
            if (dr != null && Card_Content.Text != "")
            {
                MessageBoxResult r = MessageBox.Show("Weet u zeker dat u de kaart  '" + dr["text"].ToString() + "' wilt aanpassen?",
            "Verwijderen",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

                if (r == MessageBoxResult.Yes)
                {
                    database.UpdateCard(dr["text"].ToString(), Card_Content.Text);
                    Getcards();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("Selecteer alstublieft eerst een kaart en vul de nieuwe tekst in");
            }
        }
    }
}
