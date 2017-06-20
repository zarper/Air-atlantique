using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Model;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Helper;
using System.Windows.Input;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    public class DetailSessionViewModel : ViewModelBase, IDetailSessionView
    {
        #region Interface Properties/Accessors


        private Session _sessionConcerne = new Session();
        public Session SessionConcerne
        {
            get { return _sessionConcerne; }
            set { NotifyPropertyChanged(ref _sessionConcerne, value); }
        }

        private ObservableCollection<Employee> _listeEmployeeManquant = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> ListeEmployeeManquant
        {
            get { return _listeEmployeeManquant; }
            set { NotifyPropertyChanged(ref _listeEmployeeManquant, value); }
        }

        private int _nbrPlaceRestante;
        public int NbrPlaceRestante
        {
            get { return _nbrPlaceRestante; }
            set { NotifyPropertyChanged(ref _nbrPlaceRestante, value); }
        }

        private double _prixTotal;
        public double PrixTotal
        {
            get { return _prixTotal; }
            set { NotifyPropertyChanged(ref _prixTotal, value); }
        }

        private Employee _ajouterEmployeeSelectionner;
        public Employee AjouterEmployeeSelectionner
        {
            get { return _ajouterEmployeeSelectionner; }
            set { NotifyPropertyChanged(ref _ajouterEmployeeSelectionner, value); }
        }

        private SessionEmployee _detailEmployeeSelectionner;
        public SessionEmployee DetailEmployeeSelectionner
        {
            get { return _detailEmployeeSelectionner; }
            set { NotifyPropertyChanged(ref _detailEmployeeSelectionner, value); }
        }
        #endregion

        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion

        public DetailSessionViewModel()
        {

            this.SessionConcerne = DAOSession.ConstructeurSession(LaNavigation.Session);
            this._nbrPlaceRestante = SessionConcerne.NbrPlaceTotal - SessionConcerne.ListeEmployeeConcernees.Count();
            this.PrixTotal = SessionConcerne.OrganismeFomationConcerne.Prix * SessionConcerne.NbrPlaceTotal;
            this.ListeEmployeeManquant = DAOEmploye.ListerEmployeeManquantAUneSession(SessionConcerne);
            this.DetailOrganismeCommand = new RelayCommand(DetailOrganisme);
            this.AjouterEmployeeCommand = new RelayCommand(AjouterEmployee);
            this.DetailEmployeeCommand = new RelayCommand(DetailEmployee);
            this.DetailFormationCommand = new RelayCommand(DetailFormation);
        }



        public ICommand CreerSessionCommand { get; private set; }
        public ICommand AjouterEmployeeCommand { get; private set; }
        public ICommand DetailEmployeeCommand { get; private set; }
        public ICommand DetailOrganismeCommand { get; private set; }
        public ICommand DetailFormationCommand { get; private set; }


        #region private Methods




      



        private void DetailOrganisme()
        {
            if (this.SessionConcerne.OrganismeFomationConcerne.OrganismeConcerne != null)
            {
                LaNavigation.Organisme = this.SessionConcerne.OrganismeFomationConcerne.OrganismeConcerne;
                navigate.NavigateToDetailOrganisme();
            }
        }


        private void DetailFormation()
        {
            if (SessionConcerne.OrganismeFomationConcerne.FormationConcerne != null)
            {
                LaNavigation.Formation = this.SessionConcerne.OrganismeFomationConcerne.FormationConcerne;
                navigate.NavigateToDetailFormation();
            }
        }



        private void DetailEmployee()
        {
            if (DetailEmployeeSelectionner.EmployeeConcerne != null)
            {
                LaNavigation.Employee = DetailEmployeeSelectionner.EmployeeConcerne;
                navigate.NavigateToDetailEmployee();
            }
        }


        private void AjouterEmployee()
        {
            SessionEmployee SENouveau = new SessionEmployee
            {
                EmployeeConcerne = AjouterEmployeeSelectionner,
            SessionConcerne = SessionConcerne
        };
            DAOSessionEmploye.AjouterSessionEmployee(SENouveau);


            navigate.NavigateToDetailSession();
        }
        #endregion
    }
}
