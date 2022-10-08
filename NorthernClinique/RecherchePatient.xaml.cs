using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    /// Logique d'interaction pour RecherchePatient.xaml
    /// </summary>
    public partial class RecherchePatient : Window
    {
        Northern_Lights_HospitalEntities1 myBDD;
        public RecherchePatient()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBDD = new Northern_Lights_HospitalEntities1();
            cboAssurance.DataContext = myBDD.Assurance.ToList();
        }

        private void btnAdmission_Click(object sender, RoutedEventArgs e)
        {
            ProcessusAdmission processusAdmission = new ProcessusAdmission();
            processusAdmission.Show();
            this.Close();

        }

        private void cboAssurance_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Assurance assurance = cboAssurance.SelectedItem as Assurance;

            cboAssurance.DataContext = myBDD.Assurance.ToList();

        }

        private void btnAjouterPatient_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            patient.date_naissance = DPdateNaissance.SelectedDate.Value;
            patient.nom = txtNom.Text;
            patient.prenom = txtPrenom.Text;
            patient.adresse = txtAdresse.Text;
            patient.ville = txtVille.Text;
            patient.province = txtProvince.Text;
            patient.code_postal = txtCodePostal.Text;
            patient.telephone = txtTelephone.Text;
            patient.IDAssurance = ((Assurance)cboAssurance.SelectedItem).IDAssurance;

            myBDD.Patient.Add(patient);

            try
            {
                myBDD.SaveChanges();
                MessageBox.Show("Nouveau patient ajouter avec succès");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            DPdateNaissance.DataContext = DateTime.Today;
            txtNom.Text = string.Empty;
            txtPrenom.Text = string.Empty;
            txtAdresse.Text = string.Empty;
            txtVille.Text = string.Empty;
            txtProvince.Text = string.Empty;
            txtCodePostal.Text = string.Empty;
            txtTelephone.Text = string.Empty;

        }
    }
}
