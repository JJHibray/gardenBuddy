using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardenBuddy.Models.PlantViewModels
{
    public class CreatePlantViewModel
    {
        public IFormFile Photo { get; set; }

        public Plant plant { get; set; }

    }
}
