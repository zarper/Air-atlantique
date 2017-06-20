using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.Model;

namespace MaltAirAtlantique.ViewModel.Interface
{
    public interface IAjouterSessionView
    {
        Session SessionNouvelle { get; set; }
        Formation FormationConcerne { get; set; }
        OrganismeFormation OrganismeFormationConcerne { get; set; }

    }
}
