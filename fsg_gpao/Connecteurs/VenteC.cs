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
    class VenteC
    {
        #region Get
        public static List<fsg_gpao.Acteurs.Vente> GetAllVente(int idClasseur)
        {
            List<Vente> list = new List<Vente>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idarticle, nbex, prix, remise FROM vente WHERE idClasseur = " + idClasseur;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Vente
                    {

                        ID = dt.GetInt16(0),
                        IDARTICLE = dt.GetInt16(1),
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
        public static List<Vente> GetAllVente(int idClasseur, String champ, String texte)
        {
            List<Vente> list = new List<Vente>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id, idarticle, nbex, prix, remise FROM vente WHERE (" + champ + " like '%" + texte + "%' AND idClasseur = " + idClasseur+")";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Vente
                    {

                        ID = dt.GetInt16(0),
                        IDARTICLE = dt.GetInt16(1),
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
        public static fsg_gpao.Acteurs.Vente GetVente(int id)
        {
            Vente V = new Vente();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idarticle, nbex, prix, remise FROM vente WHERE id ="+id;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    V.ID = dt.GetInt16(0);
                    V.IDARTICLE = dt.GetInt16(1);
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
        public static int AjouterVente(Vente art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO vente (idClasseur, idarticle, nbex, prix, remise) VALUES (" + art.IDCLASSEUR + "," + art.IDARTICLE + ", " + art.NBEX + ", " + art.PRIX + ", " + art.REMISE + "); ";
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
        #region ModifierVente()
        public static int ModifierVente(Vente art)
        {

            try
            {
                Connexion con = new Connexion(); 
                con.OpenConnection();

                string req = "UPDATE vente SET idarticle =" + art.IDARTICLE + ", nbex=" + art.NBEX + ", prix=" + art.PRIX + ", remise=" + art.REMISE + " WHERE id=" + art.ID + " ";
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
        public static int SupprimerVente(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM vente WHERE id=" + idd + " ";
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
