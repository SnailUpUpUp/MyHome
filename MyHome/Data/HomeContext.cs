using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyHome.Models
{
    public class HomeContext : DbContext
    {
        public HomeContext (DbContextOptions<HomeContext> options)
            : base(options)
        {
        }

        public DbSet<MyHome.Models.Temperature> Temperature { get; set; }
    }
}
