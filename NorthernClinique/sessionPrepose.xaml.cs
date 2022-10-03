using System;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProcessusAdmission processusAdmission = new ProcessusAdmission();
            processusAdmission.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RecherchePatient recherchePatient = new RecherchePatient();
            recherchePatient.Show();
            this.Close();
        }
    }
}
