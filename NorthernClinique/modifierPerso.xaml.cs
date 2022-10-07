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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NorthernClinique
{
    /// <summary>
    /// Logique d'interaction pour modifierPerso.xaml
    /// </summary>

    public partial class modifierPerso : Page
    {
        Northern_Lights_HospitalEntities1 myBDD;
        public modifierPerso()
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

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            Medecin medecin = comboBIDMedecin.SelectedItem as Medecin;

            medecin.IDMedecin = int.Parse(comboBIDMedecin.Text);
            medecin.nom = textBoxNom.Text;
            medecin.prenom = textBoxPrenom.Text;

            try
            {
                myBDD.SaveChanges();
                MessageBox.Show("Modification du medecin fait avec succès");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
