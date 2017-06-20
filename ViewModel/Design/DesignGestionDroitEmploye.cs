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
    class DesignGestionDroitEmploye : IGestionaccesView
    {
        public Employee EmployeeSelectione
        {
            get
            {
                return new Employee
                {
                    Matricule = "lgadrien",
                    Nom = "Le Geldron",
                    Prenom = "Adrien",
                    Acces = 777,
                    PosteAttribuer = new Poste
                    {
                        Nom = "Developpeur",
                        Description = "Description du poste"
                    },
                    CesFormations = new ObservableCollection<EmployeeFormation>
                    {
                        new EmployeeFormation
                        {
                            FormationConcerne = new Formation
                            {
                                Nom = "Langage Java",
                                Description = "Decouverte du java IEE"

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
