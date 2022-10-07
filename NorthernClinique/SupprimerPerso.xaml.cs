using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NorthernClinique
{
    /// <summary>
    /// Logique d'interaction pour SupprimerPerso.xaml
    /// </summary>
    public partial class SupprimerPerso : Page
    {
        Northern_Lights_HospitalEntities1 myBDD;
        public SupprimerPerso()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myBDD = new Northern_Lights_HospitalEntities1();
            Medecin medecin = comboBIDMedecin.SelectedItem as Medecin;

            comboBIDMedecin.DataContext = myBDD.Medecin.ToList();
        }

        private void comboBIDMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin medecin = comboBIDMedecin.SelectedItem as Medecin;

            textBoxNom.Text = medecin.nom.ToString();
            textBoxPrenom.Text = medecin.prenom.ToString();
        }

        private void btnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            int medecinARetirer = (comboBIDMedecin.SelectedItem as Medecin).IDMedecin;

            Medecin medecin = (from m in myBDD.Medecin where m.IDMedecin == medecinARetirer select m).SingleOrDefault();
            myBDD.Medecin.Remove(medecin);

            if (MessageBox.Show("Êtes-vous sûr de vouloir procéder à la supression?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    myBDD.SaveChanges();
                    MessageBox.Show("Modification du medecin fait avec succès");
                    comboBIDMedecin.ItemsSource = myBDD.Medecin.ToList();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }
    }
}