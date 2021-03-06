using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Pages.Maintenances
{
    /// <summary>
    /// Bu PageModel Cnc Makine icin detay bilgileri gosterir.
    /// Ayrica Authorize degiskeni ile yetkilendirilme yapilarak sadece sisteme uye olan kisilerin bu Model e erisimi saglanmistir.
    /// </summary>
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public MaintenanceServiceGeneral MaintenanceServiceGeneral { get; set; }
        public List<MaintenanceServiceDetail> MaintenanceServiceDetails { get; set; }

        public void OnGet(int? maintenanceId)
        {

            MaintenanceServiceGeneral = _context.MaintenanceServiceGenerals.Include(a => a.CncMachine).Include(a => a.CncMachine.ApplicationUser).FirstOrDefault(a => a.Id == maintenanceId);

            MaintenanceServiceDetails = _context.MaintenanceServiceDetails.Where(a => a.MaintenanceServiceGeneralId == maintenanceId).ToList();
        }
    }
}
