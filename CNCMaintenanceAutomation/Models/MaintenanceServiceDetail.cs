using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    public class MaintenanceServiceDetail
    {
        public int Id { get; set; }

        public int MaintenanceServiceGeneralId { get; set; }

        [ForeignKey("MaintenanceServiceGeneralId")]
        public virtual MaintenanceServiceGeneral MaintenanceServiceGeneral { get; set; }

        [Display(Name = "Maintenance Type Id")]
        public int MaintenanceTypeId { get; set; }

        [ForeignKey("MaintenanceId")]
        [Display(Name = "Maintenance Type")]
        public virtual MaintenanceType MaintenanceType { get; set; }

        [Display(Name = "Maintenance Price")]
        public double MaintenancePrice { get; set; }
        [Display(Name = "Maintenance Name")]
        public string MaintenanceName { get; set; }
    }
}