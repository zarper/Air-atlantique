using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Model;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Helper;
using System.Windows.Input;
using MaltAirAtlantique.Model.DAO;

namespace MaltAirAtlantique.ViewModel
{
    public class AjouterPosteViewModel : ViewModelBase, IAjouterPosteView
    {
        #region Interface Properties/Accessors


        private Poste _posteResultat = new Poste();
        public Poste PosteResultat
        {
            get { return _posteResultat; }
            set { NotifyPropertyChanged(ref _posteResultat, value); }
        }

        private ObservableCollection<Formation> _listeFormation = new ObservableCollection<Formation>();
        public ObservableCollection<Formation> ListeFormation
        {
            get { return _listeFormation; }
            set { NotifyPropertyChanged(ref _listeFormation, value); }
        }

  
        #endregion





        public AjouterPosteViewModel()
        {

            this.ListeFormation = DAOFormation.ListerFormation();
            this.AjouterPosteCommand = new RelayCommand(AjouterPoste);

        }

        #region Private Properties

        LaNavigation navigate = new LaNavigation();
        #endregion


        public ICommand AjouterPosteCommand { get; private set; }

        #region private Methods



        private void AjouterPoste()
        {
            using (var db = new DBAirAtlantiqueContext())
            {



                db.Postes.Add(PosteResultat);

                db.SaveChanges();

            }

            navigate.NavigateToAjouterPoste();
        }
        #endregion
    }
}

