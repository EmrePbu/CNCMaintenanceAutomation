using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    /// <summary>
    /// Bakim bilgilerini iceren ViewModel
    /// </summary>
    public class MaintenanceServiceDetail
    {
        /// <summary>
        /// Bakim bilgisi olusturan ViewModel e ait Id bilgisini icerir.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Genel Bakim hizmetini iceren Id bilgisidir.
        /// </summary>
        public int MaintenanceServiceGeneralId { get; set; }
        /// <summary>
        /// Genel bakim hizmetini icerir ve MaintenanceServiceGeneralId ile iliskilendirilmistir.
        /// ForeignKey olarak secilmistir.
        /// </summary>
        [ForeignKey("MaintenanceServiceGeneralId")]
        public virtual MaintenanceServiceGeneral MaintenanceServiceGeneral { get; set; }
        /// <summary>
        /// Bakim tipine ait Id bilgisinidir.
        /// Ekrada gorunen ismi burada belirtilmistir.
        /// </summary>
        [Display(Name = "Maintenance Type Id")]
        public int MaintenanceTypeId { get; set; }
        /// <summary>
        /// Bakim tipini icerir ve MaintenanceId ile iliskilendirilmistir.
        /// Ayrica ForeignKey olarka secilmistir.
        /// Ekranda gorunen ismi burada belirtilmistir.
        /// </summary>
        [ForeignKey("MaintenanceId")]
        [Display(Name = "Maintenance Type")]
        public virtual MaintenanceType MaintenanceType { get; set; }
        /// <summary>
        /// Bakima ait fiyat bilgisini icerir.
        /// Ekranda gorunen ismi burada belirtilmistir.
        /// </summary>
        [Display(Name = "Maintenance Price")]
        public double MaintenancePrice { get; set; }
        /// <summary>
        /// Bakima ait isim bilgisini icerir.
        /// Ekranda gorunen ismi burada belirtilmistir.
        /// </summary>
        [Display(Name = "Maintenance Name")]
        public string MaintenanceName { get; set; }
    }
}