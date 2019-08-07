using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GardenBuddy.Models
{
    public class GardenBed
    {
        [Key]
        public int GardenBedId { get; set; }
        [Required]
        public string name { get; set; }

        public ApplicationUser user { get; set; }

        public string userId { get; set; }
        
        public virtual ICollection<PlantGarden> PlantGardens { get; set; }

       


    }
}
