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
    /// Logique d'interaction pour SuiviDeProduction.xaml
    /// </summary>
    public partial class SuiviDeProduction : Window
    {
        String ActionDemander = "";
        int idCourant = 0;
        public SuiviDeProduction()
        {
            InitializeComponent();
        }
        public SuiviDeProduction(int id)
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

            object item = DataGridArticle.SelectedItem;
            try
            {

                TBId.Text = (DataGridArticle.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                if (!TBId.Text.Equals(""))
                {
                    int idSuivi = SuiviBonProdC.GetIdFromIdBon(TBId.Text);
                    if(idSuivi>=1)
                    {
                        int suivi = SuiviBonProdC.GetSuivi(idSuivi);
                        BPourcentage.Value = suivi;
                        LabelVisionneVal.Content = suivi + " %";
                        if(BPourcentage.Value == 100)
                        {
                            Add.IsEnabled = false;
                            Remove.IsEnabled = false;
                            
                        }
                    }
                    else
                    {
                        BPourcentage.Value = 0;
                        Add.IsEnabled = true;
                        Remove.IsEnabled = true;
                        LabelVisionneVal.Content = "0 %";
                    }
                }
                TBIdArticle.Text = (DataGridArticle.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBIdAtelier.Text = (DataGridArticle.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBNbArticle.Text = (DataGridArticle.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                TBDateDepart.Text = (DataGridArticle.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                TBDateFin.Text = (DataGridArticle.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                TBCout.Text = (DataGridArticle.SelectedCells[6].Column.GetCellContent(item) as TextBlock).Text;
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
            //BTAjouter.Visibility = Visibility.Visible;
            BTModifier.Visibility = Visibility.Visible;
            BTSupprimer.Visibility = Visibility.Visible;
            BTConfirmer.Visibility = Visibility.Hidden;
            BTAnnuler.Visibility = Visibility.Hidden;
        }

        private void LoadAllBon()
        {
            List<BonProduction> reader = BonProductionC.GetAllFactures();
            DataGridArticle.ItemsSource = null;
            DataGridArticle.ItemsSource = reader;

        }
        private void LoadAllBon(String champ, String texte)
        {
            List<BonProduction> reader = BonProductionC.GetAllFactures();
            DataGridArticle.ItemsSource = null;
            DataGridArticle.ItemsSource = reader;

        }
        private void BTModifier_Click(object sender, RoutedEventArgs e)
        {
            if (ChampVide())
            {
                Afficher_Msg_Erreur("Erreur : Champ(s) vide(s) ");
            }
            else
            {

                ActionDemander = "Progression";
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
                ActionDemander = "Livraison";
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
                    fsg_gpao.Acteurs.BonProduction articlex = new fsg_gpao.Acteurs.BonProduction(Int16.Parse(solId), Int16.Parse(TBIdArticle.Text), Int16.Parse(TBIdAtelier.Text), Int16.Parse(TBNbArticle.Text), TBDateDepart.Text, TBDateFin.Text, Int16.Parse(TBCout.Text));

                    if (ActionDemander.Equals("Démarrer"))
                    {
                        if (!TBId.Text.Equals(""))
                        {
                            DateTime localDat = DateTime.Now;
                            articlex.DATEDEPART = localDat.ToString("F");
                            int res = fsg_gpao.Connecteurs.BonProductionC.ModifierBon(articlex);
                            if (res == 1)
                            {
                                Afficher_Msg_Confirmation("Enregistrement de la date de départ est bien modifier");
                                DateTime localDate = DateTime.Now;
                                fsg_gpao.Connecteurs.JournalArticleC.ajouterJournal(new JournalArticle(this.idCourant, articlex.ID, localDate.ToString("F"), "Modification de : " + articlex.ID + " " + articlex.IDARTICLE + "", ""));
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
                        if (ActionDemander.Equals("Livraison"))
                        {
                            if (!TBId.Text.Equals(""))
                            {
                                if(BPourcentage.Value!=100)
                                {
                                    Afficher_Msg_Erreur("la progression de production n'est pas aboutie");
                                }
                                else
                                {
                                    DateTime localDat = DateTime.Now;
                                    articlex.DATEFIN = localDat.ToString("F");

                                    int res = fsg_gpao.Connecteurs.BonProductionC.ModifierBon(articlex);
                                    if (res == 1)
                                    {
                                        Afficher_Msg_Confirmation("Enregistrement de la date de laivrison est bien modifier");
                                        DateTime localDate = DateTime.Now;
                                        fsg_gpao.Connecteurs.JournalArticleC.ajouterJournal(new JournalArticle(this.idCourant, articlex.ID, localDate.ToString("F"), "Modification de : " + articlex.ID + " " + articlex.IDARTICLE + "", ""));
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
                            CacherGroupeB();
                            LoadAllBon();
                        }
                        else
                        {
                            if (ActionDemander.Equals("Progression"))
                            {
                                if (!TBId.Text.Equals(""))
                                {
                                    List<SuiviBonProd> lsbon = SuiviBonProdC.GetAllSuiviBonProd("idbon", TBId.Text);
                                    SuiviBonProd atemp = new SuiviBonProd();
                                    if(lsbon.Count!=0)
                                    {
                                        atemp = lsbon.ElementAt(0);
                                    }

                                    int res = fsg_gpao.Connecteurs.SuiviBonProdC.ModifierSuiviBonProd(new SuiviBonProd(0,Int16.Parse(TBId.Text),BPourcentage.Value+""));
                                    if (res == 1)
                                    {
                                        Afficher_Msg_Confirmation("Enregistrement de la progression est bien accomplit");
                                        DateTime localDate = DateTime.Now;
                                        fsg_gpao.Connecteurs.JournalArticleC.ajouterJournal(new JournalArticle(this.idCourant, articlex.ID, localDate.ToString("F"), "Modification de : " + articlex.ID + " " + articlex.IDARTICLE + "", ""));
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
                    case 0: LoadAllBon("idArticle", TBFiltres.Text); break;
                    case 1: LoadAllBon("idAtelier", TBFiltres.Text); break;
                    case 2: LoadAllBon("nbArticle", TBFiltres.Text); break;
                    case 3: LoadAllBon("cout", TBFiltres.Text); break;
                }
            }
        }

        private void Expander_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(this, TBFiltres);
        }
        private void progression()
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
            fsg_gpao.Acteurs.BonProduction articlex = new fsg_gpao.Acteurs.BonProduction(Int16.Parse(solId), Int16.Parse(TBIdArticle.Text), Int16.Parse(TBIdAtelier.Text), Int16.Parse(TBNbArticle.Text), TBDateDepart.Text, TBDateFin.Text, Int16.Parse(TBCout.Text));
            if (!TBId.Text.Equals(""))
            {
                int res = fsg_gpao.Connecteurs.SuiviBonProdC.ModifierStat(Int16.Parse(TBId.Text),BPourcentage.Value+"");
                if (res == 1)
                {
                    Afficher_Msg_Confirmation("Enregistrement de la progression est bien accomplit");
                    DateTime localDate = DateTime.Now;
                    fsg_gpao.Connecteurs.JournalArticleC.ajouterJournal(new JournalArticle(this.idCourant, articlex.ID, localDate.ToString("F"), "Modification de : " + articlex.ID + " " + articlex.IDARTICLE + "", ""));
                }
                else
                {
                    Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                }
            }

            else
            {
                Afficher_Msg_Erreur("Veuillez sélctionnez un bon");
            }
            CacherGroupeB();
            LoadAllBon();
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (!TBId.Text.Equals(""))
            {
                BPourcentage.Value -= 5;
                LabelVisionneVal.Content = BPourcentage.Value + " %";
                progression();
            }
            else
            {
                Afficher_Msg_Erreur("Vous devez selectionner un bon");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            if(!TBId.Text.Equals(""))
            {
                int idsuivi = SuiviBonProdC.GetIdFromIdBon(TBId.Text);
                BPourcentage.Value += 5;
                LabelVisionneVal.Content = BPourcentage.Value + " %";
                if(idsuivi == 0)
                {
                    if(SuiviBonProdC.AjouterSuiviBonProd(new SuiviBonProd(1,Int16.Parse(TBId.Text),BPourcentage.Value+"")) == 1)
                    {
                        BonProductionC.DemarrerProduction(Int16.Parse(TBId.Text));
                        Afficher_Msg_Confirmation("Demarrage de production et Enregistrement de progression");
                    }
                }
                else
                {

                    if(BPourcentage.Value!=100)
                    {
                        SuiviBonProdC.ModifierStat(idsuivi, BPourcentage.Value+"");
                        Afficher_Msg_Confirmation("Enregistrement de la progression est bien accomplit");
                    }
                    else
                    {
                        SuiviBonProdC.ModifierStat(idsuivi, BPourcentage.Value + "");
                        BonProductionC.Livraison(Int16.Parse(TBId.Text));
                        Afficher_Msg_Confirmation("Fin de production et Livraison");
                        int nbArticle = ArticleC.getQuantite(Int16.Parse(TBIdArticle.Text));
                        nbArticle += Int16.Parse(TBNbArticle.Text);
                        ArticleC.ModifierQuantiteArticle(Int16.Parse(TBIdArticle.Text), nbArticle);
                        Add.IsEnabled = false;
                        Remove.IsEnabled = false;
                    }
                }
            }
            else
            {
                Afficher_Msg_Erreur("Vous devez selectionner un bon");
            }
            
            LoadAllBon();
        }

        private void BTAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (ChampVide())
            {
                Afficher_Msg_Erreur("Erreur : Champ(s) vide(s) ");
            }
            else
            {

                ActionDemander = "Démarrer";
                CacherGroupeA();
            }
        }

        private void BTAjouter_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void BTAjouter_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void BTImprimer_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridArticle, "Suivi de production");
        }
    }
}
