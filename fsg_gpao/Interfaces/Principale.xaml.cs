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
    /// Logique d'interaction pour Principale.xaml
    /// </summary>
    public partial class Principale : Window
    {
        int idAdminCourant = 0;
        public Principale()
        {
            
            InitializeComponent();
        }
        public Principale(int id)
        {
            InitializeComponent();
            this.idAdminCourant = id;
            creerTitre();
            privilege();
        }
        private void creerTitre()
        {
            try
            {
                String login = Connecteurs.profilC.GetLoginFromId(idAdminCourant);
                this.Title = "Administrateur courant : " + login;
            }
            catch(Exception ex)
            {
               
            }
        }
        private void privilege()
        {
            String service = profilC.GetService(idAdminCourant);
            if (service.Equals("Agent Commercial"))
            {
                mAgents.IsEnabled = false;
                MProduits.IsEnabled = false;
                MAteliers.IsEnabled = false;
                consulter.IsEnabled = false;
                Mproduction.IsEnabled = false;
                Mgroupes.IsEnabled = false;
                histo.Visibility = Visibility.Collapsed;
                
                GestionClient Child = new GestionClient(idAdminCourant);
                StkPanelContent.Children.Clear();
                object content = Child.Content;
                Child.Content = null;
                this.StkPanelContent.Children.Add(content as UIElement);
            }
            if (service.Equals("Agent de production"))
            {
                mAgents.IsEnabled = false;
                MFournisseur.IsEnabled = false;
                MCLient.IsEnabled = false;
                MVentes.IsEnabled = false;
                MAchats.IsEnabled = false;
                MDevis.IsEnabled = false;
                MArticles.IsEnabled = false;
                ajouter.IsEnabled = false;
                histo.Visibility = Visibility.Collapsed;

               


    
    
    GererBonProduction Child = new GererBonProduction(idAdminCourant);
                StkPanelContent.Children.Clear();
                object content = Child.Content;
                Child.Content = null;
                this.StkPanelContent.Children.Add(content as UIElement);

                
            }
            if (service.Equals("Administrateur"))
            {
                GererAgents Child = new GererAgents(idAdminCourant);
                StkPanelContent.Children.Clear();
                object content = Child.Content;
                Child.Content = null;
                this.StkPanelContent.Children.Add(content as UIElement);
           


            }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            //GesAgents2 a = new GesAgents2();
            //a.Show();
            GererAgents Child = new GererAgents(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AjouterAgent a = new AjouterAgent(idAdminCourant);
            a.Show();
            //AjouterAgent Child = new AjouterAgent();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            //GestionClient a = new GestionClient(idAdminCourant);
            //a.Show();
            GestionClient Child = new GestionClient(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            AjouterClient a = new AjouterClient(idAdminCourant);
            a.Show();
            //AjouterClient Child = new AjouterClient();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            //GererArticles a = new GererArticles(idAdminCourant);
            //a.Show();
            GererArticles Child = new GererArticles();
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            AjouterArticle a = new AjouterArticle(idAdminCourant);
            a.Show();
            //AjouterArticle Child = new AjouterArticle();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            AjouterVente a = new AjouterVente(idAdminCourant);
            a.Show();
            //AjouterVente Child = new AjouterVente();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            //GereVente a = new GereVente(idAdminCourant);
            //a.Show();
            GereVente Child = new GereVente(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            //GererProduits a = new GererProduits(idAdminCourant);
            //a.Show();
            GererProduits Child = new GererProduits(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            AjouterProduit a = new AjouterProduit(idAdminCourant);
            a.Show();
            //AjouterProduit Child = new AjouterProduit();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            //GererFournisseur a = new GererFournisseur(idAdminCourant);
            //a.Show();
            GererFournisseur Child = new GererFournisseur(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            AjouterFournisseur a = new AjouterFournisseur(idAdminCourant);
            a.Show();
            //AjouterFournisseur Child = new AjouterFournisseur();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            //GererAchat a = new GererAchat(idAdminCourant);
            //a.Show();
            GererAchat Child = new GererAchat(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            AjouterAchat a = new AjouterAchat(idAdminCourant);
            a.Show();
            //AjouterAchat Child = new AjouterAchat();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {
            //GererDevis a = new GererDevis(idAdminCourant);
            //a.Show();
            GererDevis Child = new GererDevis(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_17(object sender, RoutedEventArgs e)
        {
            AjouterDevis a = new AjouterDevis(idAdminCourant);
            a.Show();
            //AjouterDevis Child = new AjouterDevis();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_18(object sender, RoutedEventArgs e)
        {
            //GererAtelier a = new GererAtelier(idAdminCourant);
            //a.Show();
            GererAtelier Child = new GererAtelier();
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_19(object sender, RoutedEventArgs e)
        {
            AjouterAtelier a = new AjouterAtelier(idAdminCourant);
            a.Show();
            //AjouterAtelier Child = new AjouterAtelier();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_20(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_21(object sender, RoutedEventArgs e)
        {
            //ConsulterGroupeDeTravail a = new ConsulterGroupeDeTravail(idAdminCourant);
            //a.Show();
            ConsulterGroupeDeTravail Child = new ConsulterGroupeDeTravail(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_22(object sender, RoutedEventArgs e)
        {
            AJouterGroupeDeTravail a = new AJouterGroupeDeTravail(idAdminCourant);
            a.Show();
            //AJouterGroupeDeTravail Child = new AJouterGroupeDeTravail();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_23(object sender, RoutedEventArgs e)
        {
            AjouterBonProduction a = new AjouterBonProduction(idAdminCourant);
            a.Show();
            //AjouterBonProduction Child = new AjouterBonProduction();
            //StkPanelContent.Children.Clear();
            //object content = Child.Content;
            //Child.Content = null;
            //this.StkPanelContent.Children.Add(content as UIElement);
        }

 
        

  
      

        private void MenuItem_Click_24(object sender, RoutedEventArgs e)
        {
            GererBonProduction Child = new GererBonProduction(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_25(object sender, RoutedEventArgs e)
        {
            SuiviDeProduction Child = new SuiviDeProduction(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void CalculCharge(object sender, RoutedEventArgs e)
        {
            CalculCharge Child = new CalculCharge(idAdminCourant);
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MIDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow();
            a.Show();
            for (int i = Application.Current.Windows.Count-1; i >= 0; i--)
            {
                if (Application.Current.Windows[i].Name != "authen")
                    Application.Current.Windows[i].Close();
            }
           
        }
            


        private void MIQuitter_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);

        }

        private void MenuItem_Click_26(object sender, RoutedEventArgs e)
        {
            Journal Child = new Journal("journaladmin");
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_27(object sender, RoutedEventArgs e)
        {
            Journal Child = new Journal("journalvente");
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MIDV_Click(object sender, RoutedEventArgs e)
        {
            Apropos a = new Apropos();
            a.Show();
        }

        private void MenuItem_Click_28(object sender, RoutedEventArgs e)
        {
            Journal Child = new Journal("journalachat");
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_29(object sender, RoutedEventArgs e)
        {
            Journal Child = new Journal("journalarticle");
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_30(object sender, RoutedEventArgs e)
        {
            Journal Child = new Journal("journalproduit");
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MIDZ_Click(object sender, RoutedEventArgs e)
        {
            Aide a = new Aide();
            a.Show();
        }

        private void MenuItem_Click_31(object sender, RoutedEventArgs e)
        {
            
            Statistique Child = new Statistique("article", "nom");
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_32(object sender, RoutedEventArgs e)
        {
           
            Statistique Child = new Statistique("produits", "nom");
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_33(object sender, RoutedEventArgs e)
        {
            Statistique2 Child = new Statistique2("vente", "idarticle");
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

        private void MenuItem_Click_34(object sender, RoutedEventArgs e)
        {
            Statistique3 Child = new Statistique3("achat", "idProduit");
            StkPanelContent.Children.Clear();
            object content = Child.Content;
            Child.Content = null;
            this.StkPanelContent.Children.Add(content as UIElement);
        }

       
    }
}
