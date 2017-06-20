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
    public class DesignAjouterSession : IAjouterSessionView
    {
        public Session SessionNouvelle
        {
            get
            {
                return new Session
                {
                    NbrPlaceTotal = 10,

                    DateDebut = new DateTime(2016, 06, 23, 9, 30, 0),
                    DateFin = new DateTime(2017, 06, 23, 18, 30, 0),
                    Lieu = "2 rue Fenelon 4400 Nantes"

                };
            }
            set { }
        }

        public Formation FormationConcerne
        {
            get
            {
                return new Formation
                {
                    Nom = "Soudeur",
                    Description = "Formation pour soudure MAG/MIG/TIG",
                    DureeEnHeure = 120,
                    DureeDeValidite = 5,

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
            set { }
         
        }

        public ObservableCollection<Formation> ListeFormation
        {
            get
            {
                return new ObservableCollection<Formation>
                {
                     new Formation
                    {
                       Nom = "Soudeur",
                    Description = "Formation pour soudure MAG/MIG/TIG",
                    DureeEnHeure = 120,
                    DureeDeValidite = 5,

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

                    },
                    new Formation
                    {

                        Nom = "Soudeur",
                    Description = "Formation pour soudure MAG/MIG/TIG",
                    DureeEnHeure = 120,
                    DureeDeValidite = 5,

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
                    },
                    new Formation
                    {

                        Nom = "Soudeur",
                    Description = "Formation pour soudure MAG/MIG/TIG",
                    DureeEnHeure = 120,
                    DureeDeValidite = 5,

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
                    },
                    new Formation
                    {

                        Nom = "Soudeur",
                    Description = "Formation pour soudure MAG/MIG/TIG",
                    DureeEnHeure = 120,
                    DureeDeValidite = 5,

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
                    }
                };
            }
            set { }
        }

        public OrganismeFormation OrganismeFormationConcerne
        {
            get
            {
                return new OrganismeFormation
                {
                    FormationConcerne = FormationConcerne,
                    OrganismeConcerne = FormationConcerne.ListOrganismes.First().OrganismeConcerne,
                    Prix = 1500
                };
            }
            set { }
        }
    }
}
