using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models
{
    /// <summary>
    /// Bu model de listeleme yaparken butun listenin tek ekranda degil de sayfalama yapisi ile gosterilmesini sagladim.
    /// </summary>
    public class PagingInfo
    {
        /// <summary>
        /// Kullanici, urun, vb. listelerin sayisi
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Her sayfada gorulecek itemlerin sayisi
        /// </summary>
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Kullanicinin sectigi guncel sayfa
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Toplam sayfa sayisini tutan degisken
        /// </summary>
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems/ ItemsPerPage);

        /// <summary>
        /// Her sayfada degismesi gereken url adresi icin olusturdugum degisken
        /// </summary>
        public string UrlParam { get; set; }



    }
}
