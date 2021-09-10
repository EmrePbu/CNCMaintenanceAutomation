using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using CNCMaintenanceAutomation.Models;
using CNCMaintenanceAutomation.Models.ViewModel;
using CNCMaintenanceAutomation.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Pages.Users
{
    /// <summary>
    /// Bu PageModel sisteme kayitli kisilerin listelenme islemini yapar
    /// Ayrica Authorize degiskeni ile yetkilendirilme yapilarak sadece YONETICI olan kisilerin bu Model e erisimi saglanmistir.
    /// </summary>
    [Authorize(Roles = StaticValues.AdminUser)]
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

        public async Task<IActionResult> OnGet(
            int productPage = 1,
            string searchNameLastName = null,
            string searchEmail = null,
            string searchPhoneNumber = null)
        {
            //ApplicationUsersList = await _context.ApplicationUsers.ToListAsync();
            UsersListViewModel = new UsersListViewModel()
            {
                ApplicationUsersList = await _context.ApplicationUsers.ToListAsync()
            };
            
            StringBuilder param = new StringBuilder();
            // Search with param
            param.Append("/Users?productPage=:");
            param.Append("&searchNameLastName=");
            if (searchNameLastName!=null)
            {
                param.Append(searchNameLastName);
            }
            param.Append("&searchEmail=");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&searchPhoneNumber=");
            if (searchEmail != null)
            {
                param.Append(searchPhoneNumber);
            }

            if (searchNameLastName != null)
            {
                UsersListViewModel.ApplicationUsersList = await _context.ApplicationUsers.Where(
                    a => a.NameLastName
                    .ToLower()
                    .Contains(searchNameLastName.ToLower()))
                    .ToListAsync();
            }
            else
            {
                if (searchEmail != null)
                {
                    UsersListViewModel.ApplicationUsersList = await _context.ApplicationUsers.Where(
                        a => a.Email
                        .ToLower()
                        .Contains(searchEmail.ToLower()))
                        .ToListAsync();
                }
                else
                {
                    if (searchPhoneNumber != null)
                    {
                        UsersListViewModel.ApplicationUsersList = await _context.ApplicationUsers.Where(
                       a => a.PhoneNumber
                       .ToLower()
                       .Contains(searchPhoneNumber.ToLower()))
                       .ToListAsync();
                    }
                }
            }
            
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