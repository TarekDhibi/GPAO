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
    class ArticleC
    {

        public static int NomExiste(string nom)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT id FROM article WHERE nom = '" + nom + "' ; ";
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
        public static int MaxId()
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT MAX(id) FROM article ; ";
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
                String req = "SELECT id FROM article WHERE id = " + idd + " ; ";
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
        //statistique
        public static List<String> getAllChampFromTableST(String champ, String tab)
        {
            List<String> V = new List<String>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT "+champ+" FROM "+tab ;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    V.Add( dt.GetString(0));
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
        public static List<String> getAllQuantChampFromTableST(String tab)
        {
            List<String> V = new List<String>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT quant FROM " + tab;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    V.Add(dt.GetString(0));
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
        public static List<String> getAllNbexChampFromTableST(String tab)
        {
            List<String> V = new List<String>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT nbex FROM " + tab;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    V.Add(dt.GetString(0));
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
        public static int getQuantite(int idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = " SELECT quant FROM article WHERE id= " + idd + " ";
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
        public static String getNom(int idd)
        {
            String id = "";
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = " SELECT nom FROM article WHERE id= " + idd + " ";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {

                    id = dt.GetString(0);
                }
                con.CloseConnection();
                return id;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "-1";
            }
        }
        #region GetAllProfiles()
        public static List<Article> GetAllArticles()
        {
            List<Article> list = new List<Article>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, cat, description, quant, prix FROM article";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Article
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
        public static String GetNomFromId(int id)
        {
            String nom = "";
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT nom FROM article WHERE id = "+id+";";
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
        public static List<Article> GetAllProfiles(String champ, String texte)
        {
            List<Article> list = new List<Article>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, cat, description, quant, prix FROM article WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Article
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

        public static fsg_gpao.Acteurs.Article GetArticle(int id)
        {
            Article V = new Article();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, cat, description, quant, prix FROM article WHERE id =" + id;
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

        #region AjouterArticle()
        public static int AjouterArticle(Article art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO article (nom, cat, description, quant, prix) VALUES ('" + art.NOM + "', '" + art.CAT + "', '" + art.DESC + "', '" + art.QUANTITE + "', '" + art.PRIX + "' ); ";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                cmd.ExecuteNonQuery();
                con.CloseConnection();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message +""+e.ToString());
                return 0;
            }

        }
        #endregion
        #region ModifierArticle()
        public static int ModifierArticle(Article art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE  article SET nom ='" + art.NOM + "', cat='" + art.CAT + "', description='" + art.DESC + "', quant=" + art.QUANTITE + ", prix=" + art.PRIX + " WHERE id=" + art.ID + " ";
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
        public static int ModifierQuantiteArticle(int id, int nbex)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE article SET quant=" + nbex + " WHERE id=" + id + " ";
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
        #region SupprimerArticle()
        public static int SupprimerArticle(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM article WHERE id=" + idd + " ";
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


        #region GetAllArticlesLikeColonne()
        public static List<Article> GetAllArticlesLikeColonne(String colonne, string rech)
        {
            List<Article> list = new List<Article>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, cat, description, quant, prix FROM article WHERE " + colonne + " LIKE '%" + rech + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Article
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
