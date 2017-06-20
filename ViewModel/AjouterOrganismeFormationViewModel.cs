using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Helper;
using MaltAirAtlantique.Model;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    class AjouterOrganismeFormationViewModel : ViewModelBase, IAjouterOrganismeFormationView
    {
        #region Interface Properties/Accessors


        private Formation _formationConcerne = new Formation();
        public Formation FormationConcerne
        {
            get { return _formationConcerne; }
            set { NotifyPropertyChanged(ref _formationConcerne, value); }
        }
        private Organisme _organismeConcerne = new Organisme();
        public Organisme OrganismeConcerne
        {
            get { return _organismeConcerne; }
            set { NotifyPropertyChanged(ref _organismeConcerne, value); }
        }

        private Organisme _organismeNouveau = new Organisme();
        public Organisme OrganismeNouveau
        {
            get { return _organismeNouveau; }
            set { NotifyPropertyChanged(ref _organismeNouveau, value); }
        }

        private OrganismeFormation _organismeFormationResultat = new OrganismeFormation();
        public OrganismeFormation OrganismeFormationResultat
        {
            get { return _organismeFormationResultat; }
            set { NotifyPropertyChanged(ref _organismeFormationResultat, value); }
        }

        private ObservableCollection<Organisme> _listOrganisme = new ObservableCollection<Organisme>();
        public ObservableCollection<Organisme> ListOrganisme
        {
            get { return _listOrganisme; }
            set { NotifyPropertyChanged(ref _listOrganisme, value); }
        }


        #endregion

        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion

        public AjouterOrganismeFormationViewModel()
        {
            this.OrganismeNouveau = new Organisme();
            this.FormationConcerne = LaNavigation.Formation;
            this.ListOrganisme = DAOOrganisme.ListerOrganisme();
            if (this.ListOrganisme.Count > 0)
            {
                this.OrganismeConcerne = ListOrganisme[0];
            }
            this.CreerOrganismeCommand = new RelayCommand(CreerOrganisme);
            this.AjouterOrganismeFormationCommand = new RelayCommand(AjouterOrganismeFormation);

        }

        public ICommand CreerOrganismeCommand { get; private set; }
        public ICommand AjouterOrganismeFormationCommand { get; private set; }




        #region private Methods


        private void CreerOrganisme()
        {
            OrganismeNouveau.NomSkype = "live:ludovic.appriou";
            DAOOrganisme.AjouterOrganisme(OrganismeNouveau);
            OrganismeNouveau = new Organisme();

            navigate.NavigateToAjouterOrganismeFormation();
        }

      

        private void AjouterOrganismeFormation()
        {

            OrganismeFormationResultat.OrganismeConcerne = OrganismeConcerne;
            OrganismeFormationResultat.FormationConcerne = FormationConcerne;

            DAOOrganismeFormation.AjouterOF(OrganismeFormationResultat);

           
            navigate.NavigateToAjouterOrganismeFormation();
        }
        #endregion


    }
}
