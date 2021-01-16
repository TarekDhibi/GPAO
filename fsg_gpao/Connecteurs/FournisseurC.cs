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
    class FournisseurC
    {

        public static int NomExiste(string nom)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT id FROM fournisseur WHERE nom = '" + nom + "' ; ";
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
        public static int IdExiste(string idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT id FROM fournisseur WHERE id = '" + idd + "' ; ";
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
                String req = " SELECT id FROM journalArticle WHERE idArticle= " + idd + " ";
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

        #region GetAllFournisseur()
        public static List<fsg_gpao.Acteurs.Fournisseur> GetAllFournisseur()
        {
            List<Fournisseur> list = new List<Fournisseur>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, tel, adresse, specialite, etat FROM fournisseur";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Fournisseur
                    {

                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        TELEPHONE = dt.GetString(2),
                        ADRESSE = dt.GetString(3),
                        SPECIALITE = dt.GetString(4),
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
        public static List<Fournisseur> GetAllFournisseurs(String champ, String texte)
        {
            List<Fournisseur> list = new List<Fournisseur>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, tel, adresse, specialite, etat FROM fournisseur WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Fournisseur
                    {

                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        TELEPHONE = dt.GetString(2),
                        ADRESSE = dt.GetString(3),
                        SPECIALITE = dt.GetString(4),
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

        public static fsg_gpao.Acteurs.Fournisseur GetFournisseur(int id)
        {
            Fournisseur V = new Fournisseur();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, tel, adresse, specialite, etat FROM fournisseur WHERE id =" + id;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                        V.ID = dt.GetInt16(0);
                        V.NOM = dt.GetString(1);
                        V.TELEPHONE = dt.GetString(2);
                        V.ADRESSE = dt.GetString(3);
                        V.SPECIALITE = dt.GetString(4);
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

        #region AjouterFournisseur()
        public static int AjouterFournisseur(Fournisseur art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO fournisseur (nom, tel, adresse, specialite, etat) VALUES ('" + art.NOM + "', '" + art.TELEPHONE + "', '" + art.ADRESSE + "', '" + art.SPECIALITE + "', " + art.ETAT + " ); ";
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
        #region ModifierFournisseur()
        public static int ModifierFournisseur(Fournisseur art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE  fournisseur SET nom ='" + art.NOM + "', tel='" + art.TELEPHONE + "', adresse='" + art.ADRESSE + "', specialite='" + art.SPECIALITE + "', etat=" + art.ETAT + " WHERE id=" + art.ID + " ";
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
        #region SupprimerFournisseur()
        public static int SupprimerFournisseur(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM fournisseur WHERE id=" + idd + " ";
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


        #region GetAllFournisseurLikeColonne()
        public static List<Fournisseur> GetAllFournisseurLikeColonne(String colonne, string rech)
        {
            List<Fournisseur> list = new List<Fournisseur>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, tel, adresse, specialite, etat FROM fournisseur WHERE " + colonne + " LIKE '%" + rech + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Fournisseur
                    {

                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        TELEPHONE = dt.GetString(2),
                        ADRESSE = dt.GetString(3),
                        SPECIALITE = dt.GetString(4),
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
