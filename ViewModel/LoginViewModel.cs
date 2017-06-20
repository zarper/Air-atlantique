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
    public class LoginViewModel : ViewModelBase, ILoginView
    {

        #region Interface Properties/Accessors

        private List<Notification> _notification;
        public List<Notification> Notification
        {
            get { return _notification; }
            set { NotifyPropertyChanged(ref _notification, value); }
        }
        #endregion

        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion

        public LoginViewModel()
        {
            this.GoToListeFormationCommand = new RelayCommand(GoToListeFormation);
        }


        #region ICommand
        public ICommand GoToListeFormationCommand { get; private set; }
        #endregion


        #region Methods
        private void GoToListeFormation()
        {

            navigate.NavigateToListeFormation();

        }
        #endregion
    }
}
