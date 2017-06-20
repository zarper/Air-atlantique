using MaltAirAtlantique.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model.DAO
{
    class DAOPosteFormation
    {
        public static void AjouterPosteFormation(Formation formationConcerne, Poste posteConcerne)
        {
            using (var db = new DBAirAtlantiqueContext())
            {
                var requetteFormation = from f in db.Formations where f.FormationID == formationConcerne.FormationID select f;
                var requettePoste = from p in db.Postes where p.PosteID == posteConcerne.PosteID select p;

                PosteFormation posteFormationResultat = new PosteFormation
                {
                    PosteConcerne = requettePoste.First(),
                    FormationConcerne = requetteFormation.First()
                };
                db.PosteFormation.Add(posteFormationResultat);

                db.SaveChanges();
                
            }
        }
    }
}
