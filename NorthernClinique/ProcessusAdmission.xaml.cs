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

            //Remplissage des combobox 
            Patient patient = cbNSS.SelectedItem as Patient;
            cbNSS.DataContext = myBDD.Patient.ToList();

            Medecin medecin = cboMedecin.SelectedItem as Medecin;
            cboMedecin.DataContext = myBDD.Medecin.ToList();

            Departement departement = cboTypeChambre.SelectedItem as Departement;
            cboTypeChambre.DataContext = myBDD.Departement.ToList();

            //Jointure de 3 tables pour le type de lit, son numéro et le département qui l'accueil
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

            //Validattion de disponibilité de lit
            if (nombrePatientAvecLit() < placeDisponible())
            {
                //Validation de la date de chirurgie si la checkbox est cochée
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
                //Les options de la chambre pour le calcul du prix
                if (cBoxTelevision.IsChecked == true) admission.televiseur = true;
                if (cbTelephone.IsChecked == true) admission.telephone = true;
                admission.NSS = int.Parse(cbNSS.Text);

                //Création de l'admission 
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
            
            Window window = new ProcessusAdmission();
            window.Show();
            this.Close();
        }

        //Le changement syncro des combobox lit, type de lite et dpéartement
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

        //Le changement syncro des info du patient qui ajuste le type de chambre si le patient à moins de 16 ans
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

        //Le changement syncro des info du médecin
        private void cboMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin medecin = cboMedecin.SelectedItem as Medecin;
            txtBoxMedNom.Text = medecin.nom.ToString();
            txtBoxMedPrenom.Text = medecin.prenom.ToString();
        }

        //Décompte des patients
        private int nombrePatientAvecLit() {
            int nombrePatientAvecLit = (from a in myBDD.Admission
                                        where a.date_du_congé == null
                                        select a.NSS).Count();

            return nombrePatientAvecLit;
        }

        //Décompte des places disponibles
        private int placeDisponible() {
            int placeDisponible = (from a in myBDD.Lit
                                   select a.Numero_lit).Count();

            return placeDisponible;
        }

        //Change le status du lit à occupé lors de l'admission
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

        //Ajout du prix de la télé si l'option est sélectionné
        private void cBoxTelevision_Checked(object sender, RoutedEventArgs e)
        {
            float montant = float.Parse(txtboxPrix.Text);
            float televiseur = 42.5f;
            txtboxPrix.Text = (montant+ televiseur).ToString();
        }

        //Enlève le coût de la télé si la checkbox est désélectionnée
        private void cBoxTelevision_Unchecked(object sender, RoutedEventArgs e)
        {
            float montant = float.Parse(txtboxPrix.Text);
            float televiseur = 42.5f;
            txtboxPrix.Text = (montant- televiseur).ToString();
        }

        //Ajout du prix du téléphone si l'option est sélectionné
        private void cbTelephone_Checked(object sender, RoutedEventArgs e)
        {
            float montant = float.Parse(txtboxPrix.Text);
            float telephone = 7.5f;
            txtboxPrix.Text = (montant + telephone).ToString();
        }

        //Enlève le coût du téléphone si la checkbox est désélectionnée
        private void cbTelephone_Unchecked(object sender, RoutedEventArgs e)
        {
            float montant = float.Parse(txtboxPrix.Text);
            float telephone = 7.5f;
            txtboxPrix.Text = (montant - telephone).ToString();
        }

        //Ajoute le prix selon le type de chambre sélectionnée
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

        //Réinitialise le calcul du prix
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


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Acceuil acceuil = new Acceuil();
            acceuil.Show();
            this.Hide();
        }
    }
}
