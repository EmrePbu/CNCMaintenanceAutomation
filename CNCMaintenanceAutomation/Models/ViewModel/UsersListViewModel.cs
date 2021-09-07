using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Models.ViewModel
{
    /// <summary>
    /// Kullanicilari listelemek icin olusturulan ViewModel
    /// </summary>
    public class UsersListViewModel
    {
        /// <summary>
        /// Kullanicilari iceren liste.
        /// </summary>
        public List<ApplicationUser> ApplicationUsersList { get; set; }
        /// <summary>
        /// Kullanicilari sayfa sayfa gostermek icin tanimlanan degisken.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }


    }
}