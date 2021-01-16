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
    /// Logique d'interaction pour GererFournisseur.xaml
    /// </summary>
    public partial class GererFournisseur : Window
    {
        String ActionDemander = "";
        int idCourant = 0;
        public GererFournisseur()
        {
            InitializeComponent();
        }
        public GererFournisseur(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            LoadAllFournisseur();
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
            if (TBNom.Text.Equals("") || TBTel.Text.Equals("") )
            {
                return true;
            }
            return false;
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
        private void DataGridArticle_MouseUp(object sender, MouseButtonEventArgs e)
        {

            object item = DataGridFournisseur.SelectedItem;
            try
            {
                TBId.Text = (DataGridFournisseur.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                TBNom.Text = (DataGridFournisseur.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBTel.Text = (DataGridFournisseur.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBAdresse.Text = (DataGridFournisseur.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                TBSpecialite.Text = (DataGridFournisseur.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                CBEtat.IsChecked = (DataGridFournisseur.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text.Equals("True");
            }
            catch (Exception exp)
            {
            }
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

        private void LoadAllFournisseur()
        {
            List<Fournisseur> reader = FournisseurC.GetAllFournisseur();
            DataGridFournisseur.ItemsSource = null;
            DataGridFournisseur.ItemsSource = reader;

        }
        private void LoadAllFournisseur(String champ, String texte)
        {
            List<Fournisseur> reader = FournisseurC.GetAllFournisseurLikeColonne(champ, texte);
            DataGridFournisseur.ItemsSource = null;
            DataGridFournisseur.ItemsSource = reader;
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

        private void BTSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (TBId.Text.Equals(""))
            {
                Afficher_Msg_Erreur("Erreur : Vous devez selectionnez un fournisseur ");

            }
            else
            {
                ActionDemander = "Supprimer";
                CacherGroupeA();
            }
        }

        private void BTAnnuler_Click(object sender, RoutedEventArgs e)
        {
            ActionDemander = "";
            CacherGroupeB();

        }

        private void BTConfirmer_Click(object sender, RoutedEventArgs e)
        {
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
                    fsg_gpao.Acteurs.Fournisseur articlex = new fsg_gpao.Acteurs.Fournisseur(Int16.Parse(solId), TBNom.Text, TBTel.Text, TBAdresse.Text, TBSpecialite.Text, CBEtat.IsChecked.Value);

                    if (ActionDemander.Equals("Modifier"))
                    {
                        if (!TBId.Text.Equals(""))
                        {
                            int res = fsg_gpao.Connecteurs.FournisseurC.ModifierFournisseur(articlex);
                            if (res == 1)
                            {
                                Afficher_Msg_Confirmation("Le fournisseur est bien modifier");
                                DateTime localDate = DateTime.Now;
                                fsg_gpao.Connecteurs.JournalArticleC.ajouterJournal(new JournalArticle(this.idCourant,articlex.ID, localDate.ToString("F"), "Modification de : " + articlex.NOM + " " + articlex.SPECIALITE +"",""));
                            }
                            else
                            {
                                Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                            }
                        }

                        else
                        {
                            Afficher_Msg_Erreur("Veuillez sélectionnez un fournisseur");
                        }
                        CacherGroupeB();
                        LoadAllFournisseur();
                    }
                    else
                    {
                        if (ActionDemander.Equals("Supprimer"))
                        {
                            if (!TBId.Text.Equals(""))
                            {
                                if (fsg_gpao.Connecteurs.FournisseurC.IdExisteJournal(Int16.Parse(TBId.Text)) == -1)
                                {
                                    Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                                }
                                else
                                {
                                    if (fsg_gpao.Connecteurs.FournisseurC.IdExisteJournal(Int16.Parse(TBId.Text)) != 0)
                                    {
                                        Afficher_Msg_Erreur("Impossible de supprimer ce fournisseur, il a réalisé un/des tache(s) dans le journal.");
                                    }
                                    else
                                    {
                                        int res = fsg_gpao.Connecteurs.FournisseurC.SupprimerFournisseur(articlex.ID);
                                        if (res == 1)
                                        {
                                            Afficher_Msg_Confirmation("Le fournisseur est bien supprimer");
                                            DateTime localDate = DateTime.Now;
                                            fsg_gpao.Connecteurs.JournalArticleC.ajouterJournal(new JournalArticle(this.idCourant, articlex.ID, localDate.ToString("F"), "Supprission de : " + articlex.NOM + " " + articlex.SPECIALITE + "", ""));
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
                                Afficher_Msg_Erreur("Veuillez sélctionnez un fournisseur");
                            }
                        }
                    }
                }
                CacherGroupeB();
                LoadAllFournisseur();
            }
        }

        private void TBFiltres_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                LoadAllFournisseur();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: LoadAllFournisseur("nom", TBFiltres.Text); break;
                    case 1: LoadAllFournisseur("tel", TBFiltres.Text); break;
                    case 2: LoadAllFournisseur("adresse", TBFiltres.Text); break;
                    case 3: LoadAllFournisseur("specialite", TBFiltres.Text); break;
                }
            }
        }

        private void Expander_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(this, TBFiltres);
        }

        private void BTImprimer_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridFournisseur, "Liste des fournisseurs");
        }
    }
}
