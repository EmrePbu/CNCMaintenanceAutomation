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
        
        public double MachineOperationTime { get; set; }
        
        [Required]
        public double TotalPrice { get; set; }
        
        public string Details { get; set; }

        [Required]
        [DisplayFormat(DataFormatString ="{0:dd/MMM/YYYY}")]
        public DateTime CreationDate { get; set; }

        public int CncMachineId { get; set; }

        //Burada ki key onceden MachineId idi
        [ForeignKey("CncMachineId")]
        public virtual CncMachine CncMachine { get; set; }

    }
}
