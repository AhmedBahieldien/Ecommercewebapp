using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MYAPP.Models.Users;
using MYAPP.Models.Items;

namespace MYAPP.Models
{
    public class MYAPPContext : DbContext
    {
        public MYAPPContext (DbContextOptions<MYAPPContext> options)
            : base(options)
        {
        }

        public DbSet<MYAPP.Models.Users.user> user { get; set; }

        public DbSet<MYAPP.Models.Items.Item> Item { get; set; }
    }
}
