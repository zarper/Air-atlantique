using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.ViewModel.Interface
{
    public interface IDetailSessionView
    {
        Session SessionConcerne { get; set; }

        ObservableCollection<Employee> ListeEmployeeManquant { get; set; }

        int NbrPlaceRestante { get; set; }

        double PrixTotal { get; set; }
    }
}
