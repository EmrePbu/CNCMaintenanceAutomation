using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    /// <summary>
    /// Cnc makinelerine yapilacak olan bakimin tanimlandigi ViewModel
    /// </summary>
    public class MaintenanceType
    {
        /// <summary>
        /// Her bir bakima ait primary olarak belirlenen Id bilgisini icerir.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Bakima ait bakim adini barindirir.
        /// Zorunlu alan olarak secilmistir.
        /// Girilmemesi durumunda gosterilecek olan hata mesaji burada girilmistir.
        /// Server Side Validation olarak gecer.
        /// </summary>
        [Required(ErrorMessage = "Maintenance Name not null")]
        public string MaintenanceName { get; set; }
        /// <summary>
        /// Bakima ait fiyat bilgisini icerir.
        /// Zorunlu alan olarak secilmistir.
        /// Girilmemesi durumunda gosterilecek olan hata mesaji burada girilmistir.
        /// Server Side Validation olarak gecer.
        /// </summary>
        [Required(ErrorMessage = "Maintenance Type not null")]
        public double MaintenancePrice { get; set; }
    }
}