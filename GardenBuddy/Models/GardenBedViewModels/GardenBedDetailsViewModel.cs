using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardenBuddy.Models.GardenBedViewModels
{
    public class GardenBedDetailsViewModel
    {

        public Plant Plant { get; set; }

        public GardenBed GardenBeds { get; set; }

        public IFormFile Photo { get; set; }

        public PlantGarden Plantgarden { get; set; }

        public class totalRowWidth {
           public double rowWidth { get; set; }

            public int plantCount { get; set; }

            public Plant Plant { get; set; }
        }

        public List<totalRowWidth> totalWidth { get; set; }

        public double TotalWidth
        {
            get
            {
                var sum = 0.0;
                foreach (var li in totalWidth)
                {
                    sum += li.rowWidth;
                }
                return sum;
            }
        }

        public double totalRowLength
        {
            get
            {
                var sum = 0.0;
                foreach (var length in totalWidth)
                {
                    sum += length.plantCount + length.Plant.BetweenPlants;
                }
                return sum;
            }
        }

    }
}
