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
    public class ListeEmployeeViewModel : ViewModelBase, IListeEmployeeView
    {
        #region Interface Properties/Accessors


        private ObservableCollection<Employee> _listeEmployee;
        public ObservableCollection<Employee> ListeEmployees
        {
            get { return _listeEmployee; }
            set { NotifyPropertyChanged(ref _listeEmployee, value); }
        }

        private Employee _employeeSelectionner;
        public Employee EmployeeSelectionner
        {
            get { return _employeeSelectionner; }
            set { NotifyPropertyChanged(ref _employeeSelectionner, value); }
        }


        #endregion


        #region privatePropetie
        LaNavigation navigate = new LaNavigation();

        #endregion
        // Je n'arrive pas a recuperer le parametre du relay command, ces lignes de code permettent de tester le programme

        public ListeEmployeeViewModel()
        {
            LaNavigation.Formation = null;
            ListeEmployees = DAOEmploye.ListerEmployes();
            this.AjouterEmployeeCommand = new RelayCommand(AjouterEmployee);
            this.DetailEmployeeCommand = new RelayCommand(DetailEmployee);
        }

        // Constructeur appelé normalement par le relaycommand de ListePersonneViewModel

        public ICommand AjouterEmployeeCommand { get; private set; }
        public ICommand DetailEmployeeCommand { get; private set; }
        public ICommand SuppressionFormationCommand { get; private set; }

        #region private Methods




        
        private void AjouterEmployee()
        {
            navigate.NavigateToAjouterEmployee();
        }

        private void DetailEmployee()
        {
            if (EmployeeSelectionner != null)
            {
                LaNavigation.Employee = EmployeeSelectionner;
                navigate.NavigateToDetailEmployee();
            }
        }


        #endregion
    }
}

