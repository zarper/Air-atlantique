using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    class DAOOrganisme
    {
        public static Organisme ConstructeurOrganisme(Organisme organisme)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                if (organisme.FormationsProposer.Count() == 0)
                {
                    var formations = from of in db.OrganismeFormation where of.OrganismeConcerne.OrganismeID == organisme.OrganismeID select of;
                    foreach (OrganismeFormation of in formations)
                    {
                        var requeteFormation = from f in db.Formations where f.FormationID == of.FormationConcerne.FormationID select f;
                        of.FormationConcerne = requeteFormation.First();
                        organisme.FormationsProposer.Add(of);
                    }
                }

            }

            return organisme;
        }

        public static void AjouterOrganisme(Organisme organismeNouveau)
        {
            using (var db = new DBAirAtlantiqueContext())
            {

                db.Organismes.Add(organismeNouveau);

                db.SaveChanges();

            }
        }

        public static ObservableCollection<Organisme> ListerOrganisme()
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                ObservableCollection<Organisme> ListerOrganismeDB = new ObservableCollection<Organisme>();
                var Organimes = from item in db.Organismes select item;
                foreach (Organisme item in Organimes)
                {
                    ListerOrganismeDB.Add(item);
                }

                return ListerOrganismeDB;
            }
        }



    }
}
