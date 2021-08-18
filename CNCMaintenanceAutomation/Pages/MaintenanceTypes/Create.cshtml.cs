using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Models;
using CNCMaintenanceAutomation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CNCMaintenanceAutomation.Pages.MaintenanceTypes
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public MaintenanceType MaintenanceType { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Adding data to database
            _context.MaintenanceTypes.Add(MaintenanceType);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
    