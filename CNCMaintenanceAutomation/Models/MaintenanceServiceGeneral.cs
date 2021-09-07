using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    /// <summary>
    /// Genel bakim bilgisini iceren ViewModel
    /// </summary>
    public class MaintenanceServiceGeneral
    {
        /// <summary>
        /// Her bir bakima ait primary olarak belirlenen Id bilgisini icerir.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Cnc makinesinin calisma saatini gosterir.
        /// Ekranda gosterilecek olan ismi burada girilmistir.
        /// </summary>
        [Display(Name = "Machine Operation Time")]
        public double MachineOperationTime { get; set; }
        /// <summary>
        /// Bakimin toplam fiyat bilgisini icerir.
        /// Zorunlu alan olarak secilmistir.
        /// Ekranda gosterilecek olan ismi burada girilmistir.
        /// </summary>
        [Required]
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }
        /// <summary>
        /// Bakima ait detay bilgileri icerir.
        /// Ekranda gosterilecek olan ismi burada girilmistir.
        /// </summary>
        [Display(Name = "Details")]
        public string Details { get; set; }
        /// <summary>
        /// Bakimin olusturulma tarihi icerir.
        /// Zorunlu alan olarak secilmistir.
        /// Ekranda gosterilecek olan ismi burada girilmistir.
        /// Tarih formati burada belirtilmistir.
        /// </summary>
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// Bakima girecek olan makinenin Id bilgisini icerir.
        /// </summary>
        public int CncMachineId { get; set; }
        //!Burada ki key onceden MachineId idi
        /// <summary>
        /// Bakima girecek olan makinedir. ve CncMachineId ile iliskilendirilmistir.
        /// Ayrica ForeignKey olarak secilmistir.
        /// </summary>
        [ForeignKey("CncMachineId")]
        [Display(Name = "Cnc Machine")]
        public virtual CncMachine CncMachine { get; set; }

    }
}
