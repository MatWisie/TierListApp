using TierListApp.Models;

namespace TierListApp.Interfaces
{
    public interface ITierListRepository
    {
        int AddTierList(TierList tierList);
    }
}