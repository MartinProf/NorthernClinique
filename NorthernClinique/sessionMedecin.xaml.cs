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

            dgConge.DataContext = generationDataGrid();
            dpConge.SelectedDate = DateTime.Now;
        }

        private void btnAutoriser_Click(object sender, RoutedEventArgs e)
        {
            BDD = new Northern_Lights_HospitalEntities1();

            int leNSS = 1;

            var unPatient = BDD.Admission.Where(s => s.NSS == leNSS).First();
            unPatient.date_du_congé = dpConge.SelectedDate;

            //update Admission SET date_du_congé = 2022 - 01 - 01 WHERE IDAdmission = 1;


            try
            {
                BDD.SaveChanges();
                MessageBox.Show("Congé accordé!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
    }
}
