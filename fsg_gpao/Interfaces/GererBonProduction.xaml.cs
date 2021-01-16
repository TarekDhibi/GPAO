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
    /// Logique d'interaction pour GererBonProduction.xaml
    /// </summary>
    public partial class GererBonProduction : Window
    {
        String ActionDemander = "";
        int idCourant = 0;
        public GererBonProduction()
        {
            InitializeComponent();
        }
        public GererBonProduction(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            LoadAllBon();
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
            if (TBIdArticle.Text.Equals("") || TBIdAtelier.Text.Equals("") || TBIdAtelier.Text.Equals(""))
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

            object item = DataGridBon.SelectedItem;
            try
            {
                TBId.Text = (DataGridBon.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                TBIdArticle.Text = (DataGridBon.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBIdAtelier.Text = (DataGridBon.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBNbArticle.Text = (DataGridBon.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                TBDateDepart.Text = (DataGridBon.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                TBDateFin.Text = (DataGridBon.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                TBCout.Text = (DataGridBon.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
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

        private String saisieEntier(object sender)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;
            String newText = String.Empty;
            int count = 0;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c) || (c == '.' && count == 0))
                {
                    newText += c;
                    if (c == '.')
                        count += 1;
                }
            }
            textBox.SelectionStart = selectionStart <= textBox.Text.Length ? selectionStart : textBox.Text.Length;
            return newText;
        }

        private void LoadAllBon()
        {
            List<BonProduction> reader = BonProductionC.GetAllFactures();
            DataGridBon.ItemsSource = null;
            DataGridBon.ItemsSource = reader;

        }
        private void LoadAllArticles(String champ, String texte)
        {
            List<BonProduction> reader = BonProductionC.GetAllFacturelikecolonne(champ, texte);
            DataGridBon.ItemsSource = null;
            DataGridBon.ItemsSource = reader;

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
                Afficher_Msg_Erreur("Erreur : Vous devez selectionnez un agent ");

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
                    if (ArticleC.IdExiste(TBIdArticle.Text) == 0)
                    {
                        Afficher_Msg_Erreur("l'identifiant de l'article n'est pas reconnue");

                    }
                else
                {
                    if (AtelierC.IdExiste(TBIdAtelier.Text) == 0)
                    {
                        Afficher_Msg_Erreur("l'identifiant de l'atelier n'est pas reconnue");

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
                    fsg_gpao.Acteurs.BonProduction bon = new fsg_gpao.Acteurs.BonProduction(Int16.Parse(solId), Int16.Parse(TBIdArticle.Text), Int16.Parse(TBIdAtelier.Text), Int16.Parse(TBNbArticle.Text), TBDateDepart.Text, TBDateFin.Text, Int16.Parse(TBCout.Text));

                    if (ActionDemander.Equals("Modifier"))
                    {
      
                        if (!TBId.Text.Equals(""))
                        {
                            
                            int res = fsg_gpao.Connecteurs.BonProductionC.ModifierBon(bon);
                            if (res == 1)
                            {
                                Afficher_Msg_Confirmation("Le bon est bien modifier");
                                DateTime localDate = DateTime.Now;
                                fsg_gpao.Connecteurs.JournalArticleC.ajouterJournal(new JournalArticle(this.idCourant, bon.ID, localDate.ToString("F"), "Modification de : " + bon.ID + " " + bon.IDARTICLE + "", ""));
                            }
                            else
                            {
                                Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                            }
                        }

                        else
                        {
                            Afficher_Msg_Erreur("Veuillez sélctionnez un Adminitrateur");
                        }
                        CacherGroupeB();
                        LoadAllBon();
                    }
                    else
                    {
                        if (ActionDemander.Equals("Supprimer"))
                        {
                            if (!TBId.Text.Equals(""))
                            {
                                int res = fsg_gpao.Connecteurs.BonProductionC.SupprimerClasseur(bon.ID);
                                if (res == 1)
                                {
                                    Afficher_Msg_Confirmation("Le bon est bien supprimer");
                                    DateTime localDate = DateTime.Now;
                                    fsg_gpao.Connecteurs.JournalArticleC.ajouterJournal(new JournalArticle(this.idCourant, bon.ID, localDate.ToString("F"), "Supprission de : " + bon.ID + " " + bon.IDARTICLE + "", ""));
                                }
                                else
                                {
                                    Afficher_Msg_Erreur("Erreur de connexion à la base de données");
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
            }
                CacherGroupeB();
                LoadAllBon();
            }
        }

        private void TBFiltres_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                LoadAllBon();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: LoadAllArticles("idArticle", TBFiltres.Text); break;
                    case 1: LoadAllArticles("idAtelier", TBFiltres.Text); break;
                    case 2: LoadAllArticles("nbArticle", TBFiltres.Text); break;
                    case 3: LoadAllArticles("cout", TBFiltres.Text); break;
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
            printDlg.PrintVisual(DataGridBon, "Liste des bons de productions");
        }

        private void TBIdArticle_KeyUp(object sender, KeyEventArgs e)
        {
            TBIdArticle.Text = saisieEntier(sender);
        }

        private void TBIdAtelier_KeyUp(object sender, KeyEventArgs e)
        {
            TBIdAtelier.Text = saisieEntier(sender);
        }
    }
}
