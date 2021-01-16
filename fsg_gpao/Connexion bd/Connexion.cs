using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;


namespace fsg_gpao.Connexion_bd
{
    class Connexion
    {
        public MySqlConnection connexion;
        private String server;
        private String database;
        private String user;
        private String password;

        public Connexion()
        {
            server = "localhost";
            database = "gpao";
            user = "root";
            password = "";

            string link = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "USER=" + user + ";" + "PASSWORD=" + password + ";";
            connexion = new MySqlConnection(link);
        }

        #region connexionbd()
     

        #endregion

        #region OpenConnection()
        public bool OpenConnection()
        {
            try { 
            connexion.Open();
            return true;
            }
            catch(Exception e)
            {
               // MessageBox.Show(e.Message);
                return false;
            }

        }
        #endregion

        #region CloseConnection()
        public bool CloseConnection()
        {
            connexion.Close();
            return true;
        }
        #endregion

    }
}
