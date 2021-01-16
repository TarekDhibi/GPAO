using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fsg_gpao.Connexion_bd;
using fsg_gpao.Acteurs;
using MySql.Data.MySqlClient;
using System.Windows;


namespace fsg_gpao.Connecteurs
{
    class profilC
    {
        #region authentification()
        public static int authentification(profile prof)
        {
            
            int id = 0;
            try { 
            Connexion con = new Connexion();
            con.OpenConnection();
            string req = "SELECT id FROM profile WHERE login='" + prof.LOGIN + "' AND mdp='" + prof.MDP + "' AND etat=true ;";
            ////MySql.Data.MySqlClient.MySqlCommand m1 = new MySql.Data.MySqlClient.MySqlCommand(req,con.connexion);
            ////m1.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(req, con.connexion);
            MySqlDataReader dt = cmd.ExecuteReader();
            while (dt.Read())
            {
                id= dt.GetInt16(0);

            }
            cmd.Connection.Close();
            con.CloseConnection();
            return id;
           
            }
            catch(Exception e){
                MessageBox.Show(e.Message + " 888 " +e.Data);
                return -1;
            }
        }
        #endregion
  
        #region GetMdpFromLogin()
        public static string GetMdpFromLogin(string log)
        {
            string mdp = "";
            try{
            Connexion con = new Connexion();
            con.OpenConnection();
            string req = "SELECT mdp FROM profile WHERE login='" + log + "';";
            MySqlCommand cmd = new MySqlCommand(req, con.connexion);
            MySqlDataReader dt = cmd.ExecuteReader();
            while (dt.Read())
            {
                mdp = dt.GetString(0);
            }
            con.CloseConnection();
            return mdp;
            }
               catch(Exception e){
                MessageBox.Show(e.Message);
                return null;
            }

        }
        #endregion  

        #region GetEmailFromLogin()
        public static String GetEmailFromLogin(String log)
        {
            string mail = "";
            try {
            Connexion con = new Connexion();
            con.OpenConnection();
            string req = "SELECT mail FROM profile WHERE login='" + log + "';";
            MySqlCommand cmd = new MySqlCommand(req, con.connexion);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {

                mail = dataReader.GetString(0);

            }
            con.CloseConnection();    
            return mail;
            }
               catch(Exception e){
                MessageBox.Show(e.Message);
                return null;
            }
        }

        #endregion

