using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.ViewModel.Interface
{
    public interface IListeEmployeeView
    {
        ObservableCollection<Employee> ListeEmployees { get; set; }
    }
}
