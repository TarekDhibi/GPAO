using fsg_gpao.Acteurs;
using fsg_gpao.Connecteurs;
using fsg_gpao.Connexion_bd;
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
    /// Logique d'interaction pour AjouterBonProduction.xaml
    /// </summary>
    public partial class AjouterBonProduction : Window
    {
        int idCourant = 0;
        
        List<Atelier> ls = new List<Atelier>();
        List<String> lN = new List<String>();
        public AjouterBonProduction()
        {
            InitializeComponent();
        }
        public AjouterBonProduction(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            chargerNomAtelier();
            LoadAllArticles();
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
        private void LoadAllArticles()
        {
            List<Article> reader = ArticleC.GetAllArticles();
            DataGridArticle.ItemsSource = null;
            DataGridArticle.ItemsSource = reader;

        }
        private void LoadAllArticles(String champ, String texte)
        {
            List<Article> reader = ArticleC.GetAllArticlesLikeColonne(champ, texte);
            DataGridArticle.ItemsSource = null;
            DataGridArticle.ItemsSource = reader;

        }
        public bool ChampVide()
        {
            if (TBIdArticle.Text.Equals("") || TBIdAtelier.Text.Equals("") || TBNbArticle.Text.Equals("") || TBCout.Text.Equals(""))
            {
                return true;
            }
            return false;
        }
        private void chargerNomAtelier()
        {
            ls.Clear();
            ls = AtelierC.GetAllatelier();
            lN.Clear();
            for(int i = 0; i<ls.Count;i++)
            {
                lN.Add(ls.ElementAt(i).NOM);
            }
            CBAtelier.Items.Clear();
            for(int i=0;i<lN.Count;i++)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = lN.ElementAt(i);
                item.Value = i;
                CBAtelier.Items.Add(item);
            }
            CBAtelier.SelectedIndex = 0;

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
                Afficher_Msg_Erreur("Erreur : Champ(s) vide(s), veuillez vérifier les champs obligatoires et les contraintes ");
            }
            else
            {
                
                CacherGroupeA();
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
                BonProduction adminx = new BonProduction(0, Int16.Parse(TBIdArticle.Text), Int16.Parse(TBIdAtelier.Text), Int16.Parse(TBNbArticle.Text), TBDateDepart.Text, TBDateFin.Text,Int16.Parse(TBCout.Text));
               
                    int res = fsg_gpao.Connecteurs.BonProductionC.AjouterBon(adminx);
                    if (res == 1)
                    {
                        Afficher_Msg_Confirmation("Le bon est bien ajouter");
                        try
                        {
                            DateTime localDate = DateTime.Now;
                            fsg_gpao.Acteurs.JournalArticle journal = new fsg_gpao.Acteurs.JournalArticle(idCourant, adminx.ID, localDate.ToString("F"), "Création du nouveau bon de commande : " + adminx.ID,"");
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

                
                cacherGroupeB();
                }
                
        }
        private void cacherGroupeB()
        {
            BTAjouter.Visibility = Visibility.Visible;
            // BtModifier.Visibility = Visibility.Visible;
            //BtSupprimer.Visibility = Visibility.Visible;
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

     

        private void TBIdArticle_KeyUp(object sender, KeyEventArgs e)
        {
            TBIdArticle.Text = saisieEntier(sender);
            if(!TBIdArticle.Text.Equals(""))
            {
                if (ArticleC.IdExiste(TBIdArticle.Text) == 0)
                {
                    Afficher_Msg_Erreur("l'identifiant de l'article n'est pas reconnue");
               
                }
            }
            
        }

        private void TBIdAtelier_KeyUp(object sender, KeyEventArgs e)
        {
        
        }

        private void TBNbArticle_KeyUp(object sender, KeyEventArgs e)
        {
            TBNbArticle.Text = saisieEntier(sender);
            if (!TBNbArticle.Text.Equals(""))
            {
                if (Int16.Parse(TBNbArticle.Text) <= 0)
                {
                    Afficher_Msg_Erreur("Vous devez vérifier le nombre des articles");
                }
                
            }
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

        private void DataGridArticle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            object item = DataGridArticle.SelectedItem;
            try
            {
                TBIdArticle.Text = (DataGridArticle.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
               
            }
            catch (Exception exp)
            {
            }
        }

        private void TBFiltres_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                LoadAllArticles();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: LoadAllArticles("nom", TBFiltres.Text); break;
                    case 1: LoadAllArticles("cat", TBFiltres.Text); break;
                    case 2: LoadAllArticles("description", TBFiltres.Text); break;
                    case 3: LoadAllArticles("prix", TBFiltres.Text); break;
                }
            }
        }

        private void Expander_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CBAtelier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBIdAtelier.Text = ls.ElementAt(CBAtelier.SelectedIndex).ID +"";
        }

        private void TBCout_KeyUp(object sender, KeyEventArgs e)
        {
            TBCout.Text = saisieEntier(sender);
            if (!TBCout.Text.Equals(""))
            {
                if (Int16.Parse(TBCout.Text) <= 0)
                {
                    Afficher_Msg_Erreur("Vous devez vérifier le cout");
                }

            }
        }
    }
}
