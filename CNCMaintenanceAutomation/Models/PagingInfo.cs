using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    public class PagingInfo
    {
        // Kullanici, urun, vb. seylerin sayisi
        public int TotalItems { get; set; }
        
        // Her sayfada gorulecek seylerin sayisi
        public int ItemsPerPage { get; set; }
        
        // Guncel sayfam
        public int CurrentPage { get; set; }
        
        // Toplam sayfa sayisini gosteriyorum
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems/ ItemsPerPage);

        // Her sayfada degismesi gereken url adresi icin
        public string UrlParam { get; set; }



    }
}
