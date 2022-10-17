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
            //dgConge.DataContext = BDD.Admission.Where(a => a.date_du_congé == null).ToList();
            //comboboxIdadmission.DataContext = BDD.Admission.Where(a => a.date_du_congé == null).ToList();
            dpConge.SelectedDate = DateTime.Today;
            dgConge.DataContext = BDD.AdminLitMedPatient.ToList();
        }

        private void btnAutoriser_Click(object sender, RoutedEventArgs e)
        {
            AdminLitMedPatient vue = dgConge.SelectedItem as AdminLitMedPatient;

            Admission admin = BDD.Admission.FirstOrDefault(s => s.IDAdmission == vue.NoAdmission);
            Lit lit = BDD.Lit.FirstOrDefault(t => t.Numero_lit == vue.NoLit);

            if (dpConge.SelectedDate >= DateTime.Today)
            {
                if (lit.occupe == true)
                {
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
                else { MessageBox.Show("Le congé a déjà été accordé!"); }
            }
            else MessageBox.Show("La date entrée est invalide!");

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
