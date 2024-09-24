﻿using DemoASP.NET_CORE1.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoASP.NET_CORE1.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
