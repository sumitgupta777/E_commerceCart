using DemoProject1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DemoProject1.ViewModel;

namespace DemoProject1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Products> Products { get; set; }

        public DbSet<CartItems> CartItems { get; set; }

        public DbSet<DemoProject1.ViewModel.OrderViewModel> OrderViewModel { get; set; }
    }
}
