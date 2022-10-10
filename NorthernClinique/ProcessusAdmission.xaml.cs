using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
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
            comboBSouhait.DataContext = myBDD.Type_Lit.ToList();

        }
            
        private void btnValiderAdmission_Click(object sender, RoutedEventArgs e)
        {
            Admission admission = new Admission();

            if (nombrePatientAvecLit() < placeDisponible())
            {
                if (checkbChirurgie.IsChecked == true)
                {
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
                if (cBoxTelevision.IsChecked == true) admission.televiseur = true;
                if (cbTelephone.IsChecked == true) admission.telephone = true;
                admission.NSS = int.Parse(cbNSS.Text);

                try
                {
                    admission.Numero_lit = int.Parse(cboNumLit.Text);
                    admission.IDMedecin = int.Parse(cboMedecin.Text);
                    myBDD.Admission.Add(admission);
                    miseAJourLit(int.Parse(cboNumLit.Text));
                    myBDD.SaveChanges();
                    MessageBox.Show("L'admission a été fait avec succès");
                }
                catch (Exception)
                {
                    MessageBox.Show("Le département est plein", "Attention");
                }

                cBoxTelevision.IsChecked = false;
                cbTelephone.IsChecked = false;
                checkbChirurgie.IsChecked = false;
            }else MessageBox.Show("L'hopital est plein", "Attention");
            
            Window window = new sessionPrepose();
            window.Show();
            this.Close();
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
                 select new{
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
            txtboxAssure.Text = patient.IDAssurance.ToString();
            
            string stringAgePatient = (DateTime.Now.Year - patient.date_naissance.Year).ToString();
            txtboxAge.Text = stringAgePatient;
            int intAgePatient = int.Parse(stringAgePatient);

            if (intAgePatient < 16 && checkbChirurgie.IsChecked == false)
            {
                cboTypeChambre.SelectedIndex = 2;
            }
            else cboTypeChambre.SelectedIndex = 0;
            
        }

        private void cboMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin medecin = cboMedecin.SelectedItem as Medecin;
            txtBoxMedNom.Text = medecin.nom.ToString();
            txtBoxMedPrenom.Text = medecin.prenom.ToString();
        }

        private int nombrePatientAvecLit() {
            int nombrePatientAvecLit = (from a in myBDD.Admission
                                        where a.date_du_congé == null
                                        select a.NSS).Count();

            return nombrePatientAvecLit;
        }

        private int placeDisponible() {
            int placeDisponible = (from a in myBDD.Lit
                                   select a.Numero_lit).Count();

            return placeDisponible;
        }

        public static void miseAJourLit(int numeroDuLit) {
            var BDD = new Northern_Lights_HospitalEntities1();
            {
                Lit lit = BDD.Lit.FirstOrDefault(t => t.Numero_lit == numeroDuLit);
                if (lit != null) 
                {
                    lit.occupe = true;
                    BDD.SaveChanges();
                }
            }
        }

        private void cBoxTelevision_Checked(object sender, RoutedEventArgs e)
        {
            float montant = float.Parse(txtboxPrix.Text);
            float televiseur = 42.5f;
            txtboxPrix.Text = (montant+ televiseur).ToString();
        }

        private void cBoxTelevision_Unchecked(object sender, RoutedEventArgs e)
        {
            float montant = float.Parse(txtboxPrix.Text);
            float televiseur = 42.5f;
            txtboxPrix.Text = (montant- televiseur).ToString();
        }

        private void cbTelephone_Checked(object sender, RoutedEventArgs e)
        {
            float montant = float.Parse(txtboxPrix.Text);
            float telephone = 7.5f;
            txtboxPrix.Text = (montant + telephone).ToString();
        }

        private void cbTelephone_Unchecked(object sender, RoutedEventArgs e)
        {
            float montant = float.Parse(txtboxPrix.Text);
            float telephone = 7.5f;
            txtboxPrix.Text = (montant - telephone).ToString();
        }

         private void btnCalculer_Click(object sender, RoutedEventArgs e)
        {
            int indexSouhaite = comboBSouhait.SelectedIndex;
            string litSelectionne = cboTypeLit.Text;
            int indexSelectionne;

            if (litSelectionne == "Public                   ") indexSelectionne = 0;
            else if (litSelectionne == "Semi-Privée              ") indexSelectionne = 1;
            else indexSelectionne = 2;

            bool assurePrivee = false;
            int assurance = int.Parse(txtboxAssure.Text);
            if (assurance > 1) assurePrivee = true;

            if (!assurePrivee && (indexSouhaite > 0))
            {
                if (indexSelectionne == 1)
                {
                    float montant = float.Parse(txtboxPrix.Text);
                    float semiPrivee = 267f;
                    txtboxPrix.Text = (montant + semiPrivee).ToString();
                }
                else if (indexSelectionne == 2)
                {
                    float montant = float.Parse(txtboxPrix.Text);
                    float privee = 571f;
                    txtboxPrix.Text = (montant + privee).ToString();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtboxPrix.Text = "0";
            checkbChirurgie.IsChecked = false;
            cbTelephone.IsChecked = false;
            cBoxTelevision.IsChecked = false;
        }

        private void checkbChirurgie_Checked(object sender, RoutedEventArgs e)
        {
            cboTypeChambre.SelectedIndex = 0;
        }
    }
}
