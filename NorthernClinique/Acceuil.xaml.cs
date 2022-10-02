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
    /// Logique d'interaction pour Acceuil.xaml
    /// </summary>
    public partial class Acceuil : Window
    {
        List<Utilisateur> utilisateurs;
        public Acceuil()
        {
            InitializeComponent();

            utilisateurs = new List<Utilisateur>
            {
                new Utilisateur{nomUtilisateur = "admin", motPasse = "admin", posteOccupe = "Administrateur"},
                new Utilisateur{nomUtilisateur = "medecin", motPasse = "medecin", posteOccupe = "Medecin"},
                new Utilisateur{nomUtilisateur = "prepose", motPasse = "prepose", posteOccupe = "Prepose"}
            };
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(pwLogin.Password)||cboLogin.SelectedItem==null)
            {
                MessageBox.Show("Entrez un nom d'utilisateur, un mot de passe et le poste occupé!", "Attention!");
                txtLogin.Text = "";
                pwLogin.Password = "";
                cboLogin.SelectedItem = null;
            }
            else
            {
                Utilisateur utilisateur = trouverUtilisateur(txtLogin.Text, pwLogin.Password, cboLogin.Text);
                if (utilisateur != null)
                {
                    Application.Current.Properties["nomUtilisateur"] = utilisateur.nomUtilisateur;
                    Application.Current.Properties["motPasse"] = utilisateur.motPasse;
                    Application.Current.Properties["posteOccupe"] = utilisateur.posteOccupe;
                    txtLogin.Text = "";
                    pwLogin.Password = "";
                    cboLogin.SelectedItem = null;
                    if(Application.Current.Properties["posteOccupe"].ToString() == "Administrateur")
                    {
                        sessionAdmin sessionAdmin = new sessionAdmin();
                        sessionAdmin.Show();
                        this.Close();
                    }
                    else if (Application.Current.Properties["posteOccupe"].ToString() == "Medecin")
                    {
                        sessionMedecin sessionMedecin = new sessionMedecin();
                        sessionMedecin.Show();
                        this.Close();
                    }
                    else
                    {
                        sessionPrepose sessionPrepose = new sessionPrepose();   
                        sessionPrepose.Show();
                        this.Close();
                    }

                }
                else
                    MessageBox.Show("Utilisateur inexistant!", "Attention!");


            }
        }

        private Utilisateur trouverUtilisateur(string nomUtilisateur, string motPasse, string posteOccupe)
        {
            Utilisateur utilisateur = utilisateurs.SingleOrDefault(s => s.nomUtilisateur == nomUtilisateur && s.motPasse == motPasse && s.posteOccupe == posteOccupe);
            return utilisateur;
        }
    }

}
