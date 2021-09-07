using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    /// <summary>
    /// Bakimlari iceren alisveris sepeti gorevini goren ViewModel
    /// </summary>
    public class MaintenanceServiceCard
    {
        /// <summary>
        /// Alisverisin Id bilgisi icerir.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Bakim yapilan Cnc Makinesini icerir.
        /// </summary>
        public int CncMachineId { get; set; }
        /// <summary>
        /// Makineye yapilan bakim tipini icerir.
        /// </summary>
        public int MaintenanceTypeId { get; set; }
        /// <summary>
        /// Bakim yapilan makine bilgisini icerir ve CncMachineId ile iliskilendirilmistir.
        /// Ayrica ForeignKey olarak secilmistir.
        /// </summary>
        [ForeignKey("MachineId")]
        public virtual CncMachine CncMachine { get; set; }
        /// <summary>
        /// Makineye yapilin bakim tipini icerir ve MaintenanceTypeId ile iliskilendirilmistir.
        /// Ayrica ForeignKey olarak secilmistir.
        /// </summary>
        [ForeignKey("MaintenanceTypeId")]
        public virtual MaintenanceType MaintenanceType { get; set; }


    }
}
