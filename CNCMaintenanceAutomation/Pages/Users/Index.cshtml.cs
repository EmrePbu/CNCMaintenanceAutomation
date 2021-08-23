using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context; 

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<ApplicationUser> ApplicationUsersList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ApplicationUsersList = await _context.ApplicationUsers.ToListAsync();
            return Page();
        }
    }
}
