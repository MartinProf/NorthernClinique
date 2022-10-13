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

            if(dpConge.SelectedDate >= DateTime.Today)
            {
                if (lit.occupe == true) {
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
                } else { MessageBox.Show("Le congé a déjà été accordé!"); }
            }
            else MessageBox.Show("La date entrée est invalide!");

            //BDD = new Northern_Lights_HospitalEntities1();
            //Admission admission = comboboxIdadmission.SelectedItem as Admission;

            //if (dpConge.SelectedDate >= DateTime.Today)
            //{
            //    try {
            //        miseAjourAdmission(admission.IDAdmission, (DateTime)dpConge.SelectedDate);
            //        miseAJourLit(admission.Numero_lit);
            //        BDD.SaveChanges();
            //        MessageBox.Show("Congé accordé!");
            //    }
            //    catch (Exception ex) {
            //        MessageBox.Show(ex.Message);
            //    }

            //}else MessageBox.Show("Transaction refusé, la date entrée est non valide!");

            //dgConge.DataContext = BDD.Admission.Where(a => a.date_du_congé == null).ToList();
        }

       
        //public static void miseAJourLit(int numeroDuLit)
        //{
        //    var BDD = new Northern_Lights_HospitalEntities1();
        //    {
        //        Lit lit = BDD.Lit.FirstOrDefault(t => t.Numero_lit == numeroDuLit);
        //        if (lit != null)
        //        {
        //            lit.occupe = false;
        //            BDD.SaveChanges();
        //        }
        //    }
        //}

        //public static void miseAjourAdmission(int idAdmission, DateTime date) 
        //{
        //    var BDD = new Northern_Lights_HospitalEntities1();
        //    {
        //        Admission admission = BDD.Admission.FirstOrDefault(t => t.IDAdmission == idAdmission);
        //        if (admission != null)
        //        {
        //            admission.date_du_congé = date;
        //            BDD.SaveChanges();
        //        }
        //    }
        //}

        private void Window_Closed(object sender, EventArgs e)
        {
            var acceuil = new Acceuil();
            acceuil.Show();
            this.Hide();
        }
    }
}
