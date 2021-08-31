using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Pages.Machines
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CncMachine CncMachine { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }
            CncMachine = await _context.CncMachines.Include(a => a.ApplicationUser).FirstOrDefaultAsync(a => a.Id == id);

            if (CncMachine == null)
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
            CncMachine = await _context.CncMachines.FindAsync(id);

            if (CncMachine != null)
            {
                _context.CncMachines.Remove(CncMachine);
                await _context.SaveChangesAsync();

            }
            Message = "Delete Successfully";
            return RedirectToPage("./Index", new { OwnerId = CncMachine.OwnerId });
        }
    }
}
