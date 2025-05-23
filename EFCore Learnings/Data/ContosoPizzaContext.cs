﻿using Microsoft.EntityFrameworkCore;
using EFCore_Learnings.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Learnings.Data
{
    public class ContosoPizzaContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=ContosoPizza;Trusted_Connection=True;TrustServerCertificate=True;"); // PC GABRIEL

        }
    }
}
