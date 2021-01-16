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
    /// Logique d'interaction pour Statistique3.xaml
    /// </summary>
    public partial class Statistique3 : Window
    { String table;
        String champs;
        int taille = 0;
        List<String> lstemp = new List<String>();
        List<String> lsNom = new List<String>();
        List<String> lsQuantite = new List<String>();
        public Statistique3()
        {
            InitializeComponent();
            LoadPieChartData();
        }
        public Statistique3(String table, String champs)
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
            try
            {
                List<KeyValuePair<string, int>> aaa = new List<KeyValuePair<string, int>>();
                int j = 0;
                while (j < lsNom.Count)
                {
                    aaa.Add(new KeyValuePair<string, int>(lsNom[j], Int16.Parse(lsQuantite[j])));
                    j++;
                }
                ((ColumnSeries)mcChart.Series[0]).ItemsSource = aaa;
            }
            catch(Exception ex)
            {
                MessageBox.Show(""+ex.Message);
            }
           
        }
        private void listeNom()
        {
            lstemp = ArticleC.getAllChampFromTableST(champs, table); 
            for(int i=0;i<lstemp.Count;i++)
            {
                lsNom.Add(ProduitC.GetNomFromId(Int16.Parse(lstemp[i])));
            }
        }
        private void listeQuantite()
        {
            lsQuantite = ArticleC.getAllNbexChampFromTableST(table);
        }
    }
}