using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CNCMaintenanceAutomation.Pages.MaintenanceTypes
{
    public class CreateModel : PageModel
    {
        public MaintenanceType MaintenanceType { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
    