using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Helper;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Model;
using System.Windows.Input;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    class GestionDroitEmployeViewModel : ViewModelBase, IGestionaccesView
    {
        #region Interface Properties/Accessors
        private Employee _employeeselectione = new Employee();
        public Employee EmployeeSelectione
        {
            get { return _employeeselectione; }
            set { NotifyPropertyChanged(ref _employeeselectione, value); }
        }

        private SessionEmployee _sessionSelectionner;
        public SessionEmployee SessionSelectionner
        {
            get { return _sessionSelectionner; }
            set { NotifyPropertyChanged(ref _sessionSelectionner, value); }
        }
        #endregion

        #region privatePropetie
        LaNavigation navigate = new LaNavigation();
        #endregion



        /*public GestionDroitEmployeViewModel(string niveauacces)
        {
            switch (niveauacces)
            {
                case "777":
                    //a tout les droits et permet de gerer les droits
                this.EmployeeSelectione.Acces = 421;
                    break;
                case "666":
                    //a tout les droits mais ne permet pas de gerer les droits
                    this.EmployeeSelectione.Acces = 666;
                    break;
                case "700":
                    this.EmployeeSelectione.Acces = 660;
                    break;
                case "700":
                    this.EmployeeSelectione.Acces = 660;
                    break;
                case "700":
                    this.EmployeeSelectione.Acces = 660;
                    break;
                default:
                    break;
            }     
        }*/

        public ICommand DetailSessionCommand { get; private set; }

        #region private Methods



        private void DetailSession()
        {
            if (SessionSelectionner.SessionConcerne != null)
            {
                LaNavigation.Session = SessionSelectionner.SessionConcerne;
                navigate.NavigateToDetailSession();
            }
        }

        #endregion
    }
}
