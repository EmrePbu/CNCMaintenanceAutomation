using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models.ViewModel
{
    public class CncMachineMaintenanceServiceViewModel
    {
        public CncMachine CncMachine { get; set; }
        public MaintenanceServiceGeneral MaintenanceServiceGeneral { get; set; }
        public MaintenanceServiceDetail MaintenanceServiceDetail { get; set; }

        public List<MaintenanceType> MaintenanceTypesList { get; set; }
        public List<MaintenanceServiceCard> MaintenanceServiceCardsList { get; set; }
    }
}