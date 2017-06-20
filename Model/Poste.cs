using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaltAirAtlantique.Model
{
    public class Poste
    {
        [Key]
        public int PosteID { get; set; }

        [Required]
        public string Nom { get; set; }

        public string Description { get; set; }

        public ObservableCollection<Employee> ListeEmployee { get; set; }
        public ObservableCollection<PosteFormation> ListeFormationMini { get; set; }


        public Poste()
        {
            ListeEmployee = new ObservableCollection<Employee>();
            ListeFormationMini = new ObservableCollection<PosteFormation>();
        }
    }
}
