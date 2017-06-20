using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using System.Collections.ObjectModel;

namespace MaltAirAtlantique.ViewModel.Design
{
    class DesignListeEmployee : IListeEmployeeView
    {

        public ObservableCollection<Employee> ListeEmployees
        {
            get
            {
                return new ObservableCollection<Employee>
                {
                    new Employee
                    {
                    Matricule = "ALeGeldron1",
                    Nom = "Le Geldron",
                    Prenom = "Adrien",

                    },
                    new Employee
                    {
                    Matricule = "THawk",
                    Nom = "Hawk",
                    Prenom = "Thomas",
                    },
                    new Employee
                    {
                    Matricule = "VStein",
                    Nom = "Stein",
                    Prenom = "Victor",
                    },
                };
            }
            set { }
        }
    }
    }

