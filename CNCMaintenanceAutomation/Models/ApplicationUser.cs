using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    /// <summary>
    /// Sisteme kayit olacak musterileri tanimlamak icin olusturulan ViewModel
    /// AspNetCore.Identity objesinden miras alinarak olusturulmustur.
    /// ViewModel deki degisiklikleri veritabanina aktarmak icin asagidaki komutlari Package Manager Console uzerinde calistirmak gerek
    /// 
    /// add-migration MIGRATIONNAME
    /// update-database
    /// </summary>
    public class ApplicationUser : IdentityUser
    {

        /// <summary>
        /// Musteri adi ve soyadi
        /// </summary>
        [Display(Name = "Name, Last Name")]
        public string NameLastName { get; set; }
        /// <summary>
        /// Musteri adresi
        /// </summary>
        [Display(Name = "Address")]
        public string Address { get; set; }
        /// <summary>
        /// Musterinin bulundugu sehir
        /// </summary>
        [Display(Name = "City")]
        public string City { get; set; }
        /// <summary>
        /// Musterinin bulundugu adresin posta kodu
        /// </summary>
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }



    }
}