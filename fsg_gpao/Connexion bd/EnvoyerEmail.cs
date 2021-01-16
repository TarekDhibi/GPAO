using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace fsg_gpao.Connexion_bd
{
    class EnvoyerEmail
    {
        public static int MessageMdp(String destination, String mdp)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("app.gpao@gmail.com", "123azerty");

                DateTime localDate = DateTime.Now;
                string msg = "Suite à votre demande de mot de passe le " + localDate.ToString() + "\n on vous envoi votre mot de passe est :" + mdp;
                client.Send("app.gpao@gmail.com", destination, "Mot de passe oublier", msg);
            }
            catch (Exception ex)
            {
                return -1;
            }
            return 0;
        }
    }
}
