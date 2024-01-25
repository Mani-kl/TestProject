using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Models;

namespace TestAPI.DAL
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
