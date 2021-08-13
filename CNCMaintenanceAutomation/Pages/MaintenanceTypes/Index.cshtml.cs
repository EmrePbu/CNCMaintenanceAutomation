using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CNCMaintenanceAutomation.Models;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Pages.MaintenanceTypes
{
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