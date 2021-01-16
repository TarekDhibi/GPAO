using fsg_gpao.Acteurs;
using fsg_gpao.Connexion_bd;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace fsg_gpao.Connecteurs
{
    class ClientC
    {
        public static int NomExiste(string nom)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT id FROM client WHERE nom = '" + nom + "' ; ";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    id = dt.GetInt16(0);
                }
                con.CloseConnection();
                return id;
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message);
                return -1;
            }
        }

        public static int IdExisteJournal(int idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = " SELECT id FROM journalClient WHERE idClient= " + idd + " ";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {

                    id = dt.GetInt16(0);
                }
                con.CloseConnection();
                return id;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return -1;
            }
        }

        #region GetAllClient()
        public static List<fsg_gpao.Acteurs.Client> GetAllClient()
        {
            List<Client> list = new List<Client>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, adresse, tel, remarque, etat FROM client";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Client
                    {

                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        ADRESSE = dt.GetString(2),
                        TEL = dt.GetString(3),
                        Remarque = dt.GetString(4),
                        ETAT = dt.GetBoolean(5)
                    });
                }
                con.CloseConnection();
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public static List<Client> GetAllClient(String champ, String texte)
        {
            List<Client> list = new List<Client>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id, nom, adresse, tel, remarque, etat FROM client WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Client
                    {
                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        ADRESSE = dt.GetString(2),
                        TEL = dt.GetString(3),
                        Remarque = dt.GetString(4),
                        ETAT = dt.GetBoolean(5)
                    });
                }
                con.CloseConnection();
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static fsg_gpao.Acteurs.Client GetClient(int id)
        {
            Client V = new Client();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, adresse, tel, remarque, etat FROM client WHERE id =" + id;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    V.ID = dt.GetInt16(0);
                    V.NOM = dt.GetString(1);
                    V.ADRESSE = dt.GetString(2);
                    V.TEL = dt.GetString(3);
                    V.Remarque = dt.GetString(4);
                    V.ETAT = dt.GetBoolean(5);
                }
                con.CloseConnection();
                return V;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        #endregion


        #region AjouterClient()
        public static int AjouterClient(Client art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO client(nom, adresse, tel, remarque, etat) VALUES ('" + art.NOM + "','" + art.ADRESSE + "','" + art.TEL + "', '" + art.Remarque + "'," + art.ETAT + ")";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }

        }
        #endregion
        #region ModifierClient()
        public static int ModifierClient(Client art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE  client SET nom ='" + art.NOM + "', adresse='" + art.ADRESSE + "', tel='" + art.TEL + "', remarque='" + art.Remarque + "', etat=" + art.ETAT + " WHERE id=" + art.ID + " ";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }

        }
        #endregion
        #region SupprimerClient()
        public static int SupprimerClient(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM client WHERE id=" + idd + " ";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return 0;
            }

        }
        #endregion


        #region GetAllClientLikeColonne()
        public static List<Client> GetAllClientLikeColonne(String colonne, string rech)
        {
            List<Client> list = new List<Client>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, adresse, tel, remarque, etat FROM client WHERE " + colonne + " LIKE '%" + rech + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Client
                    {
                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        ADRESSE = dt.GetString(2),
                        TEL = dt.GetString(3),
                        Remarque = dt.GetString(4),
                        ETAT = dt.GetBoolean(5)
                    });
                }
                con.CloseConnection();
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }

        }
        #endregion

    }
}
