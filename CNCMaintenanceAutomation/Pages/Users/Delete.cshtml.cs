using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models;
using CNCMaintenanceAutomation.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Pages.Users
{
    /// <summary>
    /// Bu PageModel sisteme kayitli kisilerin silme islemini yapar
    /// Ayrica Authorize degiskeni ile yetkilendirilme yapilarak sadece YONETICI olan kisilerin bu Model e erisimi saglanmistir.
    /// </summary>
    [Authorize(Roles = StaticValues.AdminUser)]
    public class DeleteModel : PageModel
    {

        private readonly ApplicationDbContext _context;
        
        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id.Trim().Length == 0)
            {
                return NotFound();
            }
            ApplicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(model => model.Id == id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {

            if (id.Trim().Length == 0)
            {
                return NotFound();
            }
            ApplicationUser = await _context.ApplicationUsers.FindAsync(id);
            
            if (ApplicationUser != null)
            {
                _context.ApplicationUsers.Remove(ApplicationUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
