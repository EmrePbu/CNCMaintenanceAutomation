using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CNCMaintenanceAutomation.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CNCMaintenanceAutomation.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            //[Required]
            [EmailAddress]
            [Display(Name = "E-Mail")]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Name, Last Name")]
            public string NameLastName { get; set; }

            [Required]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [Display(Name = "City")]
            public string City { get; set; }

            [Required]
            [Display(Name = "Zip Code")]
            public string ZipCode { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);


            //Username = userName;

            //Input = new InputModel
            //{
            //    PhoneNumber = phoneNumber
            //};

            var DatabaseFromUser = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Email == user.Email);

            Username = DatabaseFromUser.UserName;

            Input = new InputModel
            {
                Email = DatabaseFromUser.Email,
                PhoneNumber = DatabaseFromUser.PhoneNumber,
                NameLastName = DatabaseFromUser.NameLastName,
                Address = DatabaseFromUser.Address,
                City = DatabaseFromUser.City,
                ZipCode = DatabaseFromUser.ZipCode,
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var DatabaseFromUser = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Email == user.Email);

            Username = DatabaseFromUser.UserName;

            Input = new InputModel
            {
                Email = DatabaseFromUser.Email,
                PhoneNumber = DatabaseFromUser.PhoneNumber,
                NameLastName = DatabaseFromUser.NameLastName,
                Address = DatabaseFromUser.Address,
                City = DatabaseFromUser.City,
                ZipCode = DatabaseFromUser.ZipCode,
            };

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var DatabaseFromUSer = await _context.ApplicationUsers.FirstOrDefaultAsync(a => a.Email == user.Email);

            DatabaseFromUSer.Email = Input.Email;
            DatabaseFromUSer.PhoneNumber = Input.PhoneNumber;
            DatabaseFromUSer.NameLastName = Input.NameLastName;
            DatabaseFromUSer.Address = Input.Address;
            DatabaseFromUSer.City = Input.City;
            DatabaseFromUSer.ZipCode = Input.ZipCode;

            await _context.SaveChangesAsync();

            // Default Code
            //var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //if (Input.PhoneNumber != phoneNumber)
            //{
            //    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
            //    if (!setPhoneResult.Succeeded)
            //    {
            //        StatusMessage = "Unexpected error when trying to set phone number.";
            //        return RedirectToPage();
            //    }
            //}

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
