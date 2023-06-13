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
    public class TierListRepository : ITierListRepository
    {
        private readonly TierDbContext _context;
        public TierListRepository(TierDbContext context)
        {
            _context = context;
        }

        public int AddTierList(TierList tierList)
        {
            _context.TierLists.Add(tierList);
            _context.SaveChanges();
            return tierList.Id;
        }

        public List<TierList> GetTierLists()
        {
            return _context.TierLists.ToList();
        }
    }
}
