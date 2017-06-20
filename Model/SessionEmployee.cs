using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model
{
    public class SessionEmployee
    {
        [Key]
        public int SessionEmployeesID { get; set; }

        public virtual Employee EmployeeConcerne { get; set; }

        public virtual Session SessionConcerne { get; set; }
    }
}
