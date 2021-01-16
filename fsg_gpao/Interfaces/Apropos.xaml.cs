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
    /// Logique d'interaction pour Apropos.xaml
    /// </summary>
    public partial class Apropos : Window
    {
        public Apropos()
        {
            InitializeComponent();
        }

        private void quitter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTQuitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
