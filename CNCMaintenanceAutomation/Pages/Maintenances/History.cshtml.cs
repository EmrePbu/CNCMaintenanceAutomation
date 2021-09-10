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
    /// Bu PageModel Cnc Makine icin gecmis bakim bilgilerini gosterir.
    /// Ayrica Authorize degiskeni ile yetkilendirilme yapilarak sadece sisteme uye olan kisilerin bu Model e erisimi saglanmistir.
    /// </summary>
    [Authorize]
    public class HistoryModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public HistoryModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<MaintenanceServiceGeneral> MaintenanceServiceGeneral { get; set; }

        public string OwnerId { get; set; }

        public async Task OnGet(int cncMachineId)
        {
            MaintenanceServiceGeneral = await _context.MaintenanceServiceGenerals.Include(a => a.CncMachine).Include(a => a.CncMachine.ApplicationUser).Where(a => a.CncMachineId == cncMachineId).ToListAsync();

            OwnerId = _context.CncMachines.Where(a => a.Id == cncMachineId).ToList().FirstOrDefault().OwnerId;
        }
    }
}
