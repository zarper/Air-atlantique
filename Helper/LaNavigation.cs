using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaltAirAtlantique.View;
using System.Windows.Media;
using MaltAirAtlantique.Model;

namespace MaltAirAtlantique.Helper
{
    // Partie qui permet de gerer la navigation WPF
    class LaNavigation
    {
        public static AcceuilView  Accueil {get ; set;}

        public static LoginView Login { get; set; }

        public void NavigateToListeAcceuilFormation()
        {
            Init();
            InitVariable();
            Accueil.stkContenu.Content = new ListeFormationViewCU();
            Accueil.MenuFormation.IsEnabled = false;
            Accueil.MenuFormation.Background = Brushes.Azure;
        }

        public static Formation Formation { get; set; }
        public static Poste Poste { get; set; }
        public static Session Session { get; set; }
        public static Employee Employee { get; set; }
        public static Organisme Organisme { get; set; }


        public void NavigateToListeFormation()
        {
            Init();
            InitVariable();
            Accueil.stkContenu.Content = new ListeFormationViewCU();
            Accueil.MenuFormation.IsEnabled = false;
            Accueil.MenuFormation.Background = Brushes.Azure;
        }

        public void NavigateToListeEmployee()
        {
            Init();
            InitVariable();
            Accueil.stkContenu.Content = new ListeEmployeeViewCU();
            Accueil.MenuEmployee.IsEnabled = false;
            Accueil.MenuEmployee.Background = Brushes.Azure;
        }


        public void NavigateToListeSession()
        {
            Init();
            InitVariable();
            Accueil.stkContenu.Content = new ListeSessionViewCU();
            Accueil.MenuSession.IsEnabled = false;
            Accueil.MenuSession.Background = Brushes.Azure;
        }

        public void NavigateToListePoste()
        {
            Init();
            InitVariable();
            Accueil.MenuPoste.IsEnabled = false;
            Accueil.MenuPoste.Background = Brushes.Azure;
            Accueil.stkContenu.Content = new ListePosteViewCU();

        }

        public void NavigateToAjouterSession()
        {
            Init();
            Accueil.stkContenu.Content = new AjouterSessionViewCU();
        }

        public void NavigateToAjouterFormation()
        {
            Init();
            Accueil.stkContenu.Content = new AjouterFormationViewCU();

        }

        public void NavigateToAjouterEmployee()
        {
            Init();
            Accueil.stkContenu.Content = new AjouterEmployeeViewCU();

        }

        public void NavigateToDetailFormation()
        {
            if (Formation != null)
            {
                Init();

                Accueil.stkContenu.Content = new DetailFormationViewCU();
            }

        }

        public void NavigateToDetailSession()
        {
            if (Session != null)
            {
                Init();
                Accueil.stkContenu.Content = new DetailSessionViewCU();
            }
        }


        public void NavigateToDetailPoste()
        {
            if (Poste != null)
            {
                Init();
                Accueil.stkContenu.Content = new DetailPosteViewCU();
            }
            
        }

        public void NavigateToDetailEmployee()
        {
            if (Employee != null)
            {
                Init();
                Accueil.stkContenu.Content = new DetailEmployeeViewCU();
            }
        }

        public void NavigateToDetailOrganisme()
        {
            if (Organisme != null)
            {
                Init();
                Accueil.stkContenu.Content = new DetailOrganismeViewCU();
            }
        }



        public void NavigateToNotification()
        {
            Init();
            InitVariable();
            Accueil.stkContenu.Content = new NotificationViewCU();

        }

        public void NavigateToAjouterOrganismeFormation()
        {
            Init();
            Accueil.stkContenu.Content = new AjouterOFViewCU();

        }

        public void NavigateToAjouterPoste()
        {
            Init();
            Accueil.stkContenu.Content = new AjouterPosteViewCU();

        }

        /*public void NavigateToGestionacces()
        {
            if (Employee != null)
            {
                Init();
                Accueil.stkContenu.Content = new GestionaccesViewCU();
            }

        }*/






        private void Init()
        {
            Accueil.MenuAcceuil.IsEnabled = true;
            Accueil.MenuEmployee.IsEnabled = true;
            Accueil.MenuFormation.IsEnabled = true;
            Accueil.MenuSession.IsEnabled = true;
            Accueil.MenuPoste.IsEnabled = true;
            Accueil.MenuAcceuil.Background = null;
            Accueil.MenuEmployee.Background= null;
            Accueil.MenuFormation.Background = null;
            Accueil.MenuSession.Background = null;
            Accueil.MenuPoste.Background = null;
        }

        private void InitVariable()
        {
            Formation = null;
            Organisme = null;
            Session = null;
            Poste = null;
            Employee = null;
        }
    }
}
