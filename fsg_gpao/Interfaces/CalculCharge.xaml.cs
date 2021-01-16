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
    /// Logique d'interaction pour CalculCharge.xaml
    /// </summary>
    public partial class CalculCharge : Window
    {
        int idCourant = 0, idc = 0;
       
        String actionDemander = "";
        private String actionAccomplit = "";
        List<ClasseurProduit> listeClasseurProduit = new List<ClasseurProduit>();
        public CalculCharge()
        {
            InitializeComponent();
        }
        public CalculCharge(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            LoadAllProduits();
            LoadAllBon();
            idc = ClasseurVenteC.GetNexId() + 1;
        }
        private void LoadAllBon()
        {
            List<BonProduction> reader = BonProductionC.GetAllFactures();
            DataGridBonProd.ItemsSource = null;
            DataGridBonProd.ItemsSource = reader;

        }
        private void LoadAllBon(String champ, String texte)
        {
            List<BonProduction> reader = BonProductionC.GetAllFactures();
            DataGridBonProd.ItemsSource = null;
            DataGridBonProd.ItemsSource = reader;

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
            if (TBId.Equals("") || TBQuantite.Equals("") || TBNom.Equals("") || actionAccomplit.Equals(""))
            {
                return true;
            }
            return false;
        }
        public void Afficher_Msg_Erreur(string msgg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#ff6666");
            AfficherMsg.Foreground = new SolidColorBrush(couleur);
            AfficherMsg.Content = msgg;
        }

        public void Afficher_Msg_Confirmation(string msgg)
        {
            var couleur = (Color)ColorConverter.ConvertFromString("#32CD32");
            AfficherMsg.Foreground = new SolidColorBrush(couleur);
            AfficherMsg.Content = msgg;
        }

        public void CacherGroupeA()
        {
            BTAjouter.Visibility = Visibility.Hidden;
            BTQuitter.Visibility = Visibility.Hidden;
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
                actionDemander = "Ajouter";
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
            viderChamps();
        }
        private void cacherGroupeB()
        {
            BTAjouter.Visibility = Visibility.Visible;
            BTQuitter.Visibility = Visibility.Visible;
            //BtSupprimer.Visibility = Visibility.Visible;
            BTConfirmer.Visibility = Visibility.Hidden;
            BTAnnuler.Visibility = Visibility.Hidden;
        }
        private void viderChamps()
        {
            DataGridAchat.ItemsSource = null;
            listeClasseurProduit.Clear();
            TBCout.Text = "";
            cacherGroupeB();
            actionAccomplit = "";
        }
        private void BTConfirmer_Click(object sender, RoutedEventArgs e)
        {
            if (actionDemander.Equals("Ajouter"))
            {
                if (!ChampVide())
                {

                    DateTime localDate = DateTime.Now;
                    ClasseurProduit cv = new ClasseurProduit(Int16.Parse(TBIdBon.Text), Int16.Parse(TBIdBon.Text), Int16.Parse(TBId.Text), Int16.Parse(TBQuantiteUtiliser.Text));
                    //ClasseurProduitC.AjouterComposition(cv);
                    for (int i = 0; i < listeClasseurProduit.Count; i++)
                    {
                        if (listeClasseurProduit.ElementAt(i).ID == 0)
                        {
                            ClasseurProduitC.AjouterComposition(listeClasseurProduit.ElementAt(i));
                            // VenteC.AjouterVente(listeClasseurProduit.ElementAt(i));
                            int idart = listeClasseurProduit.ElementAt(i).IDPRODUIT;
                            ProduitC.ModifierQuantiteProduit(idart, (ProduitC.getQuantite(idart) - listeClasseurProduit.ElementAt(i).NBEX));
                        }
                    }
                    viderChamps();
                    Afficher_Msg_Confirmation("Produit(s) est bien ajouter");
                }
                else
                {
                    Afficher_Msg_Erreur("Erreur : Champ(s) vide(s)");
                }
            }
            else
            {
                this.Close();
            }
        }
        private void BTQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void LoadAllProduits()
        {
            List<Produits> a = ProduitC.GetAllProduits();
            DataGridProduits.ItemsSource = null;
            DataGridProduits.ItemsSource = a;

        }
        private void LoadAllProduits(String champ, String texte)
        {
            List<Produits> reader = ProduitC.GetAllProduitsLikeColonne(champ, texte);
            DataGridProduits.ItemsSource = null;
            DataGridProduits.ItemsSource = reader;

        }
        private void DataGridArticle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            object item = DataGridProduits.SelectedItem;
            try
            {
                TBId.Text = (DataGridProduits.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                TBNom.Text = (DataGridProduits.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBCat.Text = (DataGridProduits.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBDesc.Text = (DataGridProduits.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                TBQuantite.Text = (DataGridProduits.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                TBPrix.Text = (DataGridProduits.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
            }
            catch (Exception exp)
            {
            }
        }

        private void TBFiltres_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                LoadAllProduits();
            }
            else
            {
                switch (CBFiltres.SelectedIndex)
                {
                    case 0: LoadAllProduits("nom", TBFiltres.Text); break;
                    case 1: LoadAllProduits("cat", TBFiltres.Text); break;
                    case 2: LoadAllProduits("description", TBFiltres.Text); break;
                    case 3: LoadAllProduits("prix", TBFiltres.Text); break;
                }
            }
        }

        private void Expander_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FocusManager.SetFocusedElement(this, TBFiltres);
        }

        private void TBId_KeyUp(object sender, KeyEventArgs e)
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
            TBId.Text = newText;

            if (!TBId.Text.Equals(""))
            {
                Produits produit = ProduitC.GetProduit(Int16.Parse(TBId.Text));
                TBId.Text = produit.ID + "";
                TBNom.Text = produit.NOM;
                TBCat.Text = produit.CAT;
                TBDesc.Text = produit.DESC;
                TBQuantite.Text = produit.QUANTITE + "";
                TBPrix.Text = produit.PRIX;

            }
        }

        private void TBIdClient_KeyUp(object sender, KeyEventArgs e)
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
            TBIdBon.Text = newText;
            if (!TBIdBon.Text.Equals("") && (BonProductionC.IdExiste(Int16.Parse(TBIdBon.Text)) > 0))
            {
                BonProduction bonTemp = BonProductionC.GetAllFactures(Int16.Parse(TBIdBon.Text));
                TBIdArticle.Text = bonTemp.IDARTICLE + "";
                TBNbArticle.Text = bonTemp.NBARTICLE + "";
                TBDateDepart.Text = bonTemp.DATEDEPART + "";
                TBCout.Text = bonTemp.COUT + "";
                listeClasseurProduit = ClasseurProduitC.GetAllClasseur("idFactureProduction", TBIdBon.Text);
                LoadAllProduitTemp();
            }
            else
            {
                Afficher_Msg_Erreur("Veuillez saisir un identifiant valide");
            }



        }

        private void ajouterElement_Click(object sender, RoutedEventArgs e)
        {
            if (!TBIdBon.Text.Equals("") && !TBQuantiteUtiliser.Text.Equals("") && !TBNom.Text.Equals(""))
            {
                if (Int16.Parse(TBQuantite.Text) >= Int16.Parse(TBQuantiteUtiliser.Text))
                {
                    listeClasseurProduit.Add(new ClasseurProduit
                    {
                        ID = 0,
                        IDPRODUIT = Int16.Parse(TBId.Text),
                        IDFACTUREPRODUCTION = Int16.Parse(TBIdBon.Text),
                        NBEX = Int16.Parse(TBQuantiteUtiliser.Text)
                    });
                    LoadAllProduitTemp();
                    TBCout.Text = "" + CalculeAddition();
                    TBQuantite.Text = (Int16.Parse(TBQuantite.Text) - Int16.Parse(TBQuantiteUtiliser.Text)) + "";
                    actionAccomplit = "Ajout";
                }
                else
                {
                    Afficher_Msg_Erreur("Quantité du stock est insuffisante");
                }
            }
            else
            {
                Afficher_Msg_Erreur("Veuillez saisir les données convenables");
            }

        }

        private int CalculeAddition()
        {
            int addition = 0;
            for (int i = 0; i < listeClasseurProduit.Count; i++)
            {
                addition += ProduitC.getPrix(listeClasseurProduit.ElementAt(i).IDPRODUIT) * listeClasseurProduit.ElementAt(i).NBEX;
            }
            return addition;
        }

        private void LoadAllProduitTemp()
        {
            DataGridAchat.ItemsSource = null;
            DataGridAchat.ItemsSource = listeClasseurProduit;
            TBCout.Text = "" + CalculeAddition();
        }

        private void TBQuantiteAchat_KeyUp(object sender, KeyEventArgs e)
        {
            TBQuantiteUtiliser.Text = getintFromTB(sender, TBQuantiteUtiliser.Text);
        }

        private String getintFromTB(object sender, String text)
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

        private void supprimerElement_Click(object sender, RoutedEventArgs e)
        {
            object item = DataGridAchat.SelectedItem;
            if (DataGridAchat.SelectedIndex != -1)
            {
                int a = Int16.Parse((DataGridAchat.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                if (a == 0)
                {
                    listeClasseurProduit.RemoveAt(DataGridAchat.SelectedIndex);
                    LoadAllProduitTemp();
                }
                else
                {
                    ClasseurProduitC.SupprimerComposition(a);
                    listeClasseurProduit = ClasseurProduitC.GetAllClasseur("idFactureProduction", TBIdBon.Text);
                    LoadAllProduitTemp();
                }
            }
            else
                Afficher_Msg_Erreur("Vous devez selectionner un élément");
        }

        private void TBRemise_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void ajouterElement_MouseEnter(object sender, MouseEventArgs e)
        {
            ajouterElement.Opacity = 1;
        }

        private void ajouterElement_MouseLeave(object sender, MouseEventArgs e)
        {
            ajouterElement.Opacity = 0.5;
        }

        private void BTQuitter_MouseEnter(object sender, MouseEventArgs e)
        {
            BTQuitter.Opacity = 1;
        }

        private void BTQuitter_MouseLeave(object sender, MouseEventArgs e)
        {
            BTQuitter.Opacity = 0.5;
        }

        private void BTImprimer_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridAchat, "Liste des produits utilisées");
        }

        private void supprimerElement_MouseEnter(object sender, MouseEventArgs e)
        {
            supprimerElement.Opacity = 1;
        }

        private void supprimerElement_MouseLeave(object sender, MouseEventArgs e)
        {
            supprimerElement.Opacity = 0.5;
        }

        private void DataGridBonProd_MouseUp(object sender, MouseButtonEventArgs e)
        {
            object item = DataGridBonProd.SelectedItem;
            try
            {
                TBId.Text = (DataGridBonProd.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                if (!TBIdBon.Text.Equals("") && (BonProductionC.IdExiste(Int16.Parse(TBIdBon.Text)) > 0))
                {
                    BonProduction bonTemp = BonProductionC.GetAllFactures(Int16.Parse(TBIdBon.Text));
                    TBIdArticle.Text = bonTemp.IDARTICLE + "";
                    TBNbArticle.Text = bonTemp.NBARTICLE + "";
                    TBDateDepart.Text = bonTemp.DATEDEPART + "";
                    TBCout.Text = bonTemp.COUT + "";
                    TBIdBon.Text = (DataGridBonProd.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                    listeClasseurProduit = ClasseurProduitC.GetAllClasseur("idFactureProduction", TBIdBon.Text);
                    LoadAllProduitTemp();
                }
                else
                {
                    Afficher_Msg_Erreur("Veuillez saisir un identifiant valide");
                }
            }
            catch (Exception exp)
            {
            }
        }

        private void TBFiltresS_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltres.Text.Equals(""))
            {
                LoadAllBon();
            }
            else
            {
                switch (CBFiltreSs.SelectedIndex)
                {
                    case 0: LoadAllBon("idArticle", TBFiltres.Text); break;
                    case 1: LoadAllBon("idAtelier", TBFiltres.Text); break;
                    case 2: LoadAllBon("nbArticle", TBFiltres.Text); break;
                    case 3: LoadAllBon("cout", TBFiltres.Text); break;
                }
            }
        }

        private void DataGridAchat_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}