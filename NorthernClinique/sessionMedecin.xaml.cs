﻿using System;
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

            var query =
                from a in BDD.Admission
                join p in BDD.Patient on a.NSS equals p.NSS
                select new { a.NSS, p.nom, p.prenom, a.IDMedecin, a.Numero_lit, a.date_admission, a.date_du_congé };

            dgConge.DataContext = query.ToList(); 
        }

        
    }
}
