using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NorthernClinique
{
    /// <summary>
    /// Logique d'interaction pour ProcessusAdmission.xaml
    /// </summary>
    public partial class ProcessusAdmission : Window
    {
        Northern_Lights_HospitalEntities1 myBDD;
        public ProcessusAdmission()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myBDD = new Northern_Lights_HospitalEntities1();

            Patient patient = cbNSS.SelectedItem as Patient;
            cbNSS.DataContext = myBDD.Patient.ToList();

            Medecin medecin = cboMedecin.SelectedItem as Medecin;
            cboMedecin.DataContext = myBDD.Medecin.ToList();

            Departement departement = cboTypeChambre.SelectedItem as Departement;
            cboTypeChambre.DataContext = myBDD.Departement.ToList();

            var queryTypeLit =
                (from a in myBDD.Departement
                 join b in myBDD.Lit on a.IDDepartement equals b.IDDepartement
                 join c in myBDD.Type_Lit on b.IDType equals c.IDType
                 where (b.occupe == false)
                 select new { b.Numero_lit, a.nom_departement, c.description
                }).ToList();
            
            cboNumLit.DataContext = queryTypeLit;
            cboTypeLit.DataContext = queryTypeLit;

        }

        private void btnValiderAdmission_Click(object sender, RoutedEventArgs e)
        {
            Admission admission = new Admission();

            if (checkbChirurgie.IsChecked == true) {
                try
                {
                    admission.chirurgie_programmee = true;
                    admission.date_chirurgie = datepChirurgie.SelectedDate;
                }
                catch (Exception)
                {

                    MessageBox.Show("Vous devez entrer une date de chirurgie!");
                }
            }
            
            admission.date_admission = DateTime.Now;
            if(cBoxTelevision.IsChecked == true) admission.televiseur = true;
            if (cbTelephone.IsChecked == true) admission.telephone = true;
            admission.NSS = int.Parse(cbNSS.Text);
            admission.Numero_lit = int.Parse(cboNumLit.Text);
            admission.IDMedecin = int.Parse(cboMedecin.Text);

            myBDD.Admission.Add(admission);
            try
            {
                myBDD.SaveChanges();
                MessageBox.Show("L'admission a été fait avec succès");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            cBoxTelevision.IsChecked = false;
            cbTelephone.IsChecked = false;
            checkbChirurgie.IsChecked = false;
        }

        private void cboTypeChambre_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int indice = cboTypeChambre.SelectedIndex+1;

            var queryTypeLit =
                (from a in myBDD.Departement
                 join b in myBDD.Lit on a.IDDepartement equals b.IDDepartement
                 join c in myBDD.Type_Lit on b.IDType equals c.IDType
                 where (b.occupe == false)
                 where (a.IDDepartement == indice)
                 select new
                 {
                     b.Numero_lit,
                     a.nom_departement,
                     c.description
                 }).Distinct().ToList();

            cboNumLit.DataContext = queryTypeLit;
            cboTypeLit.DataContext = queryTypeLit;

        }

        private void cbNSS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Patient patient = cbNSS.SelectedItem as Patient;
            txtNom.Text = patient.nom.ToString();
            txtPrenom.Text = patient.prenom.ToString();
        }

        private void cboMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin medecin = cboMedecin.SelectedItem as Medecin;
            txtBoxMedNom.Text = medecin.nom.ToString();
            txtBoxMedPrenom.Text = medecin.prenom.ToString();
        }
    }
}
