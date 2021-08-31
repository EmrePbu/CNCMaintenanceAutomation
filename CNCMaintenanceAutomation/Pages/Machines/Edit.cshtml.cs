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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        public CncMachine CncMachine { get; set; }

        [TempData]
        public string Message { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            CncMachine = await _context.CncMachines.Include(a => a.ApplicationUser).FirstOrDefaultAsync(b => b.Id == id);

            if (CncMachine == null)
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

                // biz sadece fiyat bilgisini guncellemek istiyoruz. 
                // fakat bu kod satiri veritabanina butun bilgileri tekrardan gonderiyor.
                //_context.Attach(MaintenanceType).State = EntityState.Modified;

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
                var CncMachineFromDb = await _context.CncMachines.SingleOrDefaultAsync(a => a.Id == CncMachine.Id);
                if (CncMachineFromDb == null)
                {
                    return NotFound();
                }
                else
                {
                    CncMachineFromDb.SerialNumber = CncMachine.SerialNumber;
                    CncMachineFromDb.Brand = CncMachine.Brand;
                    CncMachineFromDb.Model = CncMachine.Model;
                    CncMachineFromDb.MachineType = CncMachine.MachineType;
                    CncMachineFromDb.DateOfManufacture = CncMachine.DateOfManufacture;
                    CncMachineFromDb.OperationTime = CncMachine.OperationTime;
                    CncMachineFromDb.Description = CncMachine.Description;

                    await _context.SaveChangesAsync();
                    Message = "Edit Cnc Machine Successfully";
                    return RedirectToPage("./Index", new { userId = CncMachine.OwnerId });
                }
            }
        }
    }
}
