using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
    }
}
