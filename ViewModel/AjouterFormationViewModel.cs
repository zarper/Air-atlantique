using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Helper;
using System.Windows.Input;
using MaltAirAtlantique.Model;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    public class AjouterFormationViewModel : ViewModelBase, IAjouterFormationView
    {
        #region Interface Properties/Accessors


        private Formation _formation = new Formation();
        public Formation Formation
        {
            get { return _formation; }
            set { NotifyPropertyChanged(ref _formation, value); }
        }
        #endregion





        public AjouterFormationViewModel()
        {

 
            this.AjouterFormationCommand = new RelayCommand(AjouterFormation);
            this.ViderFormationCommand = new RelayCommand(ViderFormation);

        }

        #region Private Properties

        LaNavigation navigate = new LaNavigation();
        #endregion


        public ICommand AjouterFormationCommand { get; private set; }
        public ICommand ViderFormationCommand { get; private set; }

        #region private Methods


        private void AjouterFormation()
        {

            DAOFormation.AjouterFormationDB(Formation);
            navigate.NavigateToAjouterFormation();
        }

        private void ViderFormation()
        {
            Formation = new Formation();
        }
        #endregion
    }
}
