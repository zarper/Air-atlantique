using MaltAirAtlantique.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.ViewModel.Interface
{
    public interface INotificationView
    {
         ObservableCollection<Session> ListeSessionAValider { get; set; }
         ObservableCollection<EmployeeFormation> ListeEmployeeNonConforme { get; set; }
    }
}
