﻿using fsg_gpao.Acteurs;
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
    /// Logique d'interaction pour GererProduits.xaml
    /// </summary>
    public partial class GererProduits : Window
    {
         String ActionDemander = "";
        int idCourant = 0;
        public GererProduits()
        {
            InitializeComponent();
        }
        public GererProduits(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            LoadAllProduits();
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
            if (TBNom.Text.Equals("") || TBquantite.Text.Equals("") || TBPrix.Text.Equals(""))
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
                TBNom.Text = (DataGridArticle.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBCat.Text = (DataGridArticle.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBDesc.Text = (DataGridArticle.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                TBquantite.Text = (DataGridArticle.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                TBPrix.Text = (DataGridArticle.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
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

        private void LoadAllProduits()
        {
            List<Produits> reader = ProduitC.GetAllProduits();
            DataGridArticle.ItemsSource = null;
            DataGridArticle.ItemsSource = reader;

        }
        private void LoadAllProduits(String champ, String texte)
        {
            List<Produits> reader = ProduitC.GetAllProduitsLikeColonne(champ, texte);
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
                    fsg_gpao.Acteurs.Produits produit = new fsg_gpao.Acteurs.Produits(Int16.Parse(solId), TBNom.Text, TBCat.Text, TBDesc.Text, Int16.Parse(TBquantite.Text), TBPrix.Text);

                    if (ActionDemander.Equals("Modifier"))
                    {
                        if (!TBId.Text.Equals(""))
                        {
                            int res = fsg_gpao.Connecteurs.ProduitC.ModifierProduits(produit);
                            if (res == 1)
                            {
                                Afficher_Msg_Confirmation("Le produit est bien modifier");
                                DateTime localDate = DateTime.Now;
                                JournalProd jounal = new JournalProd(this.idCourant,produit.ID, localDate.ToString("F"), " Modification de : " + produit.NOM , produit.DESC );
                                fsg_gpao.Connecteurs.JournalProdC.ajouterJournal(jounal);
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
                        LoadAllProduits();
                    }
                    else
                    {
                        if (ActionDemander.Equals("Supprimer"))
                        {
                            if (!TBId.Text.Equals(""))
                            {
                                if (fsg_gpao.Connecteurs.ProduitC.IdExisteJournal(Int16.Parse(TBId.Text)) == -1)
                                {
                                    Afficher_Msg_Erreur("Erreur de connexion à la base de données");
                                }
                                else
                                {
                                    if (fsg_gpao.Connecteurs.ProduitC.IdExisteJournal(Int16.Parse(TBId.Text)) != 0)
                                    {
                                        Afficher_Msg_Erreur("Impossible de supprimer ce produit, il a réalisé un/des tache(s) dans le journal.");
                                    }
                                    else
                                    {
                                        int res = fsg_gpao.Connecteurs.ProduitC.SupprimerProduits(produit.ID);
                                        if (res == 1)
                                        {
                                            Afficher_Msg_Confirmation("Le produit est bien supprimer");
                                            DateTime localDate = DateTime.Now;
                                            JournalProd jounal = new JournalProd(this.idCourant, produit.ID, localDate.ToString("F"), " Supprission de : " + produit.NOM, produit.DESC);

                                            fsg_gpao.Connecteurs.JournalProdC.ajouterJournal(jounal);
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
                LoadAllProduits();
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

        private void BTImprimer_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(DataGridArticle, "Liste des produits");
        }
    }
}
