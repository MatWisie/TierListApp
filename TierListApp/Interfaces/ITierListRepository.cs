using System.Collections.Generic;
using TierListApp.Models;

namespace TierListApp.Interfaces
{
    public interface ITierListRepository
    {
        int AddTierList(TierList tierList);
        List<TierList> GetTierLists();
        TierList? GetTierListInclude(int id);
    }
}