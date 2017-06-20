using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaltAirAtlantique.Model;
using System.Collections.ObjectModel;

namespace MaltAirAtlantique
{
    public class Session
    {
        [Key]
        public int SessionID { get; set; }
        [Required]
        public DateTime DateDebut { get; set; }
        [Required]
        public DateTime DateFin { get; set; }
        [Required]
        public int NbrPlaceTotal { get; set; }
        [Required]
        [StringLength(30)]
        public string Lieu { get; set; }

        public bool SessionValider { get; set; }

        public virtual OrganismeFormation OrganismeFomationConcerne { get; set; }

        public ObservableCollection<SessionEmployee> ListeEmployeeConcernees { get; set; }

        public Session()
        {
            this.SessionValider = false;
            this.ListeEmployeeConcernees = new ObservableCollection<SessionEmployee>();
        }
    }
}
