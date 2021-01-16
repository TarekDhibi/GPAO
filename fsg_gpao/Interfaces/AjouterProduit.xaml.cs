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

namespace fsg_gpao.Interfaces
{
    /// <summary>
    /// Logique d'interaction pour AjouterProduit.xaml
    /// </summary>
    public partial class AjouterProduit : Window
    {
        int idCourant = 0;
       
        public AjouterProduit()
        {
            InitializeComponent();
        }
        public AjouterProduit(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
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
            if (TBNom.Text.Equals("") || TBQuantite.Text.Equals("") || TBPrix.Text.Equals(""))
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
                if (int.Parse(TBQuantite.Text) <= 0)
                {
                    Afficher_Msg_Erreur("vérifier la quantité !");
                    
                }

                else
                {
                    CacherGroupeA();
                }

            }


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
                String solId;
                if (TBId.Text.Equals(""))
                {
                    solId = "0";
                }
                else
                {
                    solId = TBId.Text;
                }
                fsg_gpao.Acteurs.Produits prod = new fsg_gpao.Acteurs.Produits(Int16.Parse(solId), TBNom.Text, TBCat.Text, TBDesc.Text, Int16.Parse(TBQuantite.Text), TBPrix.Text);

                int res = fsg_gpao.Connecteurs.ProduitC.AjouterProduits(prod);
                int Idnew = fsg_gpao.Connecteurs.ProduitC.MaxId();
                        if (res == 1)
                        {
                            Afficher_Msg_Confirmation("Le produit est bien ajouter");
                            try
                            {
                                DateTime localDate = DateTime.Now;
                                fsg_gpao.Acteurs.JournalProd journal = new fsg_gpao.Acteurs.JournalProd(idCourant, Idnew, localDate.ToString("F"), "Création du nouvel article : " + prod.NOM, prod.DESC);
                                fsg_gpao.Connecteurs.JournalProdC.ajouterJournal(journal);
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
    }
}
