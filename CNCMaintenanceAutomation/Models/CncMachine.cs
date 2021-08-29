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
        [Display(Name ="Serial number")]
        public string SerialNumber { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Machine Type")]
        public string MachineType { get; set; }
        [Required]
        [Display(Name = "Date of Manufacture")]
        public string DateOfManufacture { get; set; }
        [Required]
        [Display(Name = "Operation Time")]
        public double OperationTime { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        ///
        [Required]
        public string OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}