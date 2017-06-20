using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.ViewModel.Interface;
using System.Collections.ObjectModel;

namespace MaltAirAtlantique.ViewModel.Design
{
    class DesignListeFormation : IListeFormationView
    {

        public ObservableCollection<Formation> ListeFormations
        {
            get
            {
                return new ObservableCollection<Formation>
                {
                    new Formation
                    {
                        Nom = "Soudeur",
                        Description = "Un soudeur de legende"
                    },
                    new Formation
                    {
                        Nom = "Soudeur",
                        Description = "Un soudeur de legende"
                    },
                    new Formation
                    {
                        Nom = "Soudeur",
                        Description = "Un soudeur de legende"
                    },
                    new Formation
                    {
                        Nom = "Soudeur",
                        Description = "Un soudeur de legende"
                    }
                };
            }
            set { }
        }

        public Formation FormationSelectionner { get { return new Formation { Nom = null, Description = null }; } set { } }
    }
    }

