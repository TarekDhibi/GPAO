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
    /// Logique d'interaction pour Journal.xaml
    /// </summary>
    public partial class Journal : Window
    {
        String tabel;
        public Journal()
        {
            InitializeComponent();
        }
        public Journal(String table)
        {
            InitializeComponent();
            this.tabel = table;
            ImporterValeurs();
        }
        private void ImporterValeurs()
        {
            if(tabel.Equals("journaladmin"))
            {
                List<JournalP> reader = BonProductionC.GetAll(tabel);
                DataGridAgents.ItemsSource = null;
                DataGridAgents.ItemsSource = reader;
            }
            if (tabel.Equals("journalvente"))
            {
                List<JournalVente> reader = journalVenteC.GetAll(tabel);
                DataGridAgents.ItemsSource = null;
                DataGridAgents.ItemsSource = reader;
            }

            if (tabel.Equals("journalachat"))
            {
                List<JournalAchat> reader = JournalAchatC.GetAll(tabel);
                DataGridAgents.ItemsSource = null;
                DataGridAgents.ItemsSource = reader;
            }
            if (tabel.Equals("journalarticle"))
            {
                List<JournalArticle> reader = JournalArticleC.GetAll(tabel);
                DataGridAgents.ItemsSource = null;
                DataGridAgents.ItemsSource = reader;
            }
            if (tabel.Equals("journalproduit"))
            {
                List<JournalProd> reader = JournalProdC.GetAll(tabel);
                DataGridAgents.ItemsSource = null;
                DataGridAgents.ItemsSource = reader;
            }
        }
    }
}
