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
    public class TierItemRepository : ITierItemRepository
    {
        private readonly TierDbContext _context;
        public TierItemRepository(TierDbContext context)
        {
            _context = context;
        }

        public List<TierItem> GetTierItemsByTierList(int tierListId)
        {
            return _context.TierItems.Where(e => e.TierListId == tierListId).ToList();
        }
        
        public void UpdateTierItem(TierItem tierItem)
        {
            _context.TierItems.Update(tierItem);
        }

        public List<TierItem> GetNotAssignedItems(int tierListId)
        {
            return _context.TierItems.Where(e => e.TierListId == tierListId && e.TierId == null).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
