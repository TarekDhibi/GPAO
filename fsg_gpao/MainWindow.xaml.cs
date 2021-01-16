using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using fsg_gpao.Acteurs;
using fsg_gpao.Connecteurs;
using System.Windows.Threading;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using fsg_gpao.Interfaces;

namespace fsg_gpao
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FocusManager.SetFocusedElement(this, TBLogin);
        }

        public bool vide()
        {
            if (TBLogin.Text.Equals("") || TBMDP.Password.Equals(""))
                return true;
            return false;
        }

        public void Vider_Msg_Information()
        {
            if (labmsg.Content.Equals("Connecter à l'application") || labmsg.Content.Equals("Quitter l'application") || labmsg.Content.Equals("Recevoir un email contenat votre mot de passe"))
                Afficher_Msg_Information("");
        }

        public void Afficher_Msg_Confirmation(string msg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#32CD32");
            labmsg.Foreground = new SolidColorBrush(couleur);
            labmsg.Content = msg;
        }

        public void Afficher_Msg_Erreur(string msg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#ff6666");
            labmsg.Foreground = new SolidColorBrush(couleur);
            labmsg.Content = msg;
        }

        public void Afficher_Msg_Information(string msg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#1E90FF");
            labmsg.Foreground = new SolidColorBrush(couleur);
            labmsg.Content = msg;
        }

        public void Action_Connexion()
        {
            try
            {
                if (vide())
                {
                    Afficher_Msg_Erreur("Champ(s) vide(s), tous les champs sont obligatoires");
                }
                else
                {
                    profile prof = new profile(TBLogin.Text, TBMDP.Password);
                    int id = profilC.authentification(prof);
                    prof.ID = id;

                    if (id == -1)
                    {

                        Afficher_Msg_Erreur("Erreur de connexion! veuillez contacter le service technique");
                    }
                    else
                    {
                        if (id == 0)
                        {

                            Afficher_Msg_Erreur("La combinaison login et mot de passe est incorrecte.");
                        }
                        else
                        {
                            Principale p = new Principale(id);
                            //p.WindowState = WindowState.Maximized;
                            DateTime localDate = DateTime.Now;
                            fsg_gpao.Acteurs.JournalP journal = new fsg_gpao.Acteurs.JournalP(id, localDate.ToString("F"),"Connexion", "");
                            fsg_gpao.Connecteurs.JournalPC.ajouterJournal(journal);
                            p.Show();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btconfirmer_Click(object sender, RoutedEventArgs e)
        {
            Action_Connexion();
        }

        private void btquitter_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btemail_Click(object sender, RoutedEventArgs e)
        {
            string mail = fsg_gpao.Connecteurs.profilC.GetEmailFromLogin(TBLogin.Text);
            String mdp = profilC.GetMdpFromLogin(TBLogin.Text);
            int res = fsg_gpao.Connexion_bd.EnvoyerEmail.MessageMdp(mail, mdp);
            if (TBLogin.Text.Equals(""))
            {
                Afficher_Msg_Erreur("Veuillez saisir votre login");
            }
            else
            {
                if (profilC.LogExiste(TBLogin.Text) == 0)
                {
                    Afficher_Msg_Erreur("Verifier votre login ");
                }
                else
                    if (res == -1)
                    {
                        Afficher_Msg_Erreur("Erreur de connexion. veuillez contacter le service technique");
                    }
                    else
                    {
                        Afficher_Msg_Confirmation("Votre message a été envoyé avec succée");
                    }
            }
        }


        private void btconfirmer_MouseEnter(object sender, MouseEventArgs e)
        {
            btconfirmer.Opacity = 1;
            Afficher_Msg_Information("Connecter à l'application");
            
        }

        private void btconfirmer_MouseLeave(object sender, MouseEventArgs e)
        {
            btconfirmer.Opacity = 0.5;
            Vider_Msg_Information();

        }

        private void btquitter_MouseEnter(object sender, MouseEventArgs e)
        {
            btquitter.Opacity = 1;
            Afficher_Msg_Information("Quitter l'application");
        }

        private void btquitter_MouseLeave(object sender, MouseEventArgs e)
        {
            btquitter.Opacity = 0.5;
            Vider_Msg_Information();
        }

        private void btemail_MouseEnter(object sender, MouseEventArgs e)
        {
            btemail.Opacity = 1;
            Afficher_Msg_Information("Recevoir un email contenat votre mot de passe");
        }

        private void btemail_MouseLeave(object sender, MouseEventArgs e)
        {
            btemail.Opacity = 0.5;
            Vider_Msg_Information();
        }

        private void mdptxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Action_Connexion();
                e.Handled = true;
            }
        }











































    }
}
