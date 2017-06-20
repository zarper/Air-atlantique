using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    class DAOEmployeAcces
    {

        public static Employee ModifierAccesEmploye(Employee employee)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                var Acces = from es in db.SessionEmployees where es.EmployeeConcerne.Matricule == employee.Matricule select es;
              
              //vérification de la capacité de l'utilisateur soit en droit de pouvoir faire les actions demander
                
            }
            return employee;
        }



    }
}
