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
    /// Logique d'interaction pour Aide.xaml
    /// </summary>
    public partial class Aide : Window
    {
        public Aide()
        {
            InitializeComponent();
            chargerAideAdmin();
        }
        private void chargerAideAdmin()
        {
            String a = "un profil est constitué d'un identifiant, un login, et mot de passe, une service et un état.pour accéder à chaque  enregistrement on doit connecter, et Cliquer sur l'englet agent, deux possiblités éxiste : \n -Consulter, modifier ou supprimer un enregistrement \n -ajouter un nouvel enregistrement";
            Connexion.Text = a; ;
        }
    }
}
