using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using System.Collections.ObjectModel;
using MaltAirAtlantique.Model;

namespace MaltAirAtlantique.ViewModel.Design
{
    public class DesignDetailSession : IDetailSessionView
    {
        public Session SessionConcerne
        {
            get
            {
                return new Session
                {
                    Lieu = "2 rue Fénélon Nantes",
                    DateDebut = new DateTime(2017, 03, 24, 9, 30, 0),
                    DateFin = new DateTime(2017, 03, 24, 18, 0, 0),
                    OrganismeFomationConcerne = new OrganismeFormation
                    {
                        Prix = 1200,
                        OrganismeConcerne = new Organisme
                        {
                            Nom = "EPSI"
                        },

                        FormationConcerne = new Formation
                        {
                            Nom = "Developpeur"
                        }


                    },
                    ListeEmployeeConcernees = new ObservableCollection<SessionEmployee>()
                    {
                        new SessionEmployee
                        {
                            EmployeeConcerne = new Employee
                            {

                            Nom = "Le geldron",
                            Prenom = "Adrien"

                            }

                        }


                    }
                };
            }
            
            set { }


        }

        public ObservableCollection<Employee> ListeEmployeeManquant
        {
            get
            {
                return new ObservableCollection<Employee>
                {
                    new Employee()
                    {
                        Nom = "Le geldron",
                        Prenom = "Adrien"

                    },

                    new Employee()
                    {
                        Nom ="Hawk",
                        Prenom = "Thomas"

                    }
                };
            }
            set { }
        }

        public int NbrPlaceRestante
        {
            get
            {
                return 0;
            }
            set { }
        }

        public double PrixTotal
        {
            get
            {
                return 4000;
            }
            set { }
        }
    }
}
