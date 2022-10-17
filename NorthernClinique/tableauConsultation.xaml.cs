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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NorthernClinique
{
    /// <summary>
    /// Logique d'interaction pour tableauConsultation.xaml
    /// </summary>
    public partial class tableauConsultation : Page
    {
        Northern_Lights_HospitalEntities1 myBDD;
        public tableauConsultation()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myBDD = new Northern_Lights_HospitalEntities1();

            labelTauxOcc.Content = (int)TauxOccupation() + "%";
            labelNombreMedecin.Content = NombreMedecin();
            labelPatientActif.Content = NombrePatient();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer.Start();
        }

        private bool BlinkOn = false;
        private void timer_Tick(object sender, EventArgs e)
        {
            if (BlinkOn)
            {
                lblTableauConsult.Foreground = Brushes.Orange;
            }
            else
            {
                lblTableauConsult.Foreground = Brushes.Black;
            }
            BlinkOn = !BlinkOn;
        }

        private float TauxOccupation() 
        {
            float queryOccupe = myBDD.Lit.Where(l => l.occupe==true).Count();
            float queryTotal = myBDD.Lit.Count();

            return queryOccupe / queryTotal * 100;
                
        }
        private int NombreMedecin() 
        {
            return myBDD.Medecin.Count();
        }

        private int NombrePatient()
        {
            return myBDD.Patient.Count();
        }
    }
}
