using fsg_gpao.Connecteurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace fsg_gpao.Interfaces
{
    /// <summary>
    /// Logique d'interaction pour Statistique.xaml
    /// </summary>
    public partial class Statistique : Window
    {
        String table;
        String champs;
        int taille = 0;
        List<String> lsNom = new List<String>();
        List<String> lsQuantite = new List<String>();
        public Statistique()
        {
            InitializeComponent();
            LoadPieChartData();
        }
        public Statistique(String table, String champs)
        {
            InitializeComponent();
            this.table = table;
            this.champs = champs;
            listeNom();
            listeQuantite();

            LoadPieChartData();
        }
        private void LoadPieChartData()
        {
            List<KeyValuePair<string, int>> aaa = new List<KeyValuePair<string, int>>();
             int j=0;
            while(j<lsNom.Count)
            {
                aaa.Add( new KeyValuePair<string, int>(lsNom[j], Int16.Parse(lsQuantite[j])));
                j++;
            }
            taille = j;

            ((PieSeries)mcChart.Series[0]).ItemsSource = aaa;
        }
        private void listeNom()
        {
            lsNom = ArticleC.getAllChampFromTableST(champs, table); 
        }
        private void listeQuantite()
        {
            lsQuantite = ArticleC.getAllQuantChampFromTableST(table); 
        }
    }
}
