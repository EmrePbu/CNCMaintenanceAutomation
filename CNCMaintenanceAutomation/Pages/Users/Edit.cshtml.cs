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
    [Authorize(Roles = StaticValues.AdminUser)]
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

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                var UserFromDb = await _context.ApplicationUsers.SingleOrDefaultAsync(a => a.Id == ApplicationUser.Id);
                if (UserFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    UserFromDb.NameLastName = ApplicationUser.NameLastName;
                    UserFromDb.Address = ApplicationUser.Address;
                    UserFromDb.City = ApplicationUser.City;
                    UserFromDb.ZipCode = ApplicationUser.ZipCode;
                    UserFromDb.PhoneNumber = ApplicationUser.PhoneNumber;

                    await _context.SaveChangesAsync();

                    return RedirectToPage("./Index");
                }
            }
        }

    }
}
