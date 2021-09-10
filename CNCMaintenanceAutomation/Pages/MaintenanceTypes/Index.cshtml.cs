using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CNCMaintenanceAutomation.Models;
using Microsoft.EntityFrameworkCore;
using CNCMaintenanceAutomation.Utility;
using Microsoft.AspNetCore.Authorization;

namespace CNCMaintenanceAutomation.Pages.MaintenanceTypes
{
    /// <summary>
    /// Bu PageModel Bakim ekraninin Index Modeli bu model uzerinden Ekleme Silme Duzenleme  ve Goruntuleme islemi yapilir.
    /// Ayrica Authorize degiskeni ile yetkilendirilme yapilarak sadece YONETICI olan kisilerin bu Model e erisimi saglanmistir.
    /// </summary>
    [Authorize(Roles = StaticValues.AdminUser)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        
        public IList<MaintenanceType> MaintenanceType { get; set; }

        public async Task<IActionResult> OnGet()
        {
            MaintenanceType = await _applicationDbContext.MaintenanceTypes.ToListAsync();
            return Page();
        }
    }
}