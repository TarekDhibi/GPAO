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
    class JournalProdC
    {

        public static void ajouterJournal(JournalProd journal)
        {
            try
            {
                Connexion cnx = new Connexion();
                cnx.OpenConnection();
                String requette = "INSERT INTO journalproduit (idAdmin, idProduit, heure, action, remarque) VALUES  (" + journal.IDADMIN + "," + journal.IDPRODUIT + ",'" + journal.HEURE + "','" + journal.ACTION + "','" + journal.REMARQUE + "')";
                MySqlCommand cmd = new MySqlCommand(requette, cnx.connexion);
                cmd.ExecuteNonQuery();
                cnx.CloseConnection();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }

        public static int modifierRemarque(JournalProd journal)
        {
            try
            {
                Connexion cnx = new Connexion();
                cnx.OpenConnection();
                String requette = "UPDATE journalproduit SET remarque ='" + journal.REMARQUE + "' WHERE id=" + journal.ID + " ";
                MySqlCommand cmd = new MySqlCommand(requette, cnx.connexion);
                cmd.ExecuteNonQuery();
                cnx.CloseConnection();
                return 1;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return 0;
            }
        }
        public static List<JournalProd> GetAll(String table)
        {
            List<JournalProd> list = new List<JournalProd>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT * FROM  journalproduit ";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new JournalProd
                    {
                        ID = dt.GetInt16(0),
                        IDADMIN = dt.GetInt16(1),
                        IDPRODUIT = dt.GetInt16(2),
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

    }
}