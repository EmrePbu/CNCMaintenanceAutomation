using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models.ViewModel
{
    /// <summary>
    /// Cnc makinelerine ait bakimlarin model sayfasi
    /// </summary>
    public class CncMachineMaintenanceServiceViewModel
    {
        /// <summary>
        /// Her bir bakima ait olan cnc makinesinin tutulur.
        /// </summary>
        public CncMachine CncMachine { get; set; }
        /// <summary>
        /// Her bir bakimin bilgisini iceren genel degisken
        /// </summary>
        public MaintenanceServiceGeneral MaintenanceServiceGeneral { get; set; }
        /// <summary>
        /// Makineye ait bakim sisteme girilirken diger detaylari icerir
        /// </summary>
        public MaintenanceServiceDetail MaintenanceServiceDetail { get; set; }
        /// <summary>
        /// Bir makineye birden fazla bakim secilebilecegi icin olusturulan bakim listesidir.
        /// </summary>
        public List<MaintenanceType> MaintenanceTypesList { get; set; }
        /// <summary>
        /// Makineye ait bakimlarin toplandigi alisveris sepeti gorevini gorur.
        /// </summary>
        public List<MaintenanceServiceCard> MaintenanceServiceCardsList { get; set; }
    }
}