using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    /// <summary>
    /// Musterilere tanimlanacak olan Cnc makineleri olusturacak ViewModel
    /// </summary>
    public class CncMachine
    {
        /// <summary>
        /// Makine Id si ve primary key olarak tanimlanmistir.
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Makineye ait seri numarasini icerir.
        /// Ve Zorunlu alan olarak secilmistir.
        /// </summary>
        [Required]
        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }
        /// <summary>
        /// Makine Marka bilgisini icerir.
        /// Ve Zorunlu alan olarak secilmistir.
        /// </summary>
        [Required]
        [Display(Name = "Brand")]
        public string Brand { get; set; }
        /// <summary>
        /// Makineye ait model bilgisini icerir.
        /// Ve Zorunlu alan olarak secilmistir.
        /// </summary>
        [Required]
        [Display(Name = "Model")]
        public string Model { get; set; }
        /// <summary>
        /// Makineye ait tip bilgisini icerir.
        /// Ve Zorunlu alan olarak secilmistir.
        /// </summary>
        [Required]
        [Display(Name = "Machine Type")]
        public string MachineType { get; set; }
        /// <summary>
        /// Makineye ait uretim yili bilgisini icerir.
        /// Ve Zorunlu alan olarak secilmistir.
        /// </summary>
        [Required]
        [Display(Name = "Date of Manufacture")]
        public string DateOfManufacture { get; set; }
        /// <summary>
        /// Makineye ait calisma saati bilgisini icerir.
        /// Ve Zorunlu alan olarak secilmistir.
        /// </summary>
        [Required]
        [Display(Name = "Operation Time")]
        public double OperationTime { get; set; }
        /// <summary>
        /// Makineye ait detay  bilgisini icerir.
        /// </summary>
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Her bir makinenin bir sahibi olmasi gerektigi icin
        /// Makineye tanimlanan sahipinin id bilgisini icerir.
        /// Ve Zorunlu alan olarak secilmistir.
        /// </summary>
        [Required]
        public string OwnerId { get; set; }
        /// <summary>
        /// Makinenin sahibi olan musteri bilsidir ve Foreign key olarak secilmistir.
        /// </summary>
        [ForeignKey("OwnerId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}