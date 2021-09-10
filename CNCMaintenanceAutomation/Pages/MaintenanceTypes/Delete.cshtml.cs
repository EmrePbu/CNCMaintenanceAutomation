using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models;
using Microsoft.AspNetCore.Authorization;
using CNCMaintenanceAutomation.Utility;

namespace CNCMaintenanceAutomation.Pages.MaintenanceTypes
{
    /// <summary>
    /// Bu PageModel Bakimlari silme islemini yapar.
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
        public MaintenanceType MaintenanceType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaintenanceType = await _context.MaintenanceTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (MaintenanceType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MaintenanceType = await _context.MaintenanceTypes.FindAsync(id);

            if (MaintenanceType != null)
            {
                _context.MaintenanceTypes.Remove(MaintenanceType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
