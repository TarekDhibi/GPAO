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
    /// Logique d'interaction pour GererAchat.xaml
    /// </summary>
    public partial class GererAchat : Window
    {
        int idCourant = 0;
        int classeurCourant = 0;
        String ActionDemander = "";
        public GererAchat()
        {
            InitializeComponent();
        }
        public GererAchat(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            loadAllClasseur();
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

        private void loadAllClasseur()
        {
            List<ClasseurAchat> l = Connecteurs.ClasseurAchatC.GetAllClasseurAchat();
            DataGridClasseur.ItemsSource = l;
        }
        private void loadAllClasseur(String champ, String valeur)
        {
            List<ClasseurAchat> l = Connecteurs.ClasseurAchatC.GetAllClasseurAchat(champ, valeur);
            DataGridClasseur.ItemsSource = l;
        }
        private void loadAllAchat()
        {
            List<Achat> l = Connecteurs.AchatC.GetAllAchat(classeurCourant);
            DataGridAchat.ItemsSource = l;
        }
        private void loadAllAchat(String champ, String valeur)
        {
            List<Achat> l = Connecteurs.AchatC.GetAllAchat(classeurCourant, champ, valeur);
            DataGridAchat.ItemsSource = l;
        }

        private void TBFiltres_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                loadAllClasseur();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: loadAllClasseur("idAdmin", TBFiltres.Text); break;
                    case 1: loadAllClasseur("idFournisseur", TBFiltres.Text); break;
                    case 2: loadAllClasseur("heure", TBFiltres.Text); break;
                }
            }
        }

        private void Expander_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(this, TBFiltres);
        }

        private void DataGridArticle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            loadAchatDG();
        }
        private void loadAchatDG()
        {
            object item = DataGridClasseur.SelectedItem;
            try
            {
                classeurCourant = Int16.Parse((DataGridClasseur.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                loadAllAchat();
            }
            catch (Exception exp)
            {
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

        private void BTConfirmer_Click(object sender, RoutedEventArgs e)
        {
            if(!ChampVide())
            {
                if(ProduitC.IdExiste(TBIdArticle.Text) == 0)
                {
                    Afficher_Msg_Erreur("Erreur : Id Produit n'est pas reconue");
                }
                else
                {
                    if(ActionDemander.Equals("Modifier"))
                    {
                        object itemC = DataGridClasseur.SelectedItem;
                        int idc = (Int16.Parse((DataGridClasseur.SelectedCells[0].Column.GetCellContent(itemC) as TextBlock).Text));
                        object item = DataGridAchat.SelectedItem;
                        int idcour = Int16.Parse((DataGridAchat.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
                        if((idc==null) || (idcour==null))
                        {
                            Afficher_Msg_Erreur("Erreur : Vous devez selectionner un classeur et un achat");
                        }
                        else
                        {
                            Produits achat = ProduitC.GetProduit(idcour);
                            int nbAncien = Int16.Parse((DataGridAchat.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
                            achat.QUANTITE -= nbAncien;
                            achat.QUANTITE += Int16.Parse(TBNombre.Text);
                            ProduitC.ModifierProduits(achat);
                            AchatC.ModifierAchat(new Achat(Int16.Parse((DataGridAchat.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text), idc, Int16.Parse(TBIdArticle.Text), Int16.Parse(TBNombre.Text), Int16.Parse(TBPrix.Text), Int16.Parse(TBRemise.Text)));
                            int idfourn = Int16.Parse((DataGridAchat.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                            Afficher_Msg_Confirmation("la vente est bien modifié");
                            loadAchatDG();
                            DateTime localDate = DateTime.Now;
                              JournalAchat journal =  new fsg_gpao.Acteurs.JournalAchat(1,this.idCourant,idfourn , localDate.ToString("F"), "Modification","");
                            fsg_gpao.Connecteurs.JournalAchatC.ajouterJournal(journal);

                        }
                    }
                    else
                    {
                        if (ActionDemander.Equals("Supprimer"))
                        {
                            if (DataGridAchat.Items.Count > 1)
                            {
                                object item = DataGridAchat.SelectedItem;
                                AchatC.SupprimerAchat(Int16.Parse((DataGridAchat.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
                                Produits aa = ProduitC.GetProduit(Int16.Parse((DataGridAchat.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text));
                                aa.QUANTITE -= Int16.Parse(TBNombre.Text);
                                MessageBox.Show("Ancien : " + aa.QUANTITE + "supprimer : " +TBNombre.Text);
                                ProduitC.ModifierProduits(aa);
                                Afficher_Msg_Confirmation("l'achat est bien Supprimé");
                                loadAchatDG();
                                DateTime localDate = DateTime.Now;
                                fsg_gpao.Connecteurs.JournalProdC.ajouterJournal(new fsg_gpao.Acteurs.JournalProd(1, this.idCourant, aa.ID, localDate.ToString("F"),"Suppression", ""));
                                int idprod = Int16.Parse((DataGridAchat.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
                                JournalAchat journal = new fsg_gpao.Acteurs.JournalAchat(1, this.idCourant, idprod, localDate.ToString("F"), "Suppression", "");
                                fsg_gpao.Connecteurs.JournalAchatC.ajouterJournal(journal);
                            }
                            else
                            {
                                object item = DataGridAchat.SelectedItem;
                                AchatC.SupprimerAchat(Int16.Parse((DataGridAchat.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text));
                                object itemC = DataGridClasseur.SelectedItem;
                                ClasseurAchatC.SupprimerClasseurAchat(Int16.Parse((DataGridClasseur.SelectedCells[0].Column.GetCellContent(itemC) as TextBlock).Text));
                                Produits aa = ProduitC.GetProduit(Int16.Parse((DataGridAchat.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text));
                                int nbAncien = Int16.Parse((DataGridAchat.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text);
                                aa.QUANTITE -= nbAncien;
                                ProduitC.ModifierProduits(aa);
                                Afficher_Msg_Confirmation("l'achat et le classeur sont bien Supprimés");
                                loadAllClasseur();
                                DataGridAchat.ItemsSource = null;
                                DateTime localDate = DateTime.Now;
                                int idprod = Int16.Parse((DataGridAchat.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text);
                                JournalAchat journal = new fsg_gpao.Acteurs.JournalAchat(1, this.idCourant, idprod, localDate.ToString("F"), "Suppression", "");
                                fsg_gpao.Connecteurs.JournalAchatC.ajouterJournal(journal);
                            }
                        }
                    }
                }
            }
            else
            {
                Afficher_Msg_Erreur("Erreur : champ(s) vide(s)");
            }
        }

        private void BTAnnuler_Click(object sender, RoutedEventArgs e)
        {
            ActionDemander = "";
            CacherGroupeB();
        }
        public bool ChampVide()
        {
            if (TBIdArticle.Text.Equals("") || TBNombre.Text.Equals("") || TBPrix.Text.Equals("") || TBRemise.Text.Equals(""))
            {
                return true;
            }
            return false;
        }
        private void BTModifier_Click(object sender, RoutedEventArgs e)
        {
            if(ChampVide())
            {
                Afficher_Msg_Erreur("Erreur : champ(s) vide(s)");
            }
            else
            {
                ActionDemander = "Modifier";
                CacherGroupeA();
            }
        }

        private void BTSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (ChampVide())
            {
                Afficher_Msg_Erreur("Erreur : champ(s) vide(s)");
            }
            else
            {
                ActionDemander = "Supprimer";
                CacherGroupeA();
            }
        }

        private void DataGridVente_MouseUp(object sender, MouseButtonEventArgs e)
        {
            object item = DataGridAchat.SelectedItem;
            try
            {
                TBIdArticle.Text = (DataGridAchat.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBNombre.Text = (DataGridAchat.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBPrix.Text = (DataGridAchat.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                TBRemise.Text = (DataGridAchat.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception exp)
            {
            }
        }

        private void TBIdArticle_KeyUp(object sender, KeyEventArgs e)
        {
            TBIdArticle.Text = getInt(sender, e);
            
        }
        private String getInt(object sender, KeyEventArgs e)
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
            return newText;
        }

        private void TBNombre_KeyUp(object sender, KeyEventArgs e)
        {
            TBNombre.Text = getInt(sender, e);
            if (TBIdArticle.Text.Equals(""))
            {
                Afficher_Msg_Erreur("Erreur : vous devez selectionner un article");
            }
            else
            {
                if (ProduitC.IdExiste(TBIdArticle.Text) == 0)
                {
                    Afficher_Msg_Erreur("Erreur : l'identifiant de ce produit n'est pas reconnu");
                }
                else
                {
                    try { 
                    Produits atemp = ProduitC.GetProduit(Int16.Parse(TBIdArticle.Text));
                    int a = Int16.Parse(TBNombre.Text) * Int16.Parse(atemp.PRIX.ToString());
                    TBPrix.Text = "" + a;
                        }
                    catch(Exception ex)
                    { }
                }
            }
        }

        private void TBPrix_KeyUp(object sender, KeyEventArgs e)
        {
            TBPrix.Text = getInt(sender, e);
        }

        private void TBRemise_KeyUp(object sender, KeyEventArgs e)
        {
            TBRemise.Text = getInt(sender, e);
        }

        private void BTImprimer_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridAchat, "Liste des achats");
        }

    }
}
