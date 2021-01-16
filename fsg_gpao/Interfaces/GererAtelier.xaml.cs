using fsg_gpao.Acteurs;
using fsg_gpao.Connecteurs;
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
    /// Logique d'interaction pour GererAtelier.xaml
    /// </summary>
    public partial class GererAtelier : Window
    {
        Atelier prod = new Atelier();
        private string ActionDemander ="";
        int idCourant = 0;

        public GererAtelier()
        {
            InitializeComponent();
            LoadAllAteliers();
        }
        public GererAtelier(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            LoadAllAteliers();
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

        public void Afficher_Msg_Confirmation(string msg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#32CD32");
            MsgInfo.Foreground = new SolidColorBrush(couleur);
            MsgInfo.Content = msg;
        }

        public void Afficher_Msg_Erreur(string msg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#ff6666");
            MsgInfo.Foreground = new SolidColorBrush(couleur);
            MsgInfo.Content = msg;
        }

        public void Afficher_Msg_Information(string msg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#1E90FF");
            MsgInfo.Foreground = new SolidColorBrush(couleur);
            MsgInfo.Content = msg;

        }
        public void CacherGroupeA()
        {
            //BTAjouter.Visibility = Visibility.Hidden;
            BTModifier.Visibility = Visibility.Hidden;
            BTSupprimer.Visibility = Visibility.Hidden;
            BTConfirmer.Visibility = Visibility.Visible;
            BTAnnuler.Visibility = Visibility.Visible;
        }
        public void CacherGroupeB()
        {
           // BTAjouter.Visibility = Visibility.Visible;
            BTModifier.Visibility = Visibility.Visible;
            BTSupprimer.Visibility = Visibility.Visible;
            BTConfirmer.Visibility = Visibility.Hidden;
            BTAnnuler.Visibility = Visibility.Hidden;
        }

        public bool ChampVide()
        {
            if (TBNom.Text.Equals("") || TBSpecialite.Text.Equals(""))
            {
                return true;
            }
            return false;
        }

        private void BTAjouter_MouseEnter(object sender, MouseEventArgs e)
        {
            //BTAjouter.Opacity = 1;
            
        }

        private void BTModifier_MouseEnter(object sender, MouseEventArgs e)
        {
            BTModifier.Opacity = 1;
            
        }

        private void BTSupprimer_MouseEnter(object sender, MouseEventArgs e)
        {
            BTSupprimer.Opacity = 1;
        }

        private void BTConfirmer_MouseEnter(object sender, MouseEventArgs e)
        {
            BTConfirmer.Opacity = 1;
        }

        private void BTAnnuler_MouseEnter(object sender, MouseEventArgs e)
        {
            BTAnnuler.Opacity = 1;
        }

        private void BTAjouter_MouseLeave(object sender, MouseEventArgs e)
        {
           //BTAjouter.Opacity = 0.5;
        }

        private void BTModifier_MouseLeave(object sender, MouseEventArgs e)
        {
            BTModifier.Opacity = 0.5;
        }

        private void BTSupprimer_MouseLeave(object sender, MouseEventArgs e)
        {
            BTSupprimer.Opacity = 0.5;
        }

        private void BTConfirmer_MouseLeave(object sender, MouseEventArgs e)
        {
            BTConfirmer.Opacity = 0.5;
        }

        private void BTAnnuler_MouseLeave(object sender, MouseEventArgs e)
        {
            BTAnnuler.Opacity = 0.5;
        }


        private void LoadAllAteliers()
        {
            List<Atelier> reader = AtelierC.GetAllatelier() ;
            DataGridAtelier.ItemsSource = null;
            DataGridAtelier.ItemsSource = reader;

        }
        private void LoadAllAteliers(String champ, String texte)
        {
            List<Atelier> reader = AtelierC.GetAllatelier(champ, texte);
            DataGridAtelier.ItemsSource = null;
            DataGridAtelier.ItemsSource = reader;

        }

        private void BTAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (ChampVide())
            {
                Afficher_Msg_Erreur("Erreur : Champ(s) vide(s) ");
            }
            else
            {
               
                ActionDemander = "Ajouter";
                CacherGroupeA();
            }
            

        }

        private void BTModifier_Click(object sender, RoutedEventArgs e)
        {
            if (ChampVide())
            {
                Afficher_Msg_Erreur("Erreur : Champ(s) vide(s) ");
            }
            else
            {
               
                ActionDemander = "Modifier";
                CacherGroupeA();
            }
        }

        private void BTSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (TBId.Text.Equals(""))
            {
                Afficher_Msg_Erreur("Erreur : Vous devez selectionnez un agent ");
               
            }
            else
            {
                ActionDemander = "Supprimer";
                CacherGroupeA();
            }
        }

        private void BTConfirmer_Click(object sender, RoutedEventArgs e)
        {
            //ActionDemander = "";
            if (ChampVide())
            {
                Afficher_Msg_Confirmation("Erreur : champ(s) vide(s)");
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
                fsg_gpao.Acteurs.Atelier clientx = new fsg_gpao.Acteurs.Atelier(Int16.Parse(solId), TBNom.Text, TBDescription.Text, TBSpecialite.Text);

                if (ActionDemander.Equals("Modifier"))
                {
                    if (!TBId.Text.Equals(""))
                    {
                        int res = fsg_gpao.Connecteurs.AtelierC.Modifieratelier(clientx);
                                if (res == 1)
                                {
                                    Afficher_Msg_Confirmation("Le Atelier est bien modifier");
                                }
                                else
                                {
                                    Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                                }
                    }
                    else
                    {
                        Afficher_Msg_Erreur("Veuillez sélctionnez un Atelier");
                    }
                    CacherGroupeB();
                    LoadAllAteliers();
                }
                else
                {
                    if (ActionDemander.Equals("Supprimer"))
                    {
                        if (!TBId.Text.Equals(""))
                        {
                            int res = fsg_gpao.Connecteurs.AtelierC.Supprimeratelier(clientx.ID);
                            if (res == 1)
                            {
                                Afficher_Msg_Confirmation("L'atelier est bien supprimer");
                             }
                            else
                            {
                                Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                            }
                        }
                        else
                        {
                            Afficher_Msg_Erreur("Veuillez sélctionnez un Atelier");
                        }
                    }
                }
            }
            CacherGroupeB();
            LoadAllAteliers();
        }

        private void BTAnnuler_Click(object sender, RoutedEventArgs e)
        {
            ActionDemander = "";
            CacherGroupeB();

        }

        private void Expander_MouseDown(object sender, MouseButtonEventArgs e)
        {

            FocusManager.SetFocusedElement(this, TBFiltres);
        }

        private void DataGridAgents_MouseUp(object sender, MouseButtonEventArgs e)
        {

            object item = DataGridAtelier.SelectedItem;
            try
            {
                TBId.Text = (DataGridAtelier.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                TBNom.Text = (DataGridAtelier.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBDescription.Text = (DataGridAtelier.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBSpecialite.Text = (DataGridAtelier.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                }
            catch (Exception exp)
            {
            }
        }

        private void TBFiltres_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                LoadAllAteliers();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: LoadAllAteliers("nom", TBFiltres.Text); break;
                    case 1: LoadAllAteliers("adresse", TBFiltres.Text); break;
                    case 2: LoadAllAteliers("description", TBFiltres.Text); break;
                    case 3: LoadAllAteliers("specialite", TBFiltres.Text); break;
                }
            }
        }

        private void BTImprimer_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridAtelier, "Liste des ateliers");
        }



    }
}
