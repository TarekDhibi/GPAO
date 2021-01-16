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
    class ClasseurProduitC
    {
        #region Get
        public static List<fsg_gpao.Acteurs.ClasseurProduit> GetAllClasseurAchat()
        {
            List<ClasseurProduit> list = new List<ClasseurProduit>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idFactureProduction, idProduit, nbEx FROM classeurproduit";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new ClasseurProduit
                    {
                        ID = dt.GetInt16(0),
                        IDFACTUREPRODUCTION = dt.GetInt16(1),
                        IDPRODUIT = dt.GetInt16(2),
                        NBEX = dt.GetInt16(3)
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
        public static List<ClasseurProduit> GetAllClasseur(String champ, String texte)
        {
            List<ClasseurProduit> list = new List<ClasseurProduit>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id, idFactureProduction, idProduit, nbEx FROM classeurproduit WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new ClasseurProduit
                    {
                        ID = dt.GetInt16(0),
                        IDFACTUREPRODUCTION = dt.GetInt16(1),
                        IDPRODUIT = dt.GetInt16(2),
                        NBEX = dt.GetInt16(3)
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
        public static int AjouterComposition(ClasseurProduit art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO classeurproduit (id, idFactureProduction, idProduit, nbEx) VALUES (" + art.ID + "," + art.IDFACTUREPRODUCTION + ", " + art.IDPRODUIT + ", " + art.NBEX + "); ";
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
                string req = "SELECT MAX(id) FROM classeurproduit";
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
        #region ModifierComposition()
        public static int ModifierVente(ClasseurProduit art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "UPDATE classeurproduit SET idFactureProduction =" + art.IDFACTUREPRODUCTION + ", idProduit=" + art.IDPRODUIT + ", nbEx='" + art.NBEX + "' WHERE id=" + art.ID + " ";
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

                string req = "DELETE FROM classeurproduit WHERE id=" + idd + " ";
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
