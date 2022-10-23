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

namespace NorthernClinique
{
    /// <summary>
    /// Logique d'interaction pour adminPersonnel.xaml
    /// </summary>
    public partial class adminPersonnel : Window
    {
        public adminPersonnel()
        {
            InitializeComponent();
        }

        //Ouverture des différents frames selon le choix dans le menu
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            framePerso.Content = new AjouterPerso();
        }

        private void MenuAjouter_Click(object sender, RoutedEventArgs e)
        {
            framePerso.Content = new AjouterPerso();
            
        }

        private void MenuModifier_Click(object sender, RoutedEventArgs e)
        {
            framePerso.Content = new modifierPerso();
        }

        private void MenuSupprimer_Click(object sender, RoutedEventArgs e)
        {
            framePerso.Content = new SupprimerPerso();
        }

        private void MenuQuitter_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Acceuil();
            window.Show();
            this.Close();
        }

    }
}
