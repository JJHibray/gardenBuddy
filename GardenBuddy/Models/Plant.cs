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
        public double rowWidth { get; set; }
        [Required]
        public double BetweenPlants { get; set; }
        [Required]
        public double groundDepth { get; set; }
        [Required]
        public string Soil { get; set; }
        [Required]
        public string Season { get; set; }
        [Required]
        public string Watering { get; set; }
        [Required]
        public string Pruning { get; set; }
        [Required]
        public string Pests { get; set; }
        [Required]
        public string Disease { get; set; }
        [Required]
        public string MiscCare { get; set; }
        [Required]
        public string Storage { get; set; }
        [Required]
        public string harvestMethod { get; set; }

        public string ImagePath { get; set; }

        public ApplicationUser user { get; set; }

        public string userId { get; set; }

        public List<PlantGarden> PlantGarden { get; set; }

    }
}
