using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Pages.Machines
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public UserMachineViewModel UserMachineViewModel { get; set;}

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
