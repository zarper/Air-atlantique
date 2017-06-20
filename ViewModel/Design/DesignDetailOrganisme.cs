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
    public class DesignDetailOrganisme : IDetailOrganismeView
    {
        public Organisme OrganismeConcerne
        {
            get
            {
                return new Organisme
                {
                    Nom = "EPSI",
                    LienInternet = "epsi.com",
                    ContactNom = "Le Geldron Adrien",
                    ContactMail = "adrien.legeldron@epsi.fr",

                    FormationsProposer = new ObservableCollection<OrganismeFormation>
                    {
                        new OrganismeFormation
                        {
                            Prix = 3000,
                            FormationConcerne = new Formation
                            {
                                Nom = "Developpeur",
                                Description = "Developper c'est ouf",
                                DureeEnHeure = 600,
                                DureeDeValidite = 50,
                            }
                        },
                        new OrganismeFormation
                        {
                            Prix = 1500,
                            FormationConcerne = new Formation
                            {
                                Nom = "AdminReseau",
                                Description = "Le reseau c'est ouf",
                                DureeEnHeure = 600,
                                DureeDeValidite = 50,
                            }
                        }

                    }
                };
            }
            set { }
        }
    }
}
