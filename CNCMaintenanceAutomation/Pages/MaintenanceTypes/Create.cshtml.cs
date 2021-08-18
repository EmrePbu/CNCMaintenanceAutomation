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
        private readonly ApplicationDbContext _applicationDbcontext;

        [BindProperty]
        public MaintenanceType MaintenanceType { get; set; }

        public CreateModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbcontext = applicationDbContext;
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
            _applicationDbcontext.MaintenanceTypes.Add(MaintenanceType);
            await _applicationDbcontext.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
    