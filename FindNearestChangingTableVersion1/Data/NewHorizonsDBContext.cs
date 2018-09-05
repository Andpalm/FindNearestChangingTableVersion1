using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindNearestChangingTableVersion1.Data
{
    public class NewHorizonsDBContext : DbContext
    {
        public NewHorizonsDBContext()
        {
        }

        public NewHorizonsDBContext(DbContextOptions<NewHorizonsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Markers> Markers { get; set; }
    }
}
