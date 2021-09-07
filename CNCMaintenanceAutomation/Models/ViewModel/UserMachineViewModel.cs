using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models.ViewModel
{
    /// <summary>
    /// Kullanici makine iliskinin olusturuldugu ViewModel
    /// </summary>
    public class UserMachineViewModel
    {
        /// <summary>
        /// Her makinenin bir kullanicisi vardir.
        /// </summary>
        public ApplicationUser ApplicationUser { get; set; }
        /// <summary>
        /// Her kullanicininda bir makinesi vardir.
        /// </summary>
        public IEnumerable<CncMachine> Machines { get; set; }

    }
}
