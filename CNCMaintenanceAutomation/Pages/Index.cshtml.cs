using CNCMaintenanceAutomation.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CNCMaintenanceAutomation.Pages
{
    public class IndexModel : PageModel
    {
        // Default code
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim == null)
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            //
            if (User.IsInRole(StaticValues.AdminUser))
            {
                return RedirectToPage("/Users/Index");
            }
            else if (User.IsInRole(StaticValues.CustomerUser))
            {
                return RedirectToPage("/Machines/Index");
            }
            else
            {
                return NotFound();
            }

        }
    }
}
