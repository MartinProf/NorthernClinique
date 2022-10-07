using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour AjouterPerso.xaml
    /// </summary>
    public partial class AjouterPerso : Page
    {
        Northern_Lights_HospitalEntities1 myBDD;
        public AjouterPerso()
        {
            InitializeComponent();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            myBDD = new Northern_Lights_HospitalEntities1();

            Medecin medecin = new Medecin();
            medecin.prenom = textBoxPrenom.Text;
            medecin.nom = textBoxNom.Text;

            myBDD.Medecin.Add(medecin);

            try
            {
                myBDD.SaveChanges();
                MessageBox.Show("Le nouveau medevin a été ajouté avec succès");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

    }
}
