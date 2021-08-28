using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models.ViewModel
{
    public class UserMachineViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<CncMachine> Machines { get; set; }

    }
}
