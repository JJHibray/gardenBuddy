using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardenBuddy.Models
{
    public class PlantGarden
    {

        public int PlantGardenId { get; set; }

        public int PlantId { get; set; }

        public int GardenBedId { get; set; }

        public int rowNumber { get; set; }

        public int plantCount { get; set; }

    }
}
