using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique
{
    class Formation
    {
        [Key]
        public int FormationID { get; set; }
        [Required]
        [StringLength(30)]
        public string Nom { get; set; }
        public string Description { get; set; }
        public float DureeEnHeure { get; set; }
        public int DureeDeValidite { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

    }
}
