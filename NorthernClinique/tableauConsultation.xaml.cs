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

            var query =
                from m in myBDD.Medecin
                select new { Médecin_traitant = m.prenom + " " + m.nom };
            dataGridConsul.DataContext = query.ToList();
        }
    }
}
