using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using humanemission.Model;

namespace humanemission.Data
{
    public class humanemissionContext : DbContext
    {
        public humanemissionContext (DbContextOptions<humanemissionContext> options)
            : base(options)
        {
        }

        public DbSet<humanemission.Model.Emissions> Emissions { get; set; } = default!;
    }
}
