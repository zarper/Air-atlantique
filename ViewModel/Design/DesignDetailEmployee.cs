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
    public class DesignDetailEmployee: IDetailEmployeeView
    {
        public Employee EmployeeConcerne
        {
            get
            {
                return new Employee
                {
                    Matricule = "ALeGeldron",
                    Nom = "Le Geldron",
                    Prenom = "Adrien",
                    PosteAttribuer = new Poste
                    {
                        Nom = "Developpeur Java",
                        Description = "Description du poste"
                    },
                    CesFormations = new ObservableCollection<EmployeeFormation>
                    {
                        new EmployeeFormation
                        {
                            FormationConcerne = new Formation
                            {
                                Nom = "Langage c#",
                                Description = "Decouverte de ce fabuleux langage"

                            }
                        }
                    },

                    CesSessions = new ObservableCollection<SessionEmployee>
                    {
                        new SessionEmployee
                        {
                            SessionConcerne = new Session
                            {
                                Lieu = "Nantes",
                                OrganismeFomationConcerne = new OrganismeFormation
                                {
                                    FormationConcerne = new Formation
                                    {
                                        Nom = "Formation1"

                                    },

                                    OrganismeConcerne = new Organisme()
                                    {
                                        Nom = "Organisme1",

                                    }




                                }
                            }
                        }
                    }

                    



                };
            }
            set { }
        }
    }
}
