using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp9
{
    class databasehendler
    {
        public List<sigma> sigmak = new List<sigma>();
        MySqlConnection connection;
        string tablename = "food";

        public databasehendler()
        {
            string dbname = "store";
            string host = "localhost";
            string username = "root";
            string pass = "";
            string connectionstring = $"database ={dbname};user = {username};password = {pass};host = {host}";


            connection = new MySqlConnection(connectionstring);

        }

        public void readdb()
        {
            try
            {
                connection.Open();
                string query = $"select * from {tablename}";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    sigma onesigmas = new sigma();
                    onesigmas.id = read.GetInt32(read.GetOrdinal("id"));
                    onesigmas.name = read.GetString(read.GetOrdinal("name"));
                    onesigmas.price = read.GetInt32(read.GetOrdinal("price"));
                    sigmak.Add(onesigmas);


                }
                read.Close();
                command.Dispose();
                connection.Close();
                MessageBox.Show("sikeres");
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        public void deleteone(sigma sigma) {
            try
            {
                connection.Open();
                string query = $"delete from {tablename} where id = {sigma.id}";
                sigmak.Remove(sigma);
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
        class sigma {
            public int id { get; set; }
            public string name { get; set; }
            public int price { get; set; }
        }
    }

