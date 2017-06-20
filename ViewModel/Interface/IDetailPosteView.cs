using MaltAirAtlantique.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.ViewModel.Interface
{
    public interface IDetailPosteView
    {
        ObservableCollection<Formation> ListeFormation { get; set; }
        Poste PosteConcerne { get; set; }
    }
}
