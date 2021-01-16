using fsg_gpao.Acteurs;
using fsg_gpao.Connexion_bd;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fsg_gpao.Connecteurs
{
    class JournalPC
    {

        public static void ajouterJournal(JournalP journal)
        {
            try
            {
                Connexion cnx = new Connexion();
                cnx.OpenConnection();
                String requette = "INSERT INTO journaladmin (idAdmin, heure, action, remarque) VALUES  (" + journal.IDADMIN + ",'" + journal.HEURE + "','" + journal.ACTION + "','" + journal.REMARQUE + "')";
                //MySql.Data.MySqlClient.MySqlCommand m1 = new MySql.Data.MySqlClient.MySqlCommand(requette, cnx.connexion);
                //m1.Connection.Open();
                MySqlCommand cmd = new MySqlCommand(requette, cnx.connexion);
                cmd.ExecuteNonQuery();
                cnx.CloseConnection();
                //m1.Connection.Close();
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
            }
        }

        public static int modifierRemarque(JournalP journal)
        {
            try
            {
                Connexion cnx = new Connexion();
                cnx.OpenConnection();
                String requette = "UPDATE journaladmin SET remarque ='" + journal.REMARQUE + "' WHERE id=" + journal.ID + " ";
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

    }
}
