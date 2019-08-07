using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GardenBuddy.Models.GardenBedViewModels
{
    public class AddPlantViewModel
    {
        public virtual ICollection<Plant> Plants { get; set; }

        public Plant Plant { get; set; } 

        public PlantGarden PlantGarden { get; set; }

        public GardenBed GardenBed { get; set; }

        public int GardenBedId { get; set; }

        public int PlantId { get; set; }

        public List<SelectListItem> GardenList { get; set; }


        public List<SelectListItem> PlantList { get; set; }


    
    }
        
}
