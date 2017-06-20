using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique
{
    class Catalogue
    {
        [Key]
        public int CatalogueID { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }


        public virtual ICollection<Formation> Formations { get; set; }

        public virtual Organisme Organisme { get; set; }
    }
}
