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
    class ClasseurDeviC
    {
        #region Get
        public static List<fsg_gpao.Acteurs.ClasseurDevis> GetAllClasseurVente()
        {
            List<ClasseurDevis> list = new List<ClasseurDevis>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idAdmin, idClient, heure, livraison FROM classeurdevis";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new ClasseurDevis
                    {

                        ID = dt.GetInt16(0),
                        IDADMIN = dt.GetInt16(1),
                        IDCLIENT = dt.GetInt16(2),
                        HEURE = dt.GetString(3),
                        LIVRAISON = dt.GetBoolean(4) 
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
        public static List<ClasseurDevis> GetAllClasseurDevis(String champ, String texte)
        {
            List<ClasseurDevis> list = new List<ClasseurDevis>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id, idAdmin, idClient, heure, livraison FROM classeurdevis WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new ClasseurDevis
                    {
                        ID = dt.GetInt16(0),
                        IDADMIN = dt.GetInt16(1),
                        IDCLIENT = dt.GetInt16(2),
                        HEURE = dt.GetString(3),
                        LIVRAISON = dt.GetBoolean(4) 
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
        #region Ajout
        public static int AjouterDevis(ClasseurDevis art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO classeurdevis (id, idAdmin, idClient, heure, livraison) VALUES ("+art.ID+"," + art.IDADMIN + ", " + art.IDCLIENT + ", '" + art.HEURE + "', " + art.LIVRAISON + "); ";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "" + e.ToString());
                return 0;
            }

        }
        public static int GetNexId()
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT MAX(id) FROM classeurdevis";
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
        #endregion
        #region ModifierClasseurDevis()
        public static int ModifierVente(ClasseurDevis art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE classeurdevis SET idAdmin =" + art.IDADMIN + ", idClient=" + art.IDCLIENT + ", heure='" + art.HEURE + "', livraison=" + art.LIVRAISON + " WHERE id=" + art.ID + " ";
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
        public static int Livraison(int id)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE classeurdevis SET livraison=" + true + " WHERE id=" + id + " ";
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
        #region Supprimer
        public static int SupprimerClasseurDevis(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM classeurdevis WHERE id=" + idd + " ";
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
    }
}

