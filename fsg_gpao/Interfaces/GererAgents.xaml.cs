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
using System.Net.Mail;

namespace fsg_gpao.Interfaces
{
    /// <summary>
    /// Logique d'interaction pour GererAgents.xaml
    /// </summary>
    public partial class GererAgents : Window
    {
        profile prod = new profile();
        private string ActionDemander = "";
        int idCourant = 0;

        public GererAgents()
        {
            InitializeComponent();
            LoadAllProfiles();

        }
        public GererAgents(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            LoadAllProfiles();
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
            if (TBLogin.Text.Equals("") || TBMotdepasse.Text.Equals("") || TBEmail.Text.Equals(""))
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


        private void LoadAllProfiles()
        {
            List<profile> reader = profilC.GetAllProfiles();
            DataGridAgents.ItemsSource = null;
            DataGridAgents.ItemsSource = reader;

        }
        private void LoadAllProfiles(String champ, String texte)
        {
            List<profile> reader = profilC.GetAllProfiles(champ, texte);
            DataGridAgents.ItemsSource = null;
            DataGridAgents.ItemsSource = reader;

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
                fsg_gpao.Acteurs.profile adminx = new fsg_gpao.Acteurs.profile(Int16.Parse(solId), TBLogin.Text, TBMotdepasse.Text, TBEmail.Text, CBService.Text, CHEtat.IsChecked.Value);
                //MessageBox.Show(" "+CHEtat.IsChecked.Value);

                if (ActionDemander.Equals("Modifier"))
                {
                    if (!TBId.Text.Equals(""))
                    {
                        if (fsg_gpao.Connecteurs.profilC.LogExiste(TBLogin.Text, Int16.Parse(TBId.Text)) == -1)
                        {
                            Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                        }
                        else
                        {
                            if (fsg_gpao.Connecteurs.profilC.LogExiste(TBLogin.Text, Int16.Parse(TBId.Text)) != 0)
                            {
                                Afficher_Msg_Erreur("Ce login est déja utilisé.");
                            }
                            else
                            {
                                if (!IsValidEmail(TBEmail.Text))
                   
                                {
                                     Afficher_Msg_Erreur("Erreur : E-mail invalide");
                                }
                            else
                            {
                                int res = fsg_gpao.Connecteurs.profilC.ModifierProfile(adminx);
                                if (res == 1)
                                {
                                    Afficher_Msg_Confirmation("L'administrateur est bien modifier");
                                    DateTime localDate = DateTime.Now;
                                    fsg_gpao.Acteurs.JournalP journal = new fsg_gpao.Acteurs.JournalP(this.prod.ID, localDate.ToString("F"), "Modification de : " + adminx.SERVICE + " " + adminx.LOGIN, "");
                                    fsg_gpao.Connecteurs.JournalPC.ajouterJournal(journal);
                                }
                                else
                                {
                                    Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                                }
                            }
                        }
                        }
                    }
                    else
                    {
                        Afficher_Msg_Erreur("Veuillez sélctionnez un Adminitrateur");
                    }
                    CacherGroupeB();
                    LoadAllProfiles();
                }
                else
                {
                    if (ActionDemander.Equals("Supprimer"))
                    {
                        if (!TBId.Text.Equals(""))
                        {
                            if (fsg_gpao.Connecteurs.profilC.IdExisteJournal(Int16.Parse(TBId.Text)) == -1)
                            {
                                Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                            }
                            else
                            {
                                if (fsg_gpao.Connecteurs.profilC.IdExisteJournal(Int16.Parse(TBId.Text)) != 0)
                                {
                                    Afficher_Msg_Erreur("Impossible de supprimer cet utilisateur, il a réalisé un/des tache(s) dans le journal.");
                                }
                                else
                                {
                                    int res = fsg_gpao.Connecteurs.profilC.SupprimerProfile(adminx.ID);
                                    if (res == 1)
                                    {
                                        Afficher_Msg_Confirmation("Le profil est bien supprimer");
                                        DateTime localDate = DateTime.Now;
                                        fsg_gpao.Acteurs.JournalP journal = new fsg_gpao.Acteurs.JournalP(this.prod.ID, localDate.ToString("F"), "supprission de : " + adminx.SERVICE + " " + adminx.LOGIN, "");
                                        fsg_gpao.Connecteurs.JournalPC.ajouterJournal(journal);
                                    }
                                    else
                                    {
                                        Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                                    }
                                }
                            }
                        }
                        else
                        {
                            Afficher_Msg_Erreur("Veuillez sélctionnez un Adminitrateur");
                        }
                    }
                }
            }
            CacherGroupeB();
            LoadAllProfiles();
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

            object item = DataGridAgents.SelectedItem;
            try
            {
                TBId.Text = (DataGridAgents.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                TBLogin.Text = (DataGridAgents.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBMotdepasse.Text = (DataGridAgents.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBEmail.Text = (DataGridAgents.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                String s = (DataGridAgents.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                switch (s)
                {
                    case "Administrateur": CBService.SelectedIndex = 0; break;
                    case "Agent Commercial": CBService.SelectedIndex = 1; break;
                    case "Agent de production": CBService.SelectedIndex = 2; break;
                }
                CHEtat.IsChecked = (DataGridAgents.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text.Equals("True");
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
                LoadAllProfiles();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: LoadAllProfiles("login", TBFiltres.Text); break;
                    case 1: LoadAllProfiles("mail", TBFiltres.Text); break;
                    case 2: LoadAllProfiles("service", TBFiltres.Text); break;
                    case 3: LoadAllProfiles("etat", TBFiltres.Text); break;
                }
            }
        }

        private void TBFiltres_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                LoadAllProfiles();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: LoadAllProfiles("login", TBFiltres.Text); break;
                    case 1: LoadAllProfiles("mail", TBFiltres.Text); break;
                    case 2: LoadAllProfiles("role", TBFiltres.Text); break;
                    case 3: LoadAllProfiles("etat", TBFiltres.Text); break;
                }
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                MailAddress addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

    }

}
