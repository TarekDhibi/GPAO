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
    /// Logique d'interaction pour AjouterAchat.xaml
    /// </summary>
    public partial class AjouterVente : Window
    {
        int idCourant = 0, idc=0;
        Boolean etatClientDemander = true;
        Boolean etatRemise = true;
        String actionDemander="";
        List<Vente> listeVenteTemp = new List<Vente>();  
        public AjouterVente()
        {
            InitializeComponent();
        }
        public AjouterVente(int id)
        {
            InitializeComponent();
            this.idCourant = id;
            creerTitre();
            LoadAllArticles();
            LoadAllClients();
            idc = ClasseurVenteC.GetNexId() + 1;
        }
        private void LoadAllClients()
        {
            List<Client> reader = ClientC.GetAllClient();
            DataGridClients.ItemsSource = null;
            DataGridClients.ItemsSource = reader;

        }
        private void LoadAllClients(String champ, String texte)
        {
            List<Client> reader = ClientC.GetAllClient(champ, texte);
            DataGridClients.ItemsSource = null;
            DataGridClients.ItemsSource = reader;
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
            if (!etatClientDemander || Somme.Text.Equals(""))
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
            //BTModifier.Visibility = Visibility.Hidden;
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
            // BtModifier.Visibility = Visibility.Visible;
            //BtSupprimer.Visibility = Visibility.Visible;
            BTConfirmer.Visibility = Visibility.Hidden;
            BTAnnuler.Visibility = Visibility.Hidden;
        }
        private void viderChamps()
        {
            DataGridAchat.ItemsSource = null;
            listeVenteTemp.Clear();
            Somme.Text = "";
            cacherGroupeB();
        }
         private void BTConfirmer_Click(object sender, RoutedEventArgs e)
        {
            if (actionDemander.Equals("Ajouter"))
            {
                if (!ChampVide())
                {

                    DateTime localDate = DateTime.Now;
                    ClasseurVente cv = new ClasseurVente(idc, idCourant, Int16.Parse(TBIdClient.Text), localDate.ToString("F"));
                    ClasseurVenteC.AjouterVente(cv);
                    for (int i = 0; i < DataGridAchat.Items.Count; i++)
                    {
                        VenteC.AjouterVente(listeVenteTemp.ElementAt(i));
                        int idart = listeVenteTemp.ElementAt(i).IDARTICLE;
                        fsg_gpao.Connecteurs.journalVenteC.ajouterJournal(new fsg_gpao.Acteurs.JournalVente(1, this.idCourant, idart, localDate.ToString("F"), "Vente", " Quantité vendue : " + listeVenteTemp.ElementAt(i).NBEX));

                        ArticleC.ModifierQuantiteArticle(idart, (ArticleC.getQuantite(idart)- listeVenteTemp.ElementAt(i).NBEX));
                    }
                    viderChamps();
                    Afficher_Msg_Confirmation("Vente bien ajouter");
                    idc++;    
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
        private void DataGridArticle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            object item = DataGridArticle.SelectedItem;
            try
            {
                TBId.Text = (DataGridArticle.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                TBNom.Text = (DataGridArticle.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                TBCat.Text = (DataGridArticle.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
                TBDesc.Text = (DataGridArticle.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                TBQuantite.Text = (DataGridArticle.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                TBPrix.Text = (DataGridArticle.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                TBPrixAchat.Text = (DataGridArticle.SelectedCells[5].Column.GetCellContent(item) as TextBlock).Text;
                TBQuantiteAchat.Text = "1";
                TBRemise.Text = "0";
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
                Article article = ArticleC.GetArticle(Int16.Parse(TBId.Text));
                TBId.Text = article.ID+"";
                TBNom.Text = article.NOM;
                TBCat.Text = article.CAT;
                TBDesc.Text = article.DESC;
                TBQuantite.Text = article.QUANTITE+"";
                TBPrix.Text = article.PRIX;
                TBQuantiteAchat.Text = "1";
                TBPrixAchat.Text = article.PRIX;
                TBRemise.Text = "0";
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
            TBIdClient.Text = newText;

            if (!TBIdClient.Text.Equals(""))
            {
                Client client = ClientC.GetClient(Int16.Parse(TBIdClient.Text));
                TBIdClient.Text = client.ID + "";
                TBNomClient.Text = client.NOM;
                TBAdresseClient.Text = client.ADRESSE;
                TBTelClient.Text = client.TEL;
                TBQuantite.Text = client.Remarque + "";
                CBEtatClient.IsChecked = client.ETAT;
                if(!client.ETAT)
                {
                    Afficher_Msg_Erreur("ce CLient n'est pas autorisé de faire des achats.");
                    etatClientDemander = false;
                }
            }
        }

        private void ajouterElement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Int16.Parse(TBQuantiteAchat.Text) > 0)
                {
                    if (etatRemise)
                    {
                        listeVenteTemp.Add(new Vente
                        {
                            ID = 0,
                            IDARTICLE = Int16.Parse(TBId.Text),
                            NBEX = Int16.Parse(TBQuantiteAchat.Text),
                            PRIX = Int16.Parse(TBPrixAchat.Text),
                            REMISE = Int16.Parse(TBRemise.Text),
                            IDCLASSEUR = idc
                        });
                        LoadAllArticleTemp();
                        Somme.Text = "" + CalculeAddition();
                    }
                    else
                    {
                        Afficher_Msg_Erreur("Veuillez vérifier le remise");
                    }
                }
                else
                {
                    Afficher_Msg_Erreur("Veuillez vérifier la quantité demandé");
                }
            }
            catch(Exception ex)
            {
                Afficher_Msg_Erreur("Erreur : format inattendue");
            }
            
            
        }

        private int CalculeAddition()
        {
            int addition = 0;
            for(int i=0;i<listeVenteTemp.Count;i++)
            {
                addition += listeVenteTemp.ElementAt(i).PRIX - listeVenteTemp.ElementAt(i).REMISE;
            }
            return addition;
        }

        private void LoadAllArticleTemp()
        {
            DataGridAchat.ItemsSource = null;
            DataGridAchat.ItemsSource = listeVenteTemp;
        }

        private void TBQuantiteAchat_KeyUp(object sender, KeyEventArgs e)
        {
            TBQuantiteAchat.Text = getintFromTB(sender,TBQuantiteAchat.Text);

            if (!TBId.Text.Equals("") && (!TBPrix.Equals("")) && (!TBQuantiteAchat.Text.Equals("")))
            {
                int nb = Int16.Parse(TBQuantiteAchat.Text);
                if((nb>0 )&&(!TBPrix.Equals("")))
                {
                    if(Int16.Parse(TBQuantiteAchat.Text)>Int16.Parse(TBQuantite.Text))
                    {
                        Afficher_Msg_Erreur("Strock insuffisant");
                        etatRemise = false;
                    }
                    else
                    {
                        int pr = Int16.Parse(TBPrix.Text);
                        nb *= pr;
                        TBPrixAchat.Text = nb + "";
                    }
                }
            }
        }

        private String getintFromTB(object sender,String text)
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
                listeVenteTemp.RemoveAt(DataGridAchat.SelectedIndex);
                LoadAllArticleTemp();
            }
            else
                Afficher_Msg_Erreur("Vous devez selectionner un élément");
        }

        private void TBRemise_KeyUp(object sender, KeyEventArgs e)
        {
            if(!TBRemise.Text.Equals(""))
            {
                TBRemise.Text = getintFromTB(sender, TBQuantiteAchat.Text);
                int prix = Int16.Parse(TBPrixAchat.Text);
                int remise = Int16.Parse(TBRemise.Text);
                if (prix < remise)
                {
                    Afficher_Msg_Erreur("les remises ne peuvent pas dépasser le prix de vente.");
                    etatRemise = false;
                }
                else
                {
                    etatRemise = true;
                }
            }
            else
            {
                TBRemise.Text = "0";
            }
            
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
            printDlg.PrintVisual(DataGridAchat, "Liste des ventes");
        }

        private void supprimerElement_MouseEnter(object sender, MouseEventArgs e)
        {
            supprimerElement.Opacity = 1;
        }

        private void supprimerElement_MouseLeave(object sender, MouseEventArgs e)
        {
            supprimerElement.Opacity = 0.5;
        }

        private void DataGridAgents_MouseUp(object sender, MouseButtonEventArgs e)
        {
            object item = DataGridClients.SelectedItem;
            try
            {
                TBIdClient.Text = (DataGridClients.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                if (!TBIdClient.Text.Equals(""))
                {
                    Client client = ClientC.GetClient(Int16.Parse(TBIdClient.Text));
                    TBIdClient.Text = client.ID + "";
                    TBNomClient.Text = client.NOM;
                    TBAdresseClient.Text = client.ADRESSE;
                    TBTelClient.Text = client.TEL;
                    //TBQuantite.Text = client.Remarque + "";
                    CBEtatClient.IsChecked = client.ETAT;
                    if (!client.ETAT || client.ID == 0)
                    {
                        Afficher_Msg_Erreur("ce CLient n'est pas autorisé de faire des devis.");
                        etatClientDemander = false;
                    }
                }
            }
            catch (Exception exp)
            {
            }
        }

        private void TBFiltresS_KeyUp(object sender, KeyEventArgs e)
        {
            if (TBFiltresS.Text.Equals(""))
            {
                LoadAllClients();
            }
            else
            {
                switch (CBFiltresS.SelectedIndex)
                {
                    case 0: LoadAllClients("nom", TBFiltresS.Text); break;
                    case 1: LoadAllClients("adresse", TBFiltresS.Text); break;
                    case 2: LoadAllClients("tel", TBFiltresS.Text); break;
                    case 3: LoadAllClients("remarque", TBFiltresS.Text); break;
                }
            }
        }

        private void btnImprimer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
