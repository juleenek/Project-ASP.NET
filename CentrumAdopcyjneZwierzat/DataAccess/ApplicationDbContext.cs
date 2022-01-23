
using CentrumAdopcyjneZwierzat.Models.AdoptionCenter;
using CentrumAdopcyjneZwierzat.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentrumAdopcyjneZwierzat.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}
