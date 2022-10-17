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
    /// Logique d'interaction pour sessionAdmin.xaml
    /// </summary>
    public partial class sessionAdmin : Window
    {
        public sessionAdmin()
        {
            InitializeComponent();
        }

        private void btnPersonnel_Click(object sender, RoutedEventArgs e)
        {
            Window window = new adminPersonnel();
            this.Hide();
            window.Show();
        }

        private void btnConsultation_Click(object sender, RoutedEventArgs e)
        {
            Window window = new adminConsultation();
            this.Hide();
            window.Show();
        }

    }
}