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

        public DataTable GetCardNormal(string kleur)
        {
            _conn.Open();
            MySqlCommand show = _conn.CreateCommand();
            show.CommandText = "select * from cards where categorie = 'school' and kleur = '@kleur'";
            show.Parameters.AddWithValue("@kleur", kleur);
            MySqlDataReader reader = show.ExecuteReader();

            DataTable dvData = new DataTable();
            dvData.Load(reader);
            _conn.Close();
            return dvData;
        }

        public DataTable GetCardStage(string kleur)
        {
            _conn.Open();
            MySqlCommand show = _conn.CreateCommand();
            show.CommandText = "select * from cards where categorie = 'stage' and kleur = '@kleur'";
            show.Parameters.AddWithValue("@kleur", kleur);
            MySqlDataReader reader = show.ExecuteReader();

            DataTable dvData = new DataTable();
            dvData.Load(reader);
            _conn.Close();
            return dvData;
        }
    }
}
