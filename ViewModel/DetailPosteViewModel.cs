using MaltAirAtlantique.Helper;
using MaltAirAtlantique.Model;
using MaltAirAtlantique.ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    public class DetailPosteViewModel : ViewModelBase, IDetailPosteView
    {
        #region Interface Properties/Accessors


        private Poste _posteConcerne;
        public Poste PosteConcerne
        {
            get { return _posteConcerne; }
            set { NotifyPropertyChanged(ref _posteConcerne, value); }
        }

        private ObservableCollection<Formation> _listeFormation;
        public ObservableCollection<Formation> ListeFormation
        {
            get { return _listeFormation; }
            set { NotifyPropertyChanged(ref _listeFormation, value); }
        }

        private Formation _detailFormationSelectionner;
        public Formation DetailFormationSelectionner
        {
            get { return _detailFormationSelectionner; }
            set { NotifyPropertyChanged(ref _detailFormationSelectionner, value); }
        }

        private Employee _detailEmployeeSelectionner;
        public Employee DetailEmployeeSelectionner
        {
            get { return _detailEmployeeSelectionner; }
            set { NotifyPropertyChanged(ref _detailEmployeeSelectionner, value); }
        }

        private Formation _ajouterFormationSelectionner;
        public Formation AjouterFormationSelectionner
        {
            get { return _ajouterFormationSelectionner; }
            set { NotifyPropertyChanged(ref _ajouterFormationSelectionner, value); }
        }
        #endregion

        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion

        public DetailPosteViewModel()
        {
            PosteConcerne = DAOPoste.ConstructeurPoste(LaNavigation.Poste);
            ListeFormation = DAOFormation.ListerFormationObligatoirePoste(PosteConcerne);
            this.AjouterFormationCommand = new RelayCommand(AjouterFormation);
            this.DetailFormationCommand = new RelayCommand(DetailFormation);
            this.DetailEmployeeCommand = new RelayCommand(DetailEmployee);
           
        }



        public ICommand AjouterFormationCommand { get; private set; }
        public ICommand DetailFormationCommand { get; private set; }
        public ICommand DetailEmployeeCommand { get; private set; }
        public ICommand SuppressionFormationCommand { get; private set; }

        #region private Methods


       

        private void AjouterFormation()
        {
            if (AjouterFormationSelectionner != null) {

                DAOPosteFormation.AjouterPosteFormation(AjouterFormationSelectionner, PosteConcerne);
                navigate.NavigateToDetailPoste();
            }
        }


        private void DetailFormation()
        {
            if (DetailFormationSelectionner != null)
            {
                LaNavigation.Formation = DetailFormationSelectionner;
                navigate.NavigateToDetailFormation();
            }
        }

        private void DetailEmployee()
        {
            if (DetailEmployeeSelectionner != null)
            {
                LaNavigation.Employee = DetailEmployeeSelectionner;
                navigate.NavigateToDetailEmployee();
            }
        }


        #endregion
    }


}

