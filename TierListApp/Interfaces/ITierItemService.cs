using System.Collections.ObjectModel;
using TierListApp.Models;

namespace TierListApp.Interfaces
{
    public interface ITierItemService
    {
        void ChangeItemPlace(Tier? tier, TierItem SelectedItem, ObservableCollection<Tier> Tiers, ObservableCollection<TierItem> TierItems);
        string? ChooseItem();
    }
}