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
            string connectie = string.Concat("Server=sql7.freemysqlhosting.net;Database=sql7338721;Uid=sql7338721;Pwd=PMXUjM37mF;");
            _conn = new MySqlConnection(connectie);
        }

        public DataTable GetCards(string categorie, string kleur)
        {
            _conn.Open();
            MySqlCommand show = _conn.CreateCommand();
            show.CommandText = "SELECT * FROM cards WHERE categorie = '@categorie' AND kleur = '@kleur'";
            show.Parameters.AddWithValue("@kleur", kleur);
            show.Parameters.AddWithValue("@categorie", kleur);
            MySqlDataReader reader = show.ExecuteReader();

            DataTable dvData = new DataTable();
            dvData.Load(reader);
            _conn.Close();
            return dvData;
        }

        public void NewCard(string categorie, string kleur, string text)
        {
            _conn.Open();

            MySqlCommand command = _conn.CreateCommand();
            command.CommandText = "INSERT INTO cards(categorie,kleur,text) VALUES('@categorie','@kleur','@text')";

            command.Parameters.AddWithValue("@categorie", categorie);
            command.Parameters.AddWithValue("@kleur", kleur);
            command.Parameters.AddWithValue("@text", text);

            command.ExecuteNonQuery();

            _conn.Close();
        }
    }
}
