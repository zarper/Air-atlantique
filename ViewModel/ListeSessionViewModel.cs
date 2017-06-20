using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Helper;
using System.Windows.Input;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    public class ListeSessionViewModel: ViewModelBase, IListeSessionView
    {
        #region Interface Properties/Accessors


        private ObservableCollection<Session> _listeSession;
        public ObservableCollection<Session> ListeSession
        {
            get { return _listeSession; }
            set { NotifyPropertyChanged(ref _listeSession, value); }
        }

        private Session _sessionSelectionner;
        public Session SessionSelectionner
        {
            get { return _sessionSelectionner; }
            set { NotifyPropertyChanged(ref _sessionSelectionner, value); }
        }


        #endregion


        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion
        // Je n'arrive pas a recuperer le parametre du relay command, ces lignes de code permettent de tester le programme

        public ListeSessionViewModel()
        {
            LaNavigation.Session = null;
            ListeSession = DAOSession.ListerSession();
            this.AjouterSessionCommand = new RelayCommand(AjouterSession);
            this.DetailSessionCommand = new RelayCommand(DetailSession);
            
        }

        // Constructeur appelé normalement par le relaycommand de ListePersonneViewModel

        public ICommand AjouterSessionCommand { get; private set; }
        public ICommand DetailSessionCommand { get; private set; }

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

        #endregion
    
}
}
