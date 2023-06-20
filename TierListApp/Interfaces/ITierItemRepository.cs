using System.Collections.Generic;
using TierListApp.Models;

namespace TierListApp.Interfaces
{
    public interface ITierItemRepository
    {
        List<TierItem> GetTierItemsByTierList(int tierListId);
        void UpdateTierItem(TierItem tierItem);
        List<TierItem> GetNotAssignedItems(int tierListId);
        void SaveChanges();
    }
}