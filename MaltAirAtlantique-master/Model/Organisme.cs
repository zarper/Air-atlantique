using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique
{
    class Organisme
    {
        [Key]
        public int OrganismeID { get; set; }
        [Required]
        [StringLength(30)]
        public string Nom { get; set; }

        public string ContactNom { get; set; }

        public string ContactPrenom { get; set; }

        public string ContactMail { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }

        public virtual ICollection<Catalogue> Catalogues { get; set; }

    }
}
