using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GardenBuddy.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        //Made a class in case I wanted to add any other fields for registering but pretty sure it will be just username and password.

    }
}
