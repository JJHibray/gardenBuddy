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

            public Plant Plant { get; set; }
        }

        public List<totalRowWidth> totalWidth { get; set; }

        public class totalRowLength
        {
            public Plant Plant { get; set; }

            public int plantCount { get; set; }

        }

        public List<totalRowLength> totalLength { get; set; }
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

        static KeyValuePair<int, double> ToFeetInches(double inches)
        {
            return new KeyValuePair<int, double>((int)inches / 12, inches % 12);
        }
    

    public double TotalRowLength
        {
            get
            {
                var sum = 0.0;
                foreach (var length in totalLength)
                {
                    sum += length.plantCount + length.Plant.BetweenPlants;
                }
                return sum;
            }
        }

    }
}
