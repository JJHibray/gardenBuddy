using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GardenBuddy.Models
{
    public class Plant
    {
        [Key]
        public int PlantId { get; set; }
        [Required]
        [Display(Name = "Plant")]
        public string PlantName { get; set; }
        [Required]
        [Display(Name = "Row Width(inches)")]
        [Range(.01, 999.99)]
        public double rowWidth { get; set; }
        [Required]
        [Range(.01, 999.99)]
        [Display(Name = "Between Plants(inches)")]
        public double BetweenPlants { get; set; }
        [Required]
        [Display(Name = "Depth to Plant(inches)")]
        [Range(.01, 999.99)]
        public double groundDepth { get; set; }
        [Display(Name = "Best Soil?")]
        public string Soil { get; set; }
        [Required]
        public string Season { get; set; }
        [Required]
        public string Watering { get; set; }
        [Display(Name = "How to Prune")]
        public string Pruning { get; set; }
        [Display(Name = "Possible Pest?")]
        public string Pests { get; set; }
        [Display(Name = "Possible Disease?")]
        public string Disease { get; set; }
        
        [Display(Name = "Misc Care")]
        public string MiscCare { get; set; }
        [Display(Name = "How to Store Plant")]
        public string Storage { get; set; }
        
        [Display(Name = "How to Harvest")]
        public string harvestMethod { get; set; }

        public string ImagePath { get; set; }

        public ApplicationUser user { get; set; }

        public string userId { get; set; }

        public List<PlantGarden> PlantGarden { get; set; }

    }
}
