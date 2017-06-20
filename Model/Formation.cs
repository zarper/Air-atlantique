using MaltAirAtlantique.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique
{
    public class Formation
    {
        [Key]
        public int FormationID { get; set; }
        [Required]
        [StringLength(30)]
        public string Nom { get; set; }
        public string Description { get; set; }
        public float DureeEnHeure { get; set; }
        public int? DureeDeValidite { get; set; }
        public ObservableCollection<OrganismeFormation> ListOrganismes { get; set; }
        public ObservableCollection<EmployeeFormation> ListEmployees { get; set; }

        public Formation()
        {
            ListOrganismes = new ObservableCollection<OrganismeFormation>();
            ListEmployees = new ObservableCollection<EmployeeFormation>();
        }

    }
}
