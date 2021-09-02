using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models;
using CNCMaintenanceAutomation.Models.ViewModel;
using CNCMaintenanceAutomation.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Pages.Maintenances
{
    [Authorize(Roles = StaticValues.AdminUser)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Post metoduna bagliyoruz.
        [BindProperty]
        public CncMachineMaintenanceServiceViewModel CncMachineMaintenanceServiceViewModel { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Pages/Machines/Index.cshtml - Line 128 - router name
        public async Task<IActionResult> OnGetAsync(int? cncMachineId)
        {
            if (cncMachineId == null)
            {
                return NotFound();
            }

            CncMachineMaintenanceServiceViewModel = new CncMachineMaintenanceServiceViewModel
            {
                CncMachine = await _context.CncMachines.Include(a => a.ApplicationUser).FirstOrDefaultAsync(a => a.Id == cncMachineId),
                MaintenanceServiceGeneral = new Models.MaintenanceServiceGeneral(),
            };

            List<String> MaintenanceServiceCardList = _context.MaintenanceServiceCards.Include(a => a.MaintenanceType).Where(a => a.CncMachineId == cncMachineId).Select(a => a.MaintenanceType.MaintenanceName).ToList();

            //C# 'de LINQ sorgularý yazma#
            IQueryable<MaintenanceType> MaintenanceTypesList = from x in _context.MaintenanceTypes where !(MaintenanceServiceCardList.Contains(x.MaintenanceName)) select x;

            CncMachineMaintenanceServiceViewModel.MaintenanceTypesList = MaintenanceTypesList.ToList();

            CncMachineMaintenanceServiceViewModel.MaintenanceServiceCardsList = _context.MaintenanceServiceCards.Include(a => a.MaintenanceType).Where(a => a.CncMachineId == cncMachineId).ToList();


            CncMachineMaintenanceServiceViewModel.MaintenanceServiceGeneral.TotalPrice = 0;
            foreach (var item in CncMachineMaintenanceServiceViewModel.MaintenanceServiceCardsList)
            {
                CncMachineMaintenanceServiceViewModel.MaintenanceServiceGeneral.TotalPrice += item.MaintenanceType.MaintenancePrice;
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            ///
            if (!ModelState.IsValid)
            {
                CncMachineMaintenanceServiceViewModel.MaintenanceServiceGeneral.CreationDate = DateTime.Now;

                CncMachineMaintenanceServiceViewModel.MaintenanceServiceCardsList = _context.MaintenanceServiceCards.Include(a => a.MaintenanceType).Where(a => a.CncMachineId == CncMachineMaintenanceServiceViewModel.CncMachine.Id).ToList();


                foreach (var item in CncMachineMaintenanceServiceViewModel.MaintenanceServiceCardsList)
                {
                    CncMachineMaintenanceServiceViewModel.MaintenanceServiceGeneral.TotalPrice += item.MaintenanceType.MaintenancePrice;
                }

                CncMachineMaintenanceServiceViewModel.MaintenanceServiceGeneral.CncMachineId = CncMachineMaintenanceServiceViewModel.CncMachine.Id;

                _context.MaintenanceServiceGenerals.Add(CncMachineMaintenanceServiceViewModel.MaintenanceServiceGeneral);
                await _context.SaveChangesAsync();


                foreach (var item in CncMachineMaintenanceServiceViewModel.MaintenanceServiceCardsList)
                {
                    MaintenanceServiceDetail maintenanceServiceDetail = new MaintenanceServiceDetail
                    {
                        MaintenanceServiceGeneralId = CncMachineMaintenanceServiceViewModel.MaintenanceServiceGeneral.Id,
                        MaintenanceName = item.MaintenanceType.MaintenanceName,
                        MaintenancePrice = item.MaintenanceType.MaintenancePrice,
                        MaintenanceTypeId = item.MaintenanceTypeId,
                    };
                    _context.MaintenanceServiceDetails.Add(maintenanceServiceDetail);
                }

                _context.MaintenanceServiceCards.RemoveRange(CncMachineMaintenanceServiceViewModel.MaintenanceServiceCardsList);

                await _context.SaveChangesAsync();

                return RedirectToPage("../Machines/Index", new { ownerId = CncMachineMaintenanceServiceViewModel.CncMachine.OwnerId });
            }
            return Page();
        }
    }
}