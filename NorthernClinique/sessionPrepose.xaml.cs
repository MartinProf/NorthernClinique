﻿using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour sessionPrepose.xaml
    /// </summary>
    public partial class sessionPrepose : Window
    {
        public sessionPrepose()
        {
            InitializeComponent();
        }

        private void btnAdmission_Click(object sender, RoutedEventArgs e)
        {
            ProcessusAdmission processusAdmission = new ProcessusAdmission();
            processusAdmission.Show();
            this.Hide();
        }

        private void btnPatient_Click(object sender, RoutedEventArgs e)
        {
            RecherchePatient recherchePatient = new RecherchePatient();
            recherchePatient.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Acceuil acceuil = new Acceuil();
            acceuil.Show();
            this.Hide();
        }
    }
}
