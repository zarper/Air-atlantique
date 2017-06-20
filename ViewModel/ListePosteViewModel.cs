using MaltAirAtlantique.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Helper;
using System.Windows.Input;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    public class ListePosteViewModel : ViewModelBase, IListePosteView
    {
        #region Interface Properties/Accessors


        private ObservableCollection<Poste> _listePoste;
        public ObservableCollection<Poste> ListePoste
        {
            get { return _listePoste; }
            set { NotifyPropertyChanged(ref _listePoste, value); }
        }

        private Poste _posteSelectionner;
        public Poste PosteSelectionner
        {
            get { return _posteSelectionner; }
            set { NotifyPropertyChanged(ref _posteSelectionner, value); }
        }


        #endregion


        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion
        // Je n'arrive pas a recuperer le parametre du relay command, ces lignes de code permettent de tester le programme

        public ListePosteViewModel()
        {
            LaNavigation.Formation = null;
            ListePoste = ListerPoste();
            this.AjouterPosteCommand = new RelayCommand(AjouterPoste);
            this.DetailPosteCommand = new RelayCommand(DetailPoste);
        }

        // Constructeur appelé normalement par le relaycommand de ListePersonneViewModel

        public ICommand AjouterPosteCommand { get; private set; }
        public ICommand DetailPosteCommand { get; private set; }

        #region private Methods


        private ObservableCollection<Poste> ListerPoste()
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Poste> ListerPosteDB = new ObservableCollection<Poste>();
                var Postes = from item in db.Postes select item;
                foreach (Poste item in Postes)
                {
                    ListerPosteDB.Add(item);
                }

                return ListerPosteDB;
            }


        }
        private void AjouterPoste()
        {
            navigate.NavigateToAjouterPoste();
        }

        private void DetailPoste()
        {
            if (PosteSelectionner != null)
            {
                LaNavigation.Poste = PosteSelectionner;
                navigate.NavigateToDetailPoste();
            }
        }


        #endregion
    }
}

