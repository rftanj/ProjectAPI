﻿using Microsoft.EntityFrameworkCore;
using ProjectAPI.Models.DB;

namespace ProjectAPI.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options) 
        { 
        }

        public virtual DbSet<Customer> Customers { get; set; }

    }
}
