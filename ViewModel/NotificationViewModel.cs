using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Model;
using MaltAirAtlantique.Helper;
using System.Windows.Input;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    public class NotificationViewModel : ViewModelBase, INotificationView
    {
        #region Interface Properties/Accessors


        private ObservableCollection<Session> _listeSessionAValider;
        public ObservableCollection<Session> ListeSessionAValider
        {
            get { return _listeSessionAValider; }
            set { NotifyPropertyChanged(ref _listeSessionAValider, value); }
        }

        private Session _sessionSelectionner;
        public Session SessionSelectionner
        {
            get { return _sessionSelectionner; }
            set { NotifyPropertyChanged(ref _sessionSelectionner, value); }
        }

        private ObservableCollection<EmployeeFormation> _listeEmployeeNonConforme;
        public ObservableCollection<EmployeeFormation> ListeEmployeeNonConforme
        {
            get { return _listeEmployeeNonConforme; }
            set { NotifyPropertyChanged(ref _listeEmployeeNonConforme, value); }
        }

        private EmployeeFormation _eFSelectionner;
        public EmployeeFormation EFSelectionner
        {
            get { return _eFSelectionner; }
            set { NotifyPropertyChanged(ref _eFSelectionner, value); }
        }


        #endregion



        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion

        public NotificationViewModel()
        {
            this.ListeSessionAValider = DAOSession.ListerSessionFinisNonValider();
            this.ValiderSessionCommand = new RelayCommand(ValiderSession);
            this.DetailSessionCommand = new RelayCommand(DetailSession);
            this.ListeEmployeeNonConforme = DAOEmployeeFormation.ListerEmployeeFormationManquante();
            this.DetailEmployeeCommand = new RelayCommand(DetailEmployee);
            this.CreerSessionCommand = new RelayCommand(CreerSession);
        }





        public ICommand ValiderSessionCommand { get; private set; }
        public ICommand DetailSessionCommand { get; private set; }
        public ICommand DetailEmployeeCommand { get; private set; }
        public ICommand CreerSessionCommand { get; private set; }




        #region private Methods

        private void AjouterSession()
        {
            navigate.NavigateToAjouterSession();
        }

        private void DetailSession()
        {
            if (SessionSelectionner != null)
            {
                LaNavigation.Session = SessionSelectionner;
                navigate.NavigateToDetailSession();
            }
        }

        private void DetailEmployee()
        {
            if (EFSelectionner != null)
            {
                LaNavigation.Employee = EFSelectionner.EmployeeConcerne;
                navigate.NavigateToDetailEmployee();
            }
        }


        private void CreerSession()
        {
            if (EFSelectionner != null)
            {
                LaNavigation.Formation = EFSelectionner.FormationConcerne;
                navigate.NavigateToAjouterSession();
            }
        }

        private void ValiderSession()
        {
            if (SessionSelectionner != null)
            {
                DAOSession.ValiderSession(SessionSelectionner);
                navigate.NavigateToNotification();
            }
        }

        #endregion


    }
}
