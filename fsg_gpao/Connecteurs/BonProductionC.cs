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
    class BonProductionC
    {
        public static List<JournalP> GetAll(String table)
        {
            List<JournalP> list = new List<JournalP>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT * FROM "+table;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new JournalP
                    {
                        ID = dt.GetInt16(0),
                        IDADMIN = dt.GetInt16(1),
                        HEURE = dt.GetString(2),
                        ACTION = dt.GetString(3),
                        REMARQUE = dt.GetString(4)
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
        public static List<JournalArticle> GetAll6(String table)
        {
            List<JournalArticle> list = new List<JournalArticle>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT * FROM " + table;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new JournalArticle
                    {
                        ID = dt.GetInt16(0),
                        IDADMIN = dt.GetInt16(1),
                        IDARTICLE = dt.GetInt16(2),
                        HEURE = dt.GetString(3),
                        ACTION = dt.GetString(4),
                        REMARQUE = dt.GetString(5)
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
        public static List<fsg_gpao.Acteurs.BonProduction> GetAllFactures()
        {
            List<BonProduction> list = new List<BonProduction>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idArticle, idAtelier, nbArticle, dateDepart, dateFin, cout FROM factureproduction";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new BonProduction
                    {
                        ID = dt.GetInt16(0),
                        IDARTICLE = dt.GetInt16(1),
                        IDATELIER = dt.GetInt16(2),
                        NBARTICLE = dt.GetInt16(3),
                        DATEDEPART = dt.GetString(4),
                        DATEFIN = dt.GetString(5),
                        COUT = dt.GetInt16(6)
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
        public static BonProduction GetAllFactures(int id)
        {
            BonProduction bProduction = new BonProduction();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idArticle, idAtelier, nbArticle, dateDepart, dateFin, cout FROM factureproduction WHERE id="+id;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                        bProduction.ID = dt.GetInt16(0);
                        bProduction.IDARTICLE = dt.GetInt16(1);
                        bProduction.IDATELIER = dt.GetInt16(2);
                        bProduction.NBARTICLE = dt.GetInt16(3);
                        bProduction.DATEDEPART = dt.GetString(4);
                        bProduction.DATEFIN = dt.GetString(5);
                        bProduction.COUT = dt.GetInt16(6);
                }
                con.CloseConnection();
                return bProduction;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
        public static List<BonProduction> GetAllFacturelikecolonne(String champ, String texte)
        {
            List<BonProduction> list = new List<BonProduction>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, idArticle, idAtelier, nbArticle, dateDepart, dateFin, cout FROM factureproduction WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new BonProduction
                    {
                        ID = dt.GetInt16(0),
                        IDARTICLE = dt.GetInt16(1),
                        IDATELIER = dt.GetInt16(2),
                        NBARTICLE = dt.GetInt16(3),
                        DATEDEPART = dt.GetString(4),
                        DATEFIN = dt.GetString(5),
                        COUT = dt.GetInt16(6)
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


        #region Ajout
        public static int AjouterBon(BonProduction art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "INSERT INTO factureproduction (id, idArticle, idAtelier, nbArticle, dateDepart, dateFin, cout) VALUES (" + art.ID + "," + art.IDARTICLE + "," + art.IDATELIER + ", " + art.NBARTICLE + ",'" + art.DATEDEPART + "', '" + art.DATEFIN + "'," + art.COUT + "); ";
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
                string req = "SELECT MAX(id) FROM factureproduction";
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
        public static int IdExiste(int idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id FROM factureproduction WHERE id="+idd;
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
        #region ModifierClasseur()
        public static int ModifierBon(BonProduction art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "UPDATE factureproduction SET idArticle =" + art.IDARTICLE + ", idAtelier=" + art.IDATELIER + ", nbArticle=" + art.NBARTICLE + ", dateDepart='" + art.DATEDEPART + "', dateFin='" + art.DATEFIN + "', cout=" + art.COUT + " WHERE id=" + art.ID + " ";
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
        public static int DemarrerProduction(int id)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                DateTime localDate = DateTime.Now;
                string req = "UPDATE factureproduction SET dateDepart='" + localDate.ToString("d") + "' WHERE id=" + id + " ";
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
                DateTime localDate = DateTime.Now;
                string req = "UPDATE factureproduction SET dateFin='" + localDate.ToString("d") + "' WHERE id=" + id + " ";
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
        public static int SupprimerClasseur(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM factureproduction WHERE id=" + idd + " ";
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
