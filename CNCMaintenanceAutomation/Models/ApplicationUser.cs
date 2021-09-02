using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// add-migration AddAplicationUser
        /// update-database
        /// </summary>
        [Display(Name = "Name, Last Name")]
        public string NameLastName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }



    }
}