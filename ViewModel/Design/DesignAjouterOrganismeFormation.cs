using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Model;
using System.Collections.ObjectModel;

namespace MaltAirAtlantique.ViewModel.Design
{
    class DesignAjouterOrganismeFormation : IAjouterOrganismeFormationView
    {
        public Formation FormationConcerne
        {
            get
            {
                return new Formation
                {


                    Nom = "Developpeur C#",
                    Description = "Un bon developpeur doit savoir developper",
                    DureeEnHeure = 120,
                    DureeDeValidite = 5,


                    //Sessions = new List<Session>
                    //{
                    //    new Session
                    //    {
                    //        DateDebut = new DateTime(2016,04,11,9,30,0),
                    //        DateFin = new DateTime(2016,05,15,18,30,0),
                    //        Lieu = "2 rue Fénélon 44000 Nantes",
                    //        NbrPlaceTotal = 10,

                    //    },

                    //    new Session
                    //    {
                    //        DateDebut = new DateTime(2016,05,11,9,30,0),
                    //        DateFin = new DateTime(2016,07,15,18,30,0),
                    //        Lieu = "2 rue Fénélon 44000 Nantes",
                    //        NbrPlaceTotal = 20,

                    //    }




                    //},
                    ListOrganismes = new ObservableCollection<OrganismeFormation>
                        {
                            new OrganismeFormation
                            {
                                Prix = 1500,
                                OrganismeConcerne = new Organisme
                                {
                                    Nom = "EPSI",
                                    LienInternet = "epsi.com",
                                    ContactNom = "Le Geldron Adrien",
                                    ContactMail = "adrien.legeldron@epsi.fr",
                                    


                                }
                            },

                            new OrganismeFormation
                            {
                                Prix = 3000,
                                OrganismeConcerne = new Organisme
                                {
                                    Nom = "Benetto",
                                    LienInternet = "benetto.com",
                                    ContactNom = "Olivier dupont",
                                    ContactMail = "Dupont.Olivier@benetto.fr",

                                }
                            }

                        }





                };

            }
            set { } }

             public Organisme OrganismeConcerne
        {
            get
            {
                return new Organisme
                {
                    Nom = "EPSI",
                    LienInternet = "epsi.com",
                    ContactNom = "Appriou Ludovic",
                    ContactMail = "ludovic.appriou@epsi.fr",
                    NomSkype = "zedifys"
                };              
            }
            set { }
        }

        public Organisme OrganismeNouveau
        {
            get
            {
                return new Organisme
                {
                    Nom = "EPSI",
                    LienInternet = "epsi.com",
                    ContactNom = "Appriou Ludovic",
                    ContactMail = "ludovic.appriou@epsi.fr",
                    NomSkype = "zedifys"
                };
            }
            set { }
        }


        public ObservableCollection<Organisme> ListOrganisme
        {
            get
            {
                return new ObservableCollection<Organisme>
                {

                            new Organisme
                                {
                                    Nom = "EPSI",
                                    LienInternet = "epsi.com",
                                    ContactNom = "Appriou Ludovic",
                                    ContactMail = "ludovic.appriou@epsi.fr",



                                },

                            new Organisme
                                {
                                    Nom = "Benetto",
                                    LienInternet = "benetto.com",
                                    ContactNom = "Thomas Herpin",
                                    ContactMail = "Herpin.thomas@epsi.fr",



                            }
                };
                }
            set { }
        }

        public OrganismeFormation OrganismeFormationResultat
        {
            get
            {
                return new OrganismeFormation
                {
                    OrganismeConcerne = OrganismeConcerne,
                    FormationConcerne = FormationConcerne,
                    Prix = 1500,
                };
            }
            set { }
        }
    }
}
