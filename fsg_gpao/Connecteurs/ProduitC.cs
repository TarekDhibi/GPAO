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
    class ProduitC
    {
        public static int NomExiste(string nom)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT id FROM produits WHERE nom = '" + nom + "' ; ";
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
        public static String GetNomFromId(int id)
        {
            String nom = "";
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT nom FROM produits WHERE id = " + id + ";";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    nom = dt.GetString(0);
                }
                con.CloseConnection();
                return nom;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public static int MaxId()
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT MAX(id) FROM produits ; ";
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
        public static int getQuantite(int idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = " SELECT quant FROM produits WHERE id= " + idd + " ";
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
        public static int getPrix(int idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = " SELECT prix FROM produits WHERE id= " + idd + " ";
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
        public static int ModifierQuantiteProduit(int id, int nbex)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE produits SET quant=" + nbex + " WHERE id=" + id + " ";
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
        public static int IdExiste(string idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT id FROM produits WHERE id = '" + idd + "' ; ";
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
                String req = " SELECT id FROM journalProduit WHERE idProduit= " + idd + " ";
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

        #region GetAllProfiles()
        public static List<fsg_gpao.Acteurs.Produits> GetAllProduits()
        {
            List<Produits> list = new List<Produits>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, cat, description, quant, prix FROM produits";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Produits
                    {

                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        CAT = dt.GetString(2),
                        DESC = dt.GetString(3),
                        QUANTITE = dt.GetInt16(4),
                        PRIX = dt.GetString(5)
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
        public static List<Produits> GetAllProduits(String champ, String texte)
        {
            List<Produits> list = new List<Produits>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, cat, description, quant, prix FROM produits WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Produits
                    {

                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        CAT = dt.GetString(2),
                        DESC = dt.GetString(3),
                        QUANTITE = dt.GetInt16(4),
                        PRIX = dt.GetString(5)
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

        public static fsg_gpao.Acteurs.Produits GetProduit(int id)
        {
            Produits V = new Produits();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, cat, description, quant, prix FROM produits WHERE id =" + id;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    V.ID = dt.GetInt16(0);
                    V.NOM = dt.GetString(1);
                    V.CAT = dt.GetString(2);
                    V.DESC = dt.GetString(3);
                    V.QUANTITE = dt.GetInt16(4);
                    V.PRIX = dt.GetString(5);
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

        #region AjouterProduits()
        public static int AjouterProduits(Produits art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO produits (nom, cat, description, quant, prix) VALUES ('" + art.NOM + "', '" + art.CAT + "', '" + art.DESC + "', '" + art.QUANTITE + "', '" + art.PRIX + "' ); ";
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
        #region ModifierProduits()
        public static int ModifierProduits(Produits art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE  produits SET nom ='" + art.NOM + "', cat='" + art.CAT + "', description='" + art.DESC + "', quant=" + art.QUANTITE + ", prix=" + art.PRIX + " WHERE id=" + art.ID + " ";
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
        #region SupprimerProduits()
        public static int SupprimerProduits(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM produits WHERE id=" + idd + " ";
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


        #region GetAllProduitsLikeColonne()
        public static List<Produits> GetAllProduitsLikeColonne(String colonne, string rech)
        {
            List<Produits> list = new List<Produits>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, cat, description, quant, prix FROM produits WHERE " + colonne + " LIKE '%" + rech + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Produits
                    {

                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        CAT = dt.GetString(2),
                        DESC = dt.GetString(3),
                        QUANTITE = dt.GetInt16(4),
                        PRIX = dt.GetString(5)
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
