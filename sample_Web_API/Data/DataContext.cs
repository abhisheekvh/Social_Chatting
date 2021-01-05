using Microsoft.EntityFrameworkCore;
using sample_Web_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_Web_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext( DbContextOptions options) : base(options)
        {

        }
        public DbSet<AppUser> Users { get; set; }
    }
}
