using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique
{
    class Employee
    {
        [Key]
        public string Matricule { get; set; }

        [Required]
        [StringLength(30)]
        public string Nom { get; set; }
        [Required]
        [StringLength(30)]
        public string Prenom { get; set; }

        public virtual ICollection<Formation> CesFormations { get; set; }

    }
}
