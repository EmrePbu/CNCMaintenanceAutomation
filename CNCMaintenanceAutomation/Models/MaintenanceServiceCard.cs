using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    public class MaintenanceServiceCard
    {   
        public int Id { get; set; }
        public int CncMachineId { get; set; }
        public int MaintenanceTypeId { get; set; }

        [ForeignKey("MachineId")]
        public virtual CncMachine CncMachine { get; set; }
        
        [ForeignKey("MaintenanceTypeId")]
        public virtual MaintenanceType MaintenanceType { get; set; }


    }
}
