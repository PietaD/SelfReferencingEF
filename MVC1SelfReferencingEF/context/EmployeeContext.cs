﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVC1SelfReferencingEF.Models;

namespace MVC1SelfReferencingEF.context
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Manager)
                .WithMany()
                .HasForeignKey(m => m.ManagerID);

            base.OnModelCreating(modelBuilder);
        }
    }
}