using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models;
using Microsoft.AspNetCore.Authorization;
using CNCMaintenanceAutomation.Utility;

namespace CNCMaintenanceAutomation.Pages.MaintenanceTypes
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // biz sadece fiyat bilgisini guncellemek istiyoruz. 
            // fakat bu kod satiri veritabanina butun bilgileri tekrardan gonderiyor.
            //_context.Attach(MaintenanceType).State = EntityState.Modified;

            var MaintenanceFromDb = await _context.MaintenanceTypes.FirstOrDefaultAsync(a => a.Id == MaintenanceType.Id);
            MaintenanceFromDb.MaintenanceName = MaintenanceType.MaintenanceName;
            MaintenanceFromDb.MaintenancePrice = MaintenanceType.MaintenancePrice;

            await _context.SaveChangesAsync();

            /// Veritabanina veri kaydederken
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!MaintenanceTypeExists(MaintenanceType.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return RedirectToPage("./Index");
        }

        //private bool MaintenanceTypeExists(int id)
        //{
        //    return _context.MaintenanceTypes.Any(e => e.Id == id);
        //}
    }
}
