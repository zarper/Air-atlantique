using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model
{
    public class PosteFormation
    {
        [Key]
        public int PosteFormationID { get; set; }
        public virtual Poste PosteConcerne { get; set; }
        public virtual Formation FormationConcerne { get; set; }
    }
}
