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
using System.Windows.Shapes;
using fsg_gpao.Acteurs;
using fsg_gpao.Connecteurs;
using fsg_gpao.Connexion_bd;

namespace fsg_gpao.Interfaces
{
    /// <summary>
    /// Logique d'interaction pour AJouterGroupeDeTravail.xaml
    /// </summary>
    public partial class AJouterGroupeDeTravail : Window
    {
        List<Atelier> ls = new List<Atelier>();
        List<String> lN = new List<String>();
        int idCourant = 0;
        
        public AJouterGroupeDeTravail()
        {
            InitializeComponent();
        }
        public AJouterGroupeDeTravail(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            chargerNomAtelier();

            DateTime localDate = DateTime.Now;
            TBDate.Text = localDate.ToString("d");
        }
        private void creerTitre()
        {
            try
            {
                String login = Connecteurs.profilC.GetLoginFromId(idCourant);
                this.Title = "Administrateur courant : " + login;
            }
            catch (Exception ex)
            {

            }
        }
        public bool ChampVide()
        {
            if (TBIdAtelier.Text.Equals("") || TBNom.Text.Equals(""))
            {
                return true;
            }
            return false;
        }
        public void Afficher_Msg_Erreur(string msgg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#ff6666");
            msg.Foreground = new SolidColorBrush(couleur);
            msg.Content = msgg;
        }

        public void Afficher_Msg_Confirmation(string msgg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#32CD32");
            msg.Foreground = new SolidColorBrush(couleur);
            msg.Content = msgg;
        }

        public void CacherGroupeA()
        {
            BTAjouter.Visibility = Visibility.Hidden;
            //BTModifier.Visibility = Visibility.Hidden;
            //BTSupprimer.Visibility = Visibility.Hidden;
            BTConfirmer.Visibility = Visibility.Visible;
            BTAnnuler.Visibility = Visibility.Visible;
        }

        private void BTAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (ChampVide())
            {
                Afficher_Msg_Erreur("Erreur : Champ(s) vide(s) ");
            }
            else
            {
                
                CacherGroupeA();
            }


        }
        private void chargerNomAtelier()
        {
            ls.Clear();
            ls = AtelierC.GetAllatelier();
            lN.Clear();
            for (int i = 0; i < ls.Count; i++)
            {
                lN.Add(ls.ElementAt(i).NOM);
            }
            CBAtelier.Items.Clear();
            for (int i = 0; i < lN.Count; i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = lN.ElementAt(i);
                item.Value = i;
                CBAtelier.Items.Add(item);
            }
            CBAtelier.SelectedIndex = 0;

        }

        private void BTAjouter_MouseEnter(object sender, MouseEventArgs e)
        {
            BTAjouter.Opacity = 1;

        }

        private void BTAjouter_MouseLeave(object sender, MouseEventArgs e)
        {
            BTAjouter.Opacity = 0.5;
        }

        private void BTConfirmer_MouseEnter(object sender, MouseEventArgs e)
        {
            BTConfirmer.Opacity = 1;
        }

        private void BTAnnuler_MouseEnter(object sender, MouseEventArgs e)
        {
            BTAnnuler.Opacity = 1;
        }

        private void BTConfirmer_MouseLeave(object sender, MouseEventArgs e)
        {
            BTConfirmer.Opacity = 0.5;
        }

        private void BTAnnuler_MouseLeave(object sender, MouseEventArgs e)
        {
            BTAnnuler.Opacity = 0.5;
        }

        private void BTAnnuler_Click(object sender, RoutedEventArgs e)
        {
            cacherGroupeB();
        }

        private void BTConfirmer_Click(object sender, RoutedEventArgs e)
        {
            if (ChampVide())
            {
                Afficher_Msg_Erreur("Erreur : champ(s) vide(s)");
            }
            else
            {
                fsg_gpao.Acteurs.GroupeDeTravail adminx = new fsg_gpao.Acteurs.GroupeDeTravail(0, TBNom.Text, TBPrenom.Text, Int16.Parse(TBIdAtelier.Text), TBDate.Text, TBRemarque.Text);

                int res = fsg_gpao.Connecteurs.GroupeDeTravailC.Ajoutergroupedetravail(adminx);
                        if (res == 1)
                        {
                            Afficher_Msg_Confirmation("Ce profil appartient à l'atelier courant");
                            try
                            {
                                DateTime localDate = DateTime.Now;
                                fsg_gpao.Acteurs.JournalArticle journal = new fsg_gpao.Acteurs.JournalArticle(idCourant, adminx.ID, localDate.ToString("F"), "modification de groupe de travail concernant l'atelier : " + TBIdAtelier.Text, "");
                                fsg_gpao.Connecteurs.JournalArticleC.ajouterJournal(journal);
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {
                            Afficher_Msg_Erreur("Erreur de connexion à la base de données!");
                        }
                cacherGroupeB();

            }
            cacherGroupeB();
        }
        private void cacherGroupeB()
        {
            BTAjouter.Visibility = Visibility.Visible;
            // BtModifier.Visibility = Visibility.Visible;
            //BtSupprimer.Visibility = Visibility.Visible;
            BTConfirmer.Visibility = Visibility.Hidden;
            BTAnnuler.Visibility = Visibility.Hidden;
        }

        private void BTQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTQuitter_MouseEnter(object sender, MouseEventArgs e)
        {
            BTQuitter.Opacity = 1;
        }

        private void BTQuitter_MouseLeave(object sender, MouseEventArgs e)
        {
            BTQuitter.Opacity = 0.5;

        }

        private void CBAtelier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBIdAtelier.Text = ls.ElementAt(CBAtelier.SelectedIndex).ID + "";
        }
    }
}
