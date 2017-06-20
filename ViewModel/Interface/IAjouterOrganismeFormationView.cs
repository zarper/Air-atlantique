using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.Model;
using System.Collections.ObjectModel;

namespace MaltAirAtlantique.ViewModel.Interface
{
    interface IAjouterOrganismeFormationView
    {
        Formation FormationConcerne { get; set; }
        Organisme OrganismeConcerne { get; set; }
        ObservableCollection<Organisme> ListOrganisme { get; set; }
        Organisme OrganismeNouveau { get; set; }
        OrganismeFormation OrganismeFormationResultat { get; set; }
    }
}
