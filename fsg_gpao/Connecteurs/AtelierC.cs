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
    class AtelierC
    {
        public static int NomExiste(string nom)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT id FROM atelier WHERE nom = '" + nom + "' ; ";
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
                String req = "SELECT id FROM atelier WHERE id = " + idd + " ; ";
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
                String req = " SELECT id FROM journalatelier WHERE idatelier= " + idd + " ";
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

        #region GetAllatelier()
        public static List<fsg_gpao.Acteurs.Atelier> GetAllatelier()
        {
            List<Atelier> list = new List<Atelier>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, description, specialite FROM atelier";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Atelier
                    {

                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        DESCRIPTION = dt.GetString(2),
                        SPECIALITE = dt.GetString(3)
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
        public static List<Atelier> GetAllatelier(String champ, String texte)
        {
            List<Atelier> list = new List<Atelier>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = "SELECT id, nom, description, specialite FROM atelier WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Atelier
                    {
                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        DESCRIPTION = dt.GetString(2),
                        SPECIALITE = dt.GetString(3)
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

        public static fsg_gpao.Acteurs.Atelier Getatelier(int id)
        {
            Atelier V = new Atelier();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, description, specialite FROM atelier WHERE id =" + id;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    V.ID = dt.GetInt16(0);
                    V.NOM = dt.GetString(1);
                    V.DESCRIPTION = dt.GetString(2);
                    V.SPECIALITE = dt.GetString(3);
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
        #region Ajouteratelier()
        public static int Ajouteratelier(Atelier art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO atelier(nom, description, specialite) VALUES ('" + art.NOM + "','" + art.DESCRIPTION + "','" + art.SPECIALITE + "')";
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
        #region Modifieratelier()
        public static int Modifieratelier(Atelier art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE  atelier SET nom ='" + art.NOM + "', description='" + art.DESCRIPTION + "', specialite='" + art.SPECIALITE + "' WHERE id=" + art.ID + " ";
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
        #region Supprimeratelier()
        public static int Supprimeratelier(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM atelier WHERE id=" + idd + " ";
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
        #region GetAllatelierLikeColonne()
        public static List<Atelier> GetAllatelierLikeColonne(String colonne, string rech)
        {
            List<Atelier> list = new List<Atelier>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom, description, specialite FROM atelier WHERE " + colonne + " LIKE '%" + rech + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new Atelier
                    {
                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        DESCRIPTION = dt.GetString(2),
                        SPECIALITE = dt.GetString(3)
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
