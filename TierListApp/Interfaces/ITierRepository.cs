using System.Collections.Generic;
using TierListApp.Models;

namespace TierListApp.Interfaces
{
    public interface ITierRepository
    {
        void AddTier(Tier tier);
        void AddTiers(IList<Tier> tiers);
    }
}