        #region LogExiste(string log)
        public static int LogExiste(string log)
        {
            int id = 0;
            try
            {
                Connexion con =new Connexion();
                con.OpenConnection();
                String req="SELECT id FROM profile WHERE login = '"+ log +"' ; ";
                MySqlCommand cmd = new MySqlCommand(req,con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while(dt.Read()){
                    id = dt.GetInt16(0);
                }
                con.CloseConnection(); 
                return id;
                }
            catch(Exception e){
                MessageBox.Show(""+e.Message);
                return -1;
            }  
        }
        #endregion

        #region LogExiste(string log,int idd)
        public static int LogExiste(string log,int idd)
        {
            int id=0;
            try{
                Connexion con =new Connexion();
                con.OpenConnection();
                String req=" SELECT id FROM profile WHERE login = '"+ log+"'  AND id <> "+ idd+";";
                MySqlCommand cmd =new MySqlCommand(req,con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while(dt.Read()){

                    id=dt.GetInt16(0);
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
        public static int IdExisteJournal( int idd)
        {
            int id = 0;
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                String req = " SELECT id FROM journaladmin WHERE idAdmin= " + idd + " ";
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

        #region GetProfileFromLogin()
        public static profile GetProfileFromLogin(string log)
        {
            profile prof = new profile();
            try{
            Connexion con = new Connexion();
            con.OpenConnection();
            string req = " SELECT id,login,mdp,mail,service,etat FROM profile WHERE login ='" + log + "';";
            MySqlCommand cmd = new MySqlCommand(req, con.connexion);
            MySqlDataReader dt = cmd.ExecuteReader();
            while (dt.Read())
            {
                prof.ID = dt.GetInt16(0);
                prof.MDP = dt.GetString(1);
                prof.MAIL = dt.GetString(2);
                prof.SERVICE = dt.GetString(3);
                prof.ETAT = dt.GetBoolean(4);

            }
            con.CloseConnection(); 
        }
            catch (Exception ex){
                MessageBox.Show(ex.Message);
                prof.ID=-1;
                return null;
            }
           //MessageBox.Show("prof id"+prof.ID +" prof mail "+ prof.MAIL+" prof service "+prof.SERVICE );
            return prof;
        }
        public static String GetService(int id)
        {
            String service = "";
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT service FROM profile WHERE id =" + id + ";";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    service = dt.GetString(0);

                }
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "-1";
            }
            //MessageBox.Show("prof id"+prof.ID +" prof mail "+ prof.MAIL+" prof service "+prof.SERVICE );
            return service;
        }
        public static String GetLoginFromId(int id)
        {
            String log = "";
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT login FROM profile WHERE id ='" + id + "';";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    log = dt.GetString(0);

                }
                con.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            //MessageBox.Show("prof id"+prof.ID +" prof mail "+ prof.MAIL+" prof service "+prof.SERVICE );
            return log;
        }
        #endregion

        #region GetAllProfiles()
        public static List<profile> GetAllProfiles()
        {
            List<profile> list = new List<profile>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id,login,mdp,mail,service,etat FROM profile";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new profile
                    {

                        ID = dt.GetInt16(0),
                        LOGIN = dt.GetString(1),
                        MDP = dt.GetString(2),
                        MAIL = dt.GetString(3),
                        SERVICE = dt.GetString(4),
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
        public static List<profile> GetAllProfiles(String champ, String texte)
        {
            List<profile> list = new List<profile>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id,login,mdp,mail,service,etat FROM profile WHERE " + champ + " like '%" + texte + "%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new profile
                    {

                        ID = dt.GetInt16(0),
                        LOGIN = dt.GetString(1),
                        MDP = dt.GetString(2),
                        MAIL = dt.GetString(3),
                        SERVICE = dt.GetString(4),
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


        #region AjouterProfile()
        public static int AjouterProfile(profile prof){

            try{
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "INSERT INTO profile(login,mdp,mail,service,etat) VALUES ('" + prof.LOGIN + "','" + prof.MDP + "','" + prof.MAIL + "','" + prof.SERVICE + "'," + prof.ETAT + ")";
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
        #region ModifierProfile()
        public static int ModifierProfile(profile prof)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "UPDATE  profile SET login ='" + prof.LOGIN + "', mdp='" + prof.MDP + "', mail='" + prof.MAIL + "',service='" + prof.SERVICE + "',etat=" + prof.ETAT +" WHERE id="+ prof.ID+" ";
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
        #region SupprimerProfile()
        public static int SupprimerProfile(int idd)
        {

            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();

                string req = "DELETE FROM profile WHERE id=" + idd + " ";
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


        #region GetAllProfilesLikeColonne()
        public static List<profile> GetAllProfilesLikeColonne(String colonne,string rech)
        {
            List<profile> list = new List<profile>();
            try
            {
                Connexion con = new Connexion();
                con.OpenConnection();
                string req = " SELECT id,login,mdp,mail,service,etat From profile WHERE "+ colonne+" LIKE '%"+ rech+"%'";
                MySqlCommand cmd = new MySqlCommand(req, con.connexion);
                MySqlDataReader dt = cmd.ExecuteReader();
                while (dt.Read())
                {
                    list.Add(new profile
                    {

                        ID = dt.GetInt16(0),
                        LOGIN = dt.GetString(1),
                        MDP = dt.GetString(2),
                        MAIL = dt.GetString(3),
                        SERVICE = dt.GetString(4),
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
