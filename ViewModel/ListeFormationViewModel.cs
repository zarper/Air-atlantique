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
    public class ListeFormationViewModel : ViewModelBase, IListeFormationView
    {
        #region Interface Properties/Accessors


        private ObservableCollection<Formation> _listeFormations;
        public ObservableCollection<Formation> ListeFormations
        {
            get { return _listeFormations; }
            set { NotifyPropertyChanged(ref _listeFormations, value); }
        }

        private Formation _formationSelectionner;
        public Formation FormationSelectionner
        {
            get { return _formationSelectionner;}
            set { NotifyPropertyChanged(ref _formationSelectionner, value); }
        }




        #endregion


        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion
        // Je n'arrive pas a recuperer le parametre du relay command, ces lignes de code permettent de tester le programme

        public ListeFormationViewModel()
        {
            LaNavigation.Formation = null;
            ListeFormations = DAOFormation.ListerFormation();
            this.AjouterFormationCommand = new RelayCommand(AjouterFormation);
            this.DetailFormationCommand = new RelayCommand(DetailFormation);
        }

        // Constructeur appelé normalement par le relaycommand de ListePersonneViewModel

        public ICommand AjouterFormationCommand { get; private set; }
        public ICommand DetailFormationCommand { get; private set; }
        public ICommand SuppressionFormationCommand { get; private set; }

        #region private Methods


      

        private void AjouterFormation()
        {
            navigate.NavigateToAjouterFormation();
        }

        private void DetailFormation()
        {
            if (FormationSelectionner != null)
            {
                LaNavigation.Formation = FormationSelectionner;
                navigate.NavigateToDetailFormation();
            }
        }

      
        #endregion
    }
}
