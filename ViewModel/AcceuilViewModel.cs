using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Model;
using System.Windows.Input;
using System.Windows.Controls;
using MaltAirAtlantique.View;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Helper;

namespace MaltAirAtlantique.ViewModel
{
    public class AcceuilViewModel : ViewModelBase,  IAcceuilView
    {
        

        #region Interface Properties/Accessors
        
        private List<Notification> _notification;
        public List<Notification> Notification
        {
            get { return _notification; }
            set { NotifyPropertyChanged(ref _notification, value); }
        }
        #endregion


        #region Private properties

        private LaNavigation navigate = new LaNavigation();

        #endregion

        public AcceuilViewModel()
        {
            
            this.GoToListeFormationCommand = new RelayCommand(GoToListeFormation);
            this.GoToListeEmployeeCommand = new RelayCommand(GoToListeEmployee);
            this.GoToListePosteCommand = new RelayCommand(GoToListePoste);
            this.GoToListeSessionCommand = new RelayCommand(GoToListeSession);
            this.GoToNotificationCommand = new RelayCommand(GoToNotification);


        }

        #region ICommand
        public ICommand GoToListeFormationCommand { get; private set; }
        public ICommand GoToListeEmployeeCommand { get; private set; }
        public ICommand GoToListeSessionCommand { get; private set; }
        public ICommand GoToListePosteCommand { get; private set; }
        public ICommand GoToNotificationCommand { get; private set; }
        public ICommand GoToAccesCommand { get; private set; }
        #endregion


        #region private Methods

        private void GoToListeFormation()
        {

            navigate.NavigateToListeFormation();
            
        }

        private void GoToListePoste()
        {

            navigate.NavigateToListePoste();

        }

        private void GoToListeEmployee()
        {

            navigate.NavigateToListeEmployee();

        }
        private void GoToListeSession()
        {

            navigate.NavigateToListeSession();

        }
        private void GoToNotification()
        {

            navigate.NavigateToNotification();

        }

        #endregion

    }
}
