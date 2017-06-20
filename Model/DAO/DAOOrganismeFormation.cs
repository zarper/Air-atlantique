using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    public class DAOOrganismeFormation
    {
        public static void AjouterOF(OrganismeFormation organismeFormationNouveau)
        {
            using (var db = new DBAirAtlantiqueContext())
            {

                var requeteFormation = from f in db.Formations where f.FormationID == organismeFormationNouveau.FormationConcerne.FormationID select f;
                organismeFormationNouveau.FormationConcerne = requeteFormation.FirstOrDefault();

                var requeteOrganisme = from o in db.Organismes where o.OrganismeID == organismeFormationNouveau.OrganismeConcerne.OrganismeID select o;
                organismeFormationNouveau.OrganismeConcerne = requeteOrganisme.FirstOrDefault();
                db.OrganismeFormation.Add(organismeFormationNouveau);
                db.SaveChanges();

            }
        }


    }
}
