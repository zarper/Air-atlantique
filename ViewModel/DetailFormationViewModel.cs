using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;

using MaltAirAtlantique.Helper;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Model;
using MaltAirAtlantique.Model.DAO;


namespace MaltAirAtlantique.ViewModel
{
    public class DetailFormationViewModel : ViewModelBase, IDetailFormationView
    {
        #region Interface Properties/Accessors


        private Formation _formation = new Formation();
        public Formation Formation
        {
            get { return _formation; }
            set { NotifyPropertyChanged(ref _formation, value); }
        }

        private OrganismeFormation _organismeFormationSelectionner;
        public OrganismeFormation OrganismeFormationSelectionner
        {
            get { return _organismeFormationSelectionner; }
            set { NotifyPropertyChanged(ref _organismeFormationSelectionner, value); }
        }

        private ObservableCollection<Session> _listeSessionConcerne = new ObservableCollection<Session>();
        public ObservableCollection<Session> ListeSessionConcerne
        {
            get { return _listeSessionConcerne; }
            set { NotifyPropertyChanged(ref _listeSessionConcerne, value); }



        }

        private Session _sessionSelectionner = new Session();
        public Session SessionSelectionner
        {
            get { return _sessionSelectionner; }
            set { NotifyPropertyChanged(ref _sessionSelectionner, value); }



        }
        #endregion

        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion



        public DetailFormationViewModel()
        {

            this.Formation = DAOFormation.ConstructeurFormation(LaNavigation.Formation);

            this.ListeSessionConcerne = DAOSession.ListerSessionPourUneFormation(Formation);
            this.CreerSessionCommand = new RelayCommand(CreerSession);
            this.AjouterOrganismeFormationCommand = new RelayCommand(AjouterOrganismeFormation);
            this.DetailOrganismeCommand = new RelayCommand(DetailOrganisme);
            this.DetailSessionCommand = new RelayCommand(DetailSession);
            
    }


     


        public ICommand CreerSessionCommand { get; private set; }
        public ICommand AjouterOrganismeFormationCommand { get; private set; }
        public ICommand DetailOrganismeCommand { get; private set; }
        public ICommand DetailSessionCommand { get; private set; }
        #region private Methods

       



        private void CreerSession()
        {
            LaNavigation.Formation = Formation;
            navigate.NavigateToAjouterSession();  
        }

        private void DetailSession()
        {
            LaNavigation.Session = SessionSelectionner;
            navigate.NavigateToDetailSession();
        }

        private void AjouterOrganismeFormation()
        {
            
            navigate.NavigateToAjouterOrganismeFormation();
        }

        private void DetailOrganisme()
        {

                LaNavigation.Organisme = OrganismeFormationSelectionner.OrganismeConcerne;
                navigate.NavigateToDetailOrganisme();
            
        }

        #endregion
    }
}

