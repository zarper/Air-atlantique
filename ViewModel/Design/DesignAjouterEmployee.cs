using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.Model;
using MaltAirAtlantique.ViewModel.Interface;
using System.Collections.ObjectModel;

namespace MaltAirAtlantique.ViewModel.Design
{
    public class DesignAjouterEmployee : IAjouterEmployeeView
    {
        public Employee EmployeeResultat
        {
            get
            {
                return new Employee
                {
                    Matricule = "legeldron.adrien",
                    Nom = "Le Geldron",
                    Prenom = "Adrien"
                };
            }
            set { }
        }

        public ObservableCollection<Poste> ListePoste
        {
            get
            {
                return new ObservableCollection<Poste>
                {
                    new Poste
                    {
                        Nom = "Admin",
                        Description = "daedeaz"

                    },

                    new Poste
                    {
                        Nom = "DZEEEA",
                        Description ="ezfedezade"
                    }
                };

            }
            set { }
        }

        public Poste PosteConcerne
        {
            get
            {
                return ListePoste[1];
            }
            set { }
        }
        
    }
}
