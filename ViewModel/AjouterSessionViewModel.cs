using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Helper;
using System.Windows.Input;
using MaltAirAtlantique.Model;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    public class AjouterSessionViewModel : ViewModelBase, IAjouterSessionView
    {
        #region Interface Properties/Accessors


        private Session _sessionNouvelle = new Session();
        public Session SessionNouvelle
        {
            get { return _sessionNouvelle; }
            set { NotifyPropertyChanged(ref _sessionNouvelle, value); }
        }

        private Formation _formationConcerne = new Formation();
        public Formation FormationConcerne
        {
            get { return _formationConcerne; }
            set { NotifyPropertyChanged(ref _formationConcerne, value); }
        }

        private OrganismeFormation _organismeFormationConcerne = new OrganismeFormation();
        public OrganismeFormation OrganismeFormationConcerne
        {
            get { return _organismeFormationConcerne; }
            set { NotifyPropertyChanged(ref _organismeFormationConcerne, value); }
        }

        private bool _nameSkype;
        public bool NameSkype
        {
            get { return _nameSkype; }
            set { NotifyPropertyChanged(ref _nameSkype, value); }



        }

        
        #endregion





        public AjouterSessionViewModel()
        {
            
            this.FormationConcerne = DAOFormation.ConstructeurFormation(LaNavigation.Formation);
            this.OrganismeFormationConcerne.FormationConcerne = FormationConcerne;
            this.AjouterSessionCommand = new RelayCommand(AjouterSession);
            this.AppelSkypeCommand = new RelayCommand(AppelSkype);


        }

        #region Private Properties

        LaNavigation navigate = new LaNavigation();
        #endregion


        public ICommand AjouterSessionCommand { get; private set; }
        public ICommand AppelSkypeCommand { get; private set; }
        #region private Methods

        private void AjouterSession()
        {
            
            DAOSession.AjouterSession(SessionNouvelle, OrganismeFormationConcerne);

            navigate.NavigateToAjouterSession();
        }
        private void AppelSkype()
        {
            this.OrganismeFormationConcerne.OrganismeConcerne.CallToBySkype();
        }
        #endregion
    }
}
