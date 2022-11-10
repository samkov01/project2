using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebApp.Models
{
    public class GenshinTierListContext : DbContext
    {
        public GenshinTierListContext (DbContextOptions<GenshinTierListContext> options)
            : base(options)
        {
        }

        public DbSet<AspNetCoreWebApp.Models.TierList> TierList { get; set; } = default!;
    }
}
