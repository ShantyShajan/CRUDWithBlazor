﻿using CRUDWithBlazor.Data;
using Microsoft.EntityFrameworkCore;

namespace CRUDWithBlazor.Context
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        { 
        
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
