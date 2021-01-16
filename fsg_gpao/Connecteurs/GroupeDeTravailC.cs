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
    class GroupeDeTravailC
    {
        public static int NomExiste(string nom)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT id FROM groupedetravail WHERE nom = '" + nom + "' ; ";
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
                String req = " SELECT quant FROM groupedetravail WHERE id= " + idd + " ";
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
        public static int IdExiste(string idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = "SELECT id FROM groupedetravail WHERE id = '" + idd + "' ; ";
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
                String req = " SELECT id FROM journalgroupedetravail WHERE idgroupedetravail= " + idd + " ";
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
        public static List<fsg_gpao.Acteurs.GroupeDeTravail> GetAllgroupedetravail()
        {
            List<GroupeDeTravail> list = new List<GroupeDeTravail>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom,prenom, idAtelier, Date, Remarque FROM groupedetravail";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new GroupeDeTravail
                    {

                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        PRENOM = dt.GetString(2),
                        IDATELIER = dt.GetInt16(3),
                        DATE = dt.GetString(4),
                        REMARQUE=dt.GetString(5)
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
        public static List<GroupeDeTravail> GetAllgroupedetravail(String champ, String texte)
        {
            List<GroupeDeTravail> list = new List<GroupeDeTravail>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nometprenom, idAtelier, Date FROM groupedetravail WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new GroupeDeTravail
                    {
                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        PRENOM = dt.GetString(2),
                        IDATELIER = dt.GetInt16(3),
                        DATE = dt.GetString(4),
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
        #endregion

        public static fsg_gpao.Acteurs.GroupeDeTravail GetProduit(int id)
        {
            GroupeDeTravail V = new GroupeDeTravail();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom,prenom, idAtelier, Date, Remarque FROM groupedetravail WHERE id =" + id;
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    V.ID = dt.GetInt16(0);
                    V.NOM = dt.GetString(1);
                    V.PRENOM = dt.GetString(2);
                    V.IDATELIER = dt.GetInt16(3);
                    V.DATE = dt.GetString(4);
                    V.REMARQUE = dt.GetString(5);
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

        #region Ajoutergroupedetravail()
        public static int Ajoutergroupedetravail(GroupeDeTravail art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO groupedetravail (nom,prenom, idAtelier, Date, Remarque) VALUES ('" + art.NOM + "', '" + art.PRENOM + "', " + art.IDATELIER + ", '" + art.DATE + "', '" + art.REMARQUE + "'); ";
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
        #region Modifiergroupedetravail()
        public static int Modifiergroupedetravail(GroupeDeTravail art)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE  groupedetravail SET nom ='" + art.NOM + "',prenom='" + art.PRENOM + "', idAtelier=" + art.IDATELIER + ", Date='" + art.DATE + "', Remarque='" + art.REMARQUE + "' WHERE id=" + art.ID + " ";
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
        #region Supprimergroupedetravail()
        public static int Supprimergroupedetravail(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM groupedetravail WHERE id=" + idd + " ";
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


        #region GetAllgroupedetravailLikeColonne()
        public static List<GroupeDeTravail> GetAllgroupedetravailLikeColonne(String colonne, string rech)
        {
            List<GroupeDeTravail> list = new List<GroupeDeTravail>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id, nom,prenom, idAtelier, Date, Remarque FROM groupedetravail WHERE " + colonne + " like '%" + rech + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new GroupeDeTravail
                    {
                        ID = dt.GetInt16(0),
                        NOM = dt.GetString(1),
                        PRENOM = dt.GetString(2),
                        IDATELIER = dt.GetInt16(3),
                        DATE = dt.GetString(4),
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
        #endregion
    }
}
