using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    public class DAOPoste
    {
        public static Poste ConstructeurPoste(Poste poste)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                if (poste.ListeFormationMini.Count() == 0)
                {
                    var formations = from pf in db.PosteFormation where pf.PosteConcerne.PosteID == poste.PosteID select pf;
                    foreach (PosteFormation pf in formations)
                    {
                        var requeteFormation = from f in db.Formations where f.FormationID == pf.FormationConcerne.FormationID select f;
                        pf.FormationConcerne = requeteFormation.First();
                        poste.ListeFormationMini.Add(pf);
                    }
                }

                if (poste.ListeEmployee.Count() == 0)
                {
                    var employees = from e in db.Employees where e.PosteAttribuer.PosteID == poste.PosteID select e;
                    foreach (Employee pf in employees)
                    {
                        poste.ListeEmployee.Add(pf);
                    }
                }

            }

            return poste;
        }



        public static ObservableCollection<Poste> ListerPoste()
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Poste> ListerPosteDB = new ObservableCollection<Poste>();
                var Postes = from item in db.Postes select item;
                foreach (Poste item in Postes)
                {
                    ListerPosteDB.Add(item);
                }

                return ListerPosteDB;
            }
        }


    }
}
