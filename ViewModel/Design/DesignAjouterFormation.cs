using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using MaltAirAtlantique.Model;
namespace MaltAirAtlantique.ViewModel.Design
{
    class DesignAjouterFormation : IAjouterFormationView
    {
        public Formation Formation
        {
            get
            {
                return new Formation
                {
                    Nom = "Soudeur",
                    Description = "Formation pour soudur MAG/MIG/TIG",
                    DureeEnHeure = 120,
                    DureeDeValidite = 5,
                };
            }
            set { }
        }
    }
}

