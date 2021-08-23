using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models;
using CNCMaintenanceAutomation.Models.ViewModel;
using CNCMaintenanceAutomation.Utility;
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
        public UsersListViewModel UsersListViewModel { get; set; }

        //[BindProperty]
        //public List<ApplicationUser> ApplicationUsersList { get; set; }

        public async Task<IActionResult> OnGet(int productPage = 1)
        {
            //ApplicationUsersList = await _context.ApplicationUsers.ToListAsync();
            UsersListViewModel = new UsersListViewModel()
            {
                ApplicationUsersList = await _context.ApplicationUsers.ToListAsync()
            };

            StringBuilder param = new StringBuilder();
            // Checkpoint : dikkat
            param.Append("/Users?productPage=:");

            var count = UsersListViewModel.ApplicationUsersList.Count;

            UsersListViewModel.PagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                // ITEMS PER PAGE
                ItemsPerPage = StaticValues.NumberOfItemsOnPage,
                TotalItems = count,
                UrlParam = param.ToString(),
            };

            // ITEMS PER PAGE
            UsersListViewModel.ApplicationUsersList = UsersListViewModel.ApplicationUsersList.OrderBy(a => a.Email).Skip((productPage - 1) * StaticValues.NumberOfItemsOnPage).Take(StaticValues.NumberOfItemsOnPage).ToList();

            return Page();
        }
    }
}