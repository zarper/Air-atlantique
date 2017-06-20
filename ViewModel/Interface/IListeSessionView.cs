using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.ViewModel.Interface
{
    public interface IListeSessionView
    {
        ObservableCollection<Session> ListeSession { get; set; }
        Session SessionSelectionner { get; set; }
    }
}
