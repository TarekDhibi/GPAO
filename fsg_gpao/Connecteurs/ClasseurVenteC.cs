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
    class ClasseurVenteC
    {
        #region Get
        public static List<fsg_gpao.Acteurs.ClasseurVente> GetAllClasseurVente()
        {
            List<ClasseurVente> list = new List<ClasseurVente>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idAdmin, idClient, heure FROM classeurVente";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new ClasseurVente
                    {

                        ID = dt.GetInt16(0),
                        IDADMIN = dt.GetInt16(1),
                        IDCLIENT = dt.GetInt16(2),
                        HEURE = dt.GetString(3)
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
        public static List<ClasseurVente> GetAllClasseurVente(String champ, String texte)
        {
            List<ClasseurVente> list = new List<ClasseurVente>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id, idAdmin, idClient, heure FROM classeurVente WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new ClasseurVente
                    {
                        ID = dt.GetInt16(0),
                        IDADMIN = dt.GetInt16(1),
                        IDCLIENT = dt.GetInt16(2),
                        HEURE = dt.GetString(3)
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
        public static int AjouterVente(ClasseurVente art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO classeurVente (id, idAdmin, idClient, heure) VALUES ("+art.ID+"," + art.IDADMIN + ", " + art.IDCLIENT + ", '" + art.HEURE + "'); ";
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
                string req = "SELECT MAX(id) FROM classeurVente";
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
        #region ModifierClasseurVente()
        public static int ModifierVente(ClasseurVente art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE classeurVente SET idAdmin =" + art.IDADMIN + ", idClient=" + art.IDCLIENT + ", heure='" + art.HEURE + "' WHERE id=" + art.ID + " ";
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
        public static int SupprimerClasseurVente(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM classeurVente WHERE id=" + idd + " ";
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
