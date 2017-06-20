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
    class DesignListeSession : IListeSessionView
    {
        public Session SessionSelectionner
        {
            get
            {
                return ListeSession[0];
            }
            set { }
        }
        public ObservableCollection<Session> ListeSession
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
                        OrganismeFomationConcerne = new OrganismeFormation()


                    },

                                        new Session
                    {
                        DateDebut = new DateTime(2016,03,12,8,25,0),
                        DateFin = new DateTime(2016,04,12,8,25,0),
                        NbrPlaceTotal = 10,
                        Lieu = "2 rue fenelon 44000 Nantes",
                        OrganismeFomationConcerne = new OrganismeFormation()



                    },
                                                            new Session
                    {
                        DateDebut = new DateTime(2016,03,12,8,25,0),
                        DateFin = new DateTime(2016,04,12,8,25,0),
                        NbrPlaceTotal = 10,
                        Lieu = "2 rue fenelon 44000 Nantes",
                        OrganismeFomationConcerne = new OrganismeFormation()


                    }
                };
            }
            set { }
        }
    }
}
