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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            if (id.Trim().Length == 0)
            {
                return NotFound();
            }

            ApplicationUser = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Id == id);
            
            if (ApplicationUser == null)
            {
                return NotFound();
            }
            
            return Page();
        }
    }
}
