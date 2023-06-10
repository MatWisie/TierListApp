using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TierListApp.Data;
using TierListApp.Interfaces;
using TierListApp.Models;

namespace TierListApp.Repository
{
    public class TierRepository : ITierRepository
    {
        private readonly TierDbContext _context;
        public TierRepository(TierDbContext context)
        {
            _context = context;
        }

        public void AddTiers(IList<Tier> tiers)
        {
            _context.Tiers.AddRange(tiers);
            _context.SaveChanges();
        }
        public void AddTier(Tier tier)
        {
            _context.Tiers.Add(tier);
            _context.SaveChanges();
        }
    }
}
