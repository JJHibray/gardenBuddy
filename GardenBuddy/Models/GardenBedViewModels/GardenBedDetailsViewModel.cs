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

    }
}
