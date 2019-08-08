using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GardenBuddy.Models
{
    public class PlantGarden
    {

        public int PlantGardenId { get; set; }

        public int PlantId { get; set; }

        public int GardenBedId { get; set; }

        [Range(1, 20)]
        public int rowNumber { get; set; }
        [Range(1, 100)]
        public int plantCount { get; set; }

        public Plant Plant { get; set; }

        public GardenBed GardenBed { get; set; }

    }
}
