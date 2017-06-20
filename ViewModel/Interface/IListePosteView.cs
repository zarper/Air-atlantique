using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.Model;
using System.Collections.ObjectModel;

namespace MaltAirAtlantique.ViewModel.Interface
{
    public interface IListePosteView
    {
        ObservableCollection<Poste> ListePoste { get; set; }
        Poste PosteSelectionner { get; set; }
    }
}
