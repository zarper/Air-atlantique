using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.Helper;
using MaltAirAtlantique.ViewModel.Interface;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Model;
using System.Windows.Input;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    public class DetailOrganismeViewModel : ViewModelBase, IDetailOrganismeView
    {
        #region Interface Properties/Accessors


        private Organisme _organismeConcerne = new Organisme();
        public Organisme OrganismeConcerne
        {
            get { return _organismeConcerne; }
            set { NotifyPropertyChanged(ref _organismeConcerne, value); }



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
        private bool _nameSkype ;
        public bool NameSkype
        {
            get { return _nameSkype; }
            set { NotifyPropertyChanged(ref _nameSkype, value); }



        }
        #endregion

        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        public OrganismeFormation OrganismeFormationSelectionner { get; set; }
        #endregion



        public DetailOrganismeViewModel()
        {

            this.OrganismeConcerne = DAOOrganisme.ConstructeurOrganisme(LaNavigation.Organisme);
            this.DetailOrganismeFormationCommand = new RelayCommand(DetailOrganismeFormation);
            this.ListeSessionConcerne = DAOSession.ListerSessionPourUnOrganisme(OrganismeConcerne);
            this.DetailSessionCommand = new RelayCommand(DetailSession);
            this.AppelSkypeCommand = new RelayCommand(AppelSkype);
            this.NameSkype = this.OrganismeConcerne.NomSkype == null ? false : true;
        }




        public ICommand CreerSessionCommand { get; private set; }
        public ICommand DetailOrganismeFormationCommand { get; private set; }
        public ICommand DetailSessionCommand { get; private set; }
        public ICommand AppelSkypeCommand { get; private set; }
        #region private Methods


        private void DetailSession()
        {
            if (SessionSelectionner != null)
            {
                LaNavigation.Session = SessionSelectionner;
                navigate.NavigateToDetailSession();
            }
        }


        private void DetailOrganismeFormation()
        {
            if (OrganismeFormationSelectionner.FormationConcerne != null)
            {
                LaNavigation.Formation = OrganismeFormationSelectionner.FormationConcerne;

                navigate.NavigateToDetailFormation();
            }
        }

        private void AppelSkype()
        {
            OrganismeConcerne.CallToBySkype();
        }

        #endregion
    }
}
