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
    public class DetailEmployeeViewModel : ViewModelBase, IDetailEmployeeView
    {
        #region Interface Properties/Accessors


        private Employee _employeeConcerne = new Employee();
        public Employee EmployeeConcerne
        {
            get { return _employeeConcerne; }
            set { NotifyPropertyChanged(ref _employeeConcerne, value); }
        }


        private SessionEmployee _sessionSelectionner;
        public SessionEmployee SessionSelectionner
        {
            get { return _sessionSelectionner; }
            set { NotifyPropertyChanged(ref _sessionSelectionner, value); }
        }

        private Formation _ajouterformationSelectionner;
        public Formation AjouterFormationSelectionner
        {
            get { return _ajouterformationSelectionner; }
            set { NotifyPropertyChanged(ref _ajouterformationSelectionner, value); }
        }


        private EmployeeFormation _employeFormationSelectionner;
        public EmployeeFormation EmployeFormationSelectionner
        {
            get { return _employeFormationSelectionner; }
            set { NotifyPropertyChanged(ref _employeFormationSelectionner, value); }
        }

        private ObservableCollection<Formation> _listeFormation;
        public ObservableCollection<Formation> ListeFormation
        {
            get { return _listeFormation; }
            set { NotifyPropertyChanged(ref _listeFormation, value); }
        }
        #endregion



        #region privatePropetie
        LaNavigation navigate = new LaNavigation();
        #endregion


        public DetailEmployeeViewModel()
        {

            this.EmployeeConcerne = DAOEmploye.ConctructeurEmploye(LaNavigation.Employee);
            this.ListeFormation = DAOFormation.ListerFormationPourUnEmployee(EmployeeConcerne);
            this.DetailFormationCommand = new RelayCommand(DetailFormation);
            this.DetailSessionCommand = new RelayCommand(DetailSession);
            this.AjouterFormationCommand = new RelayCommand(AjouterEmployeeFormation);

        }


        public ICommand DetailSessionCommand { get; private set; }
        public ICommand DetailFormationCommand { get; private set; }
        public ICommand AjouterFormationCommand { get; private set; }

        #region private Methods


        private void AjouterEmployeeFormation()
        {
            EmployeeFormation ef = new EmployeeFormation
            {
                EmployeeConcerne = EmployeeConcerne,
                FormationConcerne = AjouterFormationSelectionner
                
            };

            DAOEmployeeFormation.AjouterEmployeeFormation(ef);
            EmployeeConcerne = DAOEmploye.ConctructeurEmploye(EmployeeConcerne);

        }

     



        private void DetailSession()
        {
            if (SessionSelectionner.SessionConcerne != null)
            {
                LaNavigation.Session = SessionSelectionner.SessionConcerne;
                navigate.NavigateToDetailSession();
            }
        }


        private void DetailFormation()
        {
            if (this.EmployeFormationSelectionner != null)
            {
                LaNavigation.Formation = this.EmployeFormationSelectionner.FormationConcerne;
                navigate.NavigateToDetailFormation();
            }
        }

        #endregion
    }
}
