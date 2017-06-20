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
    public class DesignNotification : INotificationView
    {
        public ObservableCollection<EmployeeFormation> ListeEmployeeNonConforme
        {
            get
            {
                return new ObservableCollection<EmployeeFormation>
                {
                    new EmployeeFormation
                    {
                      EmployeeConcerne = new Employee
                      {
                            Matricule = "ALeGeldron",
                            Nom = "Le Geldron",
                            Prenom = "Adrien",
                      },

                      FormationConcerne = new Formation
                      {
                          Nom = "Developpeur"
                      }



                    },

                    new EmployeeFormation
                    {
                         EmployeeConcerne = new Employee
                      {
                          Matricule = "thomas.herpin",
                          Nom = "Herpin",
                          Prenom ="Thomas"
                      },

                      FormationConcerne = new Formation
                      {
                          Nom = "Developpeur"
                      }

                    }
                };

            }
            set { }
        }

        public ObservableCollection<Session> ListeSessionAValider
        {
            get
            {
                return new ObservableCollection<Session>
                {
                    new Session
                    {
                        DateDebut = new DateTime(2016,03,12,8,25,0),
                        DateFin = new DateTime(2016,04,12,8,25,0),
                        NbrPlaceTotal = 10,
                        Lieu = "2 rue fenelon 44000 Nantes",
                        OrganismeFomationConcerne = new OrganismeFormation
                        {
                            OrganismeConcerne = new Organisme
                            {
                                Nom = "EPSI"
                            },

                            FormationConcerne = new Formation
                            {
                                Nom = "Developpeur"
                            },
    
                        }


                    },

                                        new Session
                    {
                        DateDebut = new DateTime(2016,03,12,8,25,0),
                        DateFin = new DateTime(2016,04,12,8,25,0),
                        NbrPlaceTotal = 10,
                        Lieu = "2 rue fenelon 44000 Nantes",
                         OrganismeFomationConcerne = new OrganismeFormation
                        {
                            OrganismeConcerne = new Organisme
                            {
                                Nom = "AFPI"
                            },

                            FormationConcerne = new Formation
                            {
                                Nom = "Soudeur"
                            },

                        }



                    },
                                                            new Session
                    {
                        DateDebut = new DateTime(2016,03,12,8,25,0),
                        DateFin = new DateTime(2016,04,12,8,25,0),
                        NbrPlaceTotal = 10,
                        Lieu = "2 rue fenelon 44000 Nantes",
                        OrganismeFomationConcerne = new OrganismeFormation
                        {
                            OrganismeConcerne = new Organisme
                            {
                                Nom = "EPSI"
                            },

                            FormationConcerne = new Formation
                            {
                                Nom = "VLAN"
                            },

                        }


                    }
                };

            }
            set { }
        }
    }
}
