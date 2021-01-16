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
    class SuiviBonProdC
    {
        #region Get
        public static List<fsg_gpao.Acteurs.SuiviBonProd> GetAllSuiviBonProd()
        {
            List<SuiviBonProd> list = new List<SuiviBonProd>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idbon, suivi FROM suivibonprod";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new SuiviBonProd
                    {
                        ID = dt.GetInt16(0),
                        IDBON = dt.GetInt16(1),
                        POURCENTAGE = dt.GetString(2)
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
        public static List<SuiviBonProd> GetAllSuiviBonProd(String champ, String texte)
        {
            List<SuiviBonProd> list = new List<SuiviBonProd>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id, idbon, suivi FROM suivibonprod WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new SuiviBonProd
                    {
                        ID = dt.GetInt16(0),
                        IDBON = dt.GetInt16(1),
                        POURCENTAGE = dt.GetString(2)
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
        public static int AjouterSuiviBonProd(SuiviBonProd art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO suivibonprod (idbon, suivi) VALUES (" + art.IDBON + ", '" + art.POURCENTAGE +"'); ";
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
                string req = "SELECT MAX(id) FROM suivibonprod";
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
        public static int GetIdFromIdBon(String idBon)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id FROM suivibonprod WHERE idbon = " + idBon + " " ;
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
        public static int GetSuivi(int idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT suivi FROM suivibonprod WHERE id = " + idd;
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
        #region ModifierSuiviBonProd()
        public static int ModifierSuiviBonProd(SuiviBonProd art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "UPDATE suivibonprod SET idbon =" + art.IDBON + ", suivi='" + art.POURCENTAGE + "' WHERE id=" + art.ID + " ";
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
        public static int ModifierStat(int id, String stat)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "UPDATE suivibonprod SET  suivi='" + stat + "' WHERE id=" + id + " ";
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
        public static int ModifierSuiviBonProd(int id, String pourcentage)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "UPDATE suivibonprod SET  suivi='" + pourcentage + "' WHERE id=" + id + " ";
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
        public static int SupprimerComposition(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM suivibonprod WHERE id=" + idd + " ";
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
