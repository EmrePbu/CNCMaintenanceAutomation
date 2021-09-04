using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    public class MaintenanceServiceGeneral
    {
        public int Id { get; set; }
        
        [Display(Name ="Machine Operation Time")]
        public double MachineOperationTime { get; set; }
        
        [Required]
        [Display(Name ="Total Price")]
        public double TotalPrice { get; set; }
        
        [Display(Name ="Details")]
        public string Details { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        [Display(Name ="Creation Date")]
        public DateTime CreationDate { get; set; }

        public int CncMachineId { get; set; }

        //Burada ki key onceden MachineId idi
        [ForeignKey("CncMachineId")]
        [Display(Name ="Cnc Machine")]
        public virtual CncMachine CncMachine { get; set; }

    }
}
