using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BnSystem_Test.Models
{
    public class StoreDb : DbContext
    {
        public StoreDb(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccTransfers> AccTransfers { get; set; }
    }
}
