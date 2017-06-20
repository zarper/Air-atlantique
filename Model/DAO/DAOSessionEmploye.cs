using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    class DAOSessionEmploye
    {
        public static void AjouterSessionEmployee(SessionEmployee sEConcerne)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                var requetteE = from e in db.Employees where sEConcerne.EmployeeConcerne.Matricule == e.Matricule select e;
                var requetteS = from s in db.Sessions where sEConcerne.SessionConcerne.SessionID == s.SessionID select s;
                SessionEmployee _sessionEmployeeNouveau = new SessionEmployee
                {
                    SessionConcerne = requetteS.First(),
                    EmployeeConcerne = requetteE.First()

                };

                db.SessionEmployees.Add(_sessionEmployeeNouveau);

                db.SaveChanges();
            }
        }
    }
}
