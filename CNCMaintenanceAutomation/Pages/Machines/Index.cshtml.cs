using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Pages.Machines
{
    /// <summary>
    /// Bu PageModel musteri ve yoneticilere ait olan makineleri listeler.
    /// Ayrica Authorize degiskeni ile yetkilendirilme yapilarak sadece sisteme uye olan kisilerin bu Model e erisimi saglanmistir.
    /// </summary>
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public UserMachineViewModel UserMachineViewModel { get; set;}

        /// <summary>
        /// TempData PageModel 'ler arasinda veri iletilmesini saglar. Orn. Mesaj
        /// </summary>
        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(string ownerId = null)
        {
            if (ownerId == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                ownerId = claim.Value;
                //return NotFound();
            }

            UserMachineViewModel = new UserMachineViewModel()
            {
                Machines = await _context.CncMachines.Where(a => a.OwnerId == ownerId).ToListAsync(),
                ApplicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Id == ownerId),
            };

            return Page();

        }
    }
}
