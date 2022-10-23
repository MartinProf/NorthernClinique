using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour sessionMedecin.xaml
    /// </summary>
    public partial class sessionMedecin : Window
    {
        Northern_Lights_HospitalEntities1 BDD;
        public sessionMedecin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BDD = new Northern_Lights_HospitalEntities1();
            dpConge.SelectedDate = DateTime.Today;
            //Affichage de la vue crée (seulement les lits occupés sont affichés)
            dgConge.DataContext = BDD.AdminLitMedPatient.ToList();
        }

        
        private void btnAutoriser_Click(object sender, RoutedEventArgs e)
        {
            AdminLitMedPatient vue = dgConge.SelectedItem as AdminLitMedPatient;

            //instanciation de admin et lit en liant les tables d'origines aux vues 
            Admission admin = BDD.Admission.FirstOrDefault(s => s.IDAdmission == vue.NoAdmission);
            Lit lit = BDD.Lit.FirstOrDefault(t => t.Numero_lit == vue.NoLit);

            //Validation que la date est égales ou supérieure à celle d'aujourd'hui
            if (dpConge.SelectedDate >= DateTime.Today)
            {
                    //Application de la date du congé et changement de status du lit à false
                    try
                    {
                        admin.date_du_congé = dpConge.SelectedDate;
                        lit.occupe = false;
                        BDD.SaveChanges();
                        MessageBox.Show("Le congé a bien été accordé!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                
            }
            else MessageBox.Show("La date entrée est invalide!");

            //Rafraîchissement du datagrid pour enlever le congé ayant été accordé
            dgConge.DataContext = BDD.AdminLitMedPatient.ToList();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Acceuil acceuil = new Acceuil();       
            this.Hide();
            acceuil.Show();
        }
    }
}
