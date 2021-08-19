using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
        public string NameLastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        


    }
}