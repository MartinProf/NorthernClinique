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
            dgConge.DataContext = BDD.Admission.Where(a => a.date_du_congé == null).ToList();
            comboboxIdadmission.DataContext = BDD.Admission.Where(a => a.date_du_congé == null).ToList();
            dpConge.SelectedDate = DateTime.Today;
        }

        private void btnAutoriser_Click(object sender, RoutedEventArgs e)
        {
            BDD = new Northern_Lights_HospitalEntities1();
            Admission admission = comboboxIdadmission.SelectedItem as Admission;

            if (dpConge.SelectedDate >= DateTime.Today)
            {
                try {
                    miseAjourAdmission(admission.IDAdmission, (DateTime)dpConge.SelectedDate);
                    miseAJourLit(admission.Numero_lit);
                    BDD.SaveChanges();
                    MessageBox.Show("Congé accordé!");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

            }else MessageBox.Show("Transaction refusé, la date entrée est non valide!");

            dgConge.DataContext = BDD.Admission.Where(a => a.date_du_congé == null).ToList();
        }

        private List<dynamic> generationDataGrid() 
        {
            var query =
                from a in BDD.Admission
                join p in BDD.Patient on a.NSS equals p.NSS
                join l in BDD.Lit on a.Numero_lit equals l.Numero_lit
                join m in BDD.Medecin on a.IDMedecin equals m.IDMedecin
                select new { a.NSS, Patient = p.nom + p.prenom, ID = a.IDMedecin, Medecin = m.nom + m.prenom, Lit = a.Numero_lit, Status = l.occupe, Admission = a.date_admission, Conge = a.date_du_congé };

            return query.AsEnumerable().Cast<dynamic>().ToList<dynamic>();
        }

        public static void miseAJourLit(int numeroDuLit)
        {
            var BDD = new Northern_Lights_HospitalEntities1();
            {
                Lit lit = BDD.Lit.FirstOrDefault(t => t.Numero_lit == numeroDuLit);
                if (lit != null)
                {
                    lit.occupe = false;
                    BDD.SaveChanges();
                }
            }
        }

        public static void miseAjourAdmission(int idAdmission, DateTime date) 
        {
            var BDD = new Northern_Lights_HospitalEntities1();
            {
                Admission admission = BDD.Admission.FirstOrDefault(t => t.IDAdmission == idAdmission);
                if (admission != null)
                {
                    admission.date_du_congé = date;
                    BDD.SaveChanges();
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = new Acceuil();
            this.Close();
            window.Show();
        }
    }
}
