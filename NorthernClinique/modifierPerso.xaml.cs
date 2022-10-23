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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NorthernClinique
{
    /// <summary>
    /// Logique d'interaction pour modifierPerso.xaml
    /// </summary>

    public partial class modifierPerso : Page
    {
        Northern_Lights_HospitalEntities1 myBDD;
        public modifierPerso()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            myBDD = new Northern_Lights_HospitalEntities1();
            Medecin medecin = comboBIDMedecin.SelectedItem as Medecin;

            comboBIDMedecin.DataContext = myBDD.Medecin.ToList();
        }

        private void comboBIDMedecin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Medecin medecin = comboBIDMedecin.SelectedItem as Medecin;

            textBoxNom.Text = medecin.nom.ToString();
            textBoxPrenom.Text = medecin.prenom.ToString();
        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            Medecin medecin = comboBIDMedecin.SelectedItem as Medecin;

            if(string.IsNullOrEmpty(textBoxNom.Text) || string.IsNullOrEmpty(textBoxNom.Text)) 
            {
                MessageBox.Show("Veuillez remplir tous les champs!");
            } else
            {
                //Modification du médecin en le sélectionnant avec son ID
                medecin.IDMedecin = int.Parse(comboBIDMedecin.Text);
                medecin.nom = textBoxNom.Text;
                medecin.prenom = textBoxPrenom.Text;

                try
                {
                    myBDD.SaveChanges();
                    MessageBox.Show("Modification du medecin fait avec succès");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

            //Animationm du bouton lors du click
            DoubleAnimation da = new DoubleAnimation();
            DoubleAnimation da2 = new DoubleAnimation();
            da.From = 75;
            da.To = 105;
            da2.From = 190;
            da2.To = 220;
            da.Duration = new Duration(TimeSpan.FromSeconds(1));
            da.AutoReverse = true;
            da2.AutoReverse = true;
            btnModifier.BeginAnimation(Button.HeightProperty, da);
            btnModifier.BeginAnimation(Button.WidthProperty, da2);

        }

    }
}
