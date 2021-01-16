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
using fsg_gpao.Interfaces;

namespace fsg_gpao.Interfaces
{
    /// <summary>
    /// Logique d'interaction pour GesAgents2.xaml
    /// </summary>
    public partial class GestionClient : Window
    {
        profile prod = new profile();
        private string ActionDemander ="";
        int idCourant = 0;

        public GestionClient()
        {
            InitializeComponent();
            LoadAllClients();
        }
        public GestionClient(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            LoadAllClients();
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
            if (TBNom.Text.Equals("") || TBAdresse.Text.Equals("") || TBTel.Text.Equals(""))
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


        private void LoadAllClients()
        {
            List<Client> reader = ClientC.GetAllClient() ;
            DataGridClient.ItemsSource = null;
            DataGridClient.ItemsSource = reader;

        }
        private void LoadAllClients(String champ, String texte)
        {
            List<Client> reader = ClientC.GetAllClient(champ, texte);
            DataGridClient.ItemsSource = null;
            DataGridClient.ItemsSource = reader;
        }

        //private void LoadAllProfiles(String colonne, string cher)
        //{
        //    List<profile> reader = profilC.GetAllProfilesLikeColonne(colonne,cher);
        //    DataGridAgents.ItemsSource = null; 
        //    DataGridAgents.ItemsSource = reader;

        //}

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
                fsg_gpao.Acteurs.Client clientx = new fsg_gpao.Acteurs.Client(Int16.Parse(solId), TBNom.Text, TBAdresse.Text, TBTel.Text, CBRemarque.Text, CHEtat.IsChecked.Value);
                if(!TBId.Text.Equals("1"))
                {

                if (ActionDemander.Equals("Modifier"))
                {
                    if (!TBId.Text.Equals(""))
                    {
                        int res = fsg_gpao.Connecteurs.ClientC.ModifierClient(clientx);
                                if (res == 1)
                                {
                                    Afficher_Msg_Confirmation("Le client est bien modifier");
                                    DateTime localDate = DateTime.Now;
                                    fsg_gpao.Connecteurs.journalVenteC.ajouterJournal(new fsg_gpao.Acteurs.JournalVente(this.idCourant, clientx.ID, localDate.ToString("F"), "Modification de : " + clientx.NOM,""));
                                }
                                else
                                {
                                    Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                                }
                    }
                    else
                    {
                        Afficher_Msg_Erreur("Veuillez sélctionnez un client");
                    }
                    CacherGroupeB();
                    LoadAllClients();
                }
                else
                {
                    if (ActionDemander.Equals("Supprimer"))
                    {
                        if (!TBId.Text.Equals(""))
                        {
                                if (fsg_gpao.Connecteurs.ClientC.IdExisteJournal(Int16.Parse(TBId.Text)) != 0)
                                {
                                    Afficher_Msg_Erreur("Impossible de supprimer ce client, il a réalisé un/des tache(s) dans le journal.");
                                }
                                else
                                {
                                    int res = fsg_gpao.Connecteurs.ClientC.SupprimerClient(clientx.ID);
                                    if (res == 1)
                                    {
                                        Afficher_Msg_Confirmation("Le client est bien supprimer");
                                        DateTime localDate = DateTime.Now;
                                        fsg_gpao.Connecteurs.journalVenteC.ajouterJournal(new fsg_gpao.Acteurs.JournalVente(this.idCourant, clientx.ID, localDate.ToString("F"), "Supprision de : " + clientx.NOM, ""));
                                    }
                                    else
                                    {
                                        Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                                    }
                                }
                        }
                        else
                        {
                            Afficher_Msg_Erreur("Veuillez sélctionnez un CLient");
                        }
                    }
                }
            }
                else
                {
                    Afficher_Msg_Erreur("Cet enregistrement est integré dans le système");
                }
            }
            CacherGroupeB();
            LoadAllClients();
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

            object item = DataGridClient.SelectedItem;
            try
            {
                TBId.Text = (DataGridClient.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                TBNom.Text = (DataGridClient.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBAdresse.Text = (DataGridClient.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBTel.Text = (DataGridClient.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                CBRemarque.Text = (DataGridClient.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                CHEtat.IsChecked = (DataGridClient.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text.Equals("True");
            }
            catch (Exception exp)
            {
            }
        }

        private void DataGridAgents_MouseUp_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void TBFiltres_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                LoadAllClients();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: LoadAllClients("nom", TBFiltres.Text); break;
                    case 1: LoadAllClients("adresse", TBFiltres.Text); break;
                    case 2: LoadAllClients("tel", TBFiltres.Text); break;
                    case 3: LoadAllClients("remarque", TBFiltres.Text); break;
                }
            }
        }

        private void TBFiltres_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                LoadAllClients();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: LoadAllClients("nom", TBFiltres.Text); break;
                    case 1: LoadAllClients("adresse", TBFiltres.Text); break;
                    case 2: LoadAllClients("tel", TBFiltres.Text); break;
                    case 3: LoadAllClients("remarque", TBFiltres.Text); break;
                }
            }
        }

        private void btnImprimer_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridClient, "Liste des clients");

        }



    }
}
