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
    class AchatC
    {
        #region Get
        public static List<fsg_gpao.Acteurs.Achat> GetAllAchat(int idClasseur)
        {
            List<Achat> list = new List<Achat>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idProduit, nbex, prix, remise FROM achat WHERE idClasseur = " + idClasseur;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Achat
                    {

                        ID = dt.GetInt16(0),
                        IDPRODUIT = dt.GetInt16(1),
                        NBEX = dt.GetInt16(2),
                        PRIX = dt.GetInt16(3),
                        REMISE = dt.GetInt16(4)
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
        public static List<Achat> GetAllAchat(int idClasseur, String champ, String texte)
        {
            List<Achat> list = new List<Achat>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id, idProduit, nbex, prix, remise FROM achat WHERE (" + champ + " like '%" + texte + "%' AND idClasseur = " + idClasseur + ")";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Achat
                    {

                        ID = dt.GetInt16(0),
                        IDPRODUIT = dt.GetInt16(1),
                        NBEX = dt.GetInt16(2),
                        PRIX = dt.GetInt16(3),
                        REMISE = dt.GetInt16(4)
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
        public static fsg_gpao.Acteurs.Achat GetAchat(int id)
        {
            Achat V = new Achat();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idProduit, nbex, prix, remise FROM achat WHERE id =" + id;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    V.ID = dt.GetInt16(0);
                    V.IDPRODUIT = dt.GetInt16(1);
                    V.NBEX = dt.GetInt16(2);
                    V.PRIX = dt.GetInt16(3);
                    V.REMISE = dt.GetInt16(4);
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


        #region Ajout
        public static int AjouterAchat(Achat art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO achat (idClasseur, idProduit, nbex, prix, remise) VALUES (" + art.IDCLASSEUR + "," + art.IDPRODUIT + ", " + art.NBEX + ", " + art.PRIX + ", " + art.REMISE + "); ";
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
        #endregion
        #region ModifierAchat()
        public static int ModifierAchat(Achat art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE achat SET idProduit =" + art.IDPRODUIT + ", nbex=" + art.NBEX + ", prix=" + art.PRIX + ", remise=" + art.REMISE + " WHERE id=" + art.ID + " ";
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
        public static int SupprimerAchat(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM achat WHERE id=" + idd + " ";
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
