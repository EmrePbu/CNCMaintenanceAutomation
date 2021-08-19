using CNCMaintenanceAutomation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNCMaintenanceAutomation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Bu kisimda migration yapman gerek
        public DbSet<MaintenanceType> MaintenanceTypes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
    