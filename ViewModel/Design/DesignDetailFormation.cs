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
    class DesignDetailFormation : IDetailFormationView
    {
        public Formation Formation
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
                                    ContactNom = "Thomas Herpin",
                                    ContactMail = "Herpin.thomas@epsi.fr",

                                }
                            }
                    }
                    
                };
            }
            set { }
        }
    }
}
