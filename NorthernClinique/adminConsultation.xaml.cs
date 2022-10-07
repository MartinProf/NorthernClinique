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
    /// Logique d'interaction pour adminConsultation.xaml
    /// </summary>
    public partial class adminConsultation : Window
    {
        public adminConsultation()
        {
            InitializeComponent();
        }

        private void MenuQuitter_Click(object sender, RoutedEventArgs e)
        {
            Window window = new sessionAdmin();
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            frameConsul.Content = new tableauConsultation();
        }
    }
}
