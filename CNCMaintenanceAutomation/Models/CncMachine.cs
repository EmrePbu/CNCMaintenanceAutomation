using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    public class CncMachine
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        public string MachineType { get; set; }
        [Required]
        public string DateOfManufacture { get; set; }
        [Required]
        public double OperationTime { get; set; }
        public string Description { get; set; }
        ///
        [Required]
        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}