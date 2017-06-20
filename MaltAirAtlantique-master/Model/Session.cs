using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique
{
    class Session
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
    }
}
