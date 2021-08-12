using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    public class MaintenanceType
    {
        public int Id { get; set; }

        [Required]
        public string MaintenanceName { get; set; }
        [Required]
        public double MaintenancePrice { get; set; }
    }
}