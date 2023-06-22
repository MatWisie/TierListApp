using System.Collections.Generic;
using System.Collections.ObjectModel;
using TierListApp.Models;

namespace TierListApp.Interfaces
{
    public interface ITierItemService
    {
        void ChangeItemPlace(Tier? tier, TierItem SelectedItem, ObservableCollection<Tier> Tiers, ObservableCollection<TierItem> TierItems);
        string? ChooseItem();
        void SaveTierItems(ObservableCollection<Tier> Tiers, ObservableCollection<TierItem> TierItems, List<TierItem> ItemsToDelete);
        List<TierItem> GetNotAssignedItems(int tierListId);
        void DeleteItem(TierItem? SelectedItem, ObservableCollection<Tier> Tiers, ObservableCollection<TierItem> TierItems, List<TierItem> ItemsToDelete);
    }
}