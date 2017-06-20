using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Model;
using MaltAirAtlantique.Model.DAO;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Helper;
using System.Windows.Input;

namespace MaltAirAtlantique.ViewModel
{
    public class AjouterEmployeeViewModel : ViewModelBase, IAjouterEmployeeView
    {

        #region Interface Properties/Accessors


        private Poste _posteConcerne = new Poste();
        public Poste PosteConcerne
        {
            get { return _posteConcerne; }
            set { NotifyPropertyChanged(ref _posteConcerne, value); }
        }
        private Employee _employeeResultat = new Employee();
        public Employee EmployeeResultat
        {
            get { return _employeeResultat; }
            set { NotifyPropertyChanged(ref _employeeResultat, value); }
        }


        private ObservableCollection<Poste> _listePoste = new ObservableCollection<Poste>();
        public ObservableCollection<Poste> ListePoste
        {
            get { return _listePoste; }
            set { NotifyPropertyChanged(ref _listePoste, value); }
        }

        #endregion

        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion

        public AjouterEmployeeViewModel()
        {
            this.EmployeeResultat = new Employee();
            this.ListePoste = DAOPoste.ListerPoste();
            if (this.ListePoste.Count > 0)
            {
                this.PosteConcerne = ListePoste[0];
            }
            this.AjouterEmployeeCommand = new RelayCommand(AjouterEmployee);


        }

        public ICommand AjouterEmployeeCommand { get; private set; }




        #region private Methods


        private void AjouterEmployee()
        {
            if(EmployeeResultat.Prenom == null)
            {
                EmployeeResultat.Prenom = "BugData";
            }
            DAOEmploye.AjouterEmployeBDD(EmployeeResultat, PosteConcerne);
            EmployeeResultat = new Employee();
            navigate.NavigateToAjouterEmployee();
        }
        #endregion

    }
}
