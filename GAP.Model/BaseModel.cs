using MySql.Data.MySqlClient;
using System.Configuration;

namespace GAP.Model
{
    public class BaseModel
    {
        public MySqlConnection connection;
        public MySqlDataAdapter adapter;
        public MySqlCommand cmd;
        string ConnectionString = ConfigurationManager.ConnectionStrings["ONEGAP"].ToString();

        public BaseModel()
        {
            connection = new MySqlConnection(ConnectionString);
            cmd = new MySqlCommand();
            cmd.Connection = connection;
        }
    }
}