using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TierListApp.Models;

namespace TierListApp.Data
{
    public class TierDbContext : DbContext
    {
        public TierDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Tier> Tiers { get; set; }
        public DbSet<TierItem> TierItems { get; set; }
        public DbSet<TierList> TierLists { get; set; }
        
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite($"Data Source=TierDB.db");
            }
        
    }
}
