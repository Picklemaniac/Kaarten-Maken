using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaarten_Maken
{
    class DBCards
    {
        MySqlConnection _conn;
        public DBCards()
        {
            string connectie = "Server=localhost;Database=Cards;Uid=root;Pwd=;";
            _conn = new MySqlConnection(connectie);
        }

        public DataView GetCards(string categorie, string kleur)
        {
            _conn.Open();

            MySqlCommand command = _conn.CreateCommand();

            command.CommandText = "SELECT * FROM cards WHERE Categorie = @categorie AND Kleur = @kleur;";
            command.Parameters.AddWithValue("@kleur", kleur);
            command.Parameters.AddWithValue("@categorie", categorie);

            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine(reader.ToString());
            DataTable firstdatatable = new DataTable();
            firstdatatable.Load(reader);

            _conn.Close();

            return firstdatatable.DefaultView;
        }

        public void NewCard(string categorie, string kleur, string text)
        {
            _conn.Open();

            MySqlCommand command = _conn.CreateCommand();
            command.CommandText = "INSERT INTO cards(categorie,kleur,text) VALUES(@categorie,@kleur,@text)";

            command.Parameters.AddWithValue("@categorie", categorie);
            command.Parameters.AddWithValue("@kleur", kleur);
            command.Parameters.AddWithValue("@text", text);

            command.ExecuteNonQuery();

            _conn.Close();
        }

        public void UpdateCard(int id, string text)
        {
            _conn.Open();

            MySqlCommand command = _conn.CreateCommand();
            command.CommandText = "UPDATE cards set text = @text where id = @id";

            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@text", text);

            command.ExecuteNonQuery();

            _conn.Close();
        }

        public void DeleteCard(string text)
        {
            _conn.Open();

            MySqlCommand command = _conn.CreateCommand();
            command.CommandText = "DELETE FROM CARDS WHERE text = @text;";

            command.Parameters.AddWithValue("@text", text);

            command.ExecuteNonQuery();

            _conn.Close();
        }
    }
}
