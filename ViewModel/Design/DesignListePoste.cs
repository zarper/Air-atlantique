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
    class DesignListePoste : IListePosteView
    {
        public ObservableCollection<Poste> ListePoste
        {
            get
            {
                return new ObservableCollection<Poste>
                {
                    new Poste
                    {
                        Nom = "admin reseaux",
                        Description = "zazdzea",

                    },
                    new Poste
                    {
                        Nom ="ezdzaedaze",
                        Description = "ezdezdszeas"
                    }
                };
            }
            set { }
        }

        public Poste PosteSelectionner
        {
            get
            {
                return ListePoste[0];
            }
            set { }
        }

    }
}