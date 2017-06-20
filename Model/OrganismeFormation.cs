using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model
{
    public class OrganismeFormation
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public double Prix { get; set; }

        public virtual Formation FormationConcerne { get; set; }
        public virtual Organisme OrganismeConcerne { get; set; }

        public ObservableCollection<Session> Sessions { get; set; }

        public OrganismeFormation()
        {
            this.Sessions = new ObservableCollection<Session>();
        }
    }
}
