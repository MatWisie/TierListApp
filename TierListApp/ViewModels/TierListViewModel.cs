using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TierListApp.Interfaces;
using TierListApp.Models;

namespace TierListApp.ViewModels
{
    partial class TierListViewModel : ObservableObject, IRecipient<TierListIdMessage>
    {
        private readonly ITierListService _tierListService;
        private readonly ITierItemService _tierItemService;
        public TierListViewModel(ITierListService tierListService, ITierItemService tierItemService)
        {
            WeakReferenceMessenger.Default.Register<TierListIdMessage>(this);
            _tierListService = tierListService;
            _tierItemService = tierItemService;
        }

        [ObservableProperty]
        private int tierListId;

        [ObservableProperty]
        private string tierListName;

        [ObservableProperty]
        private ObservableCollection<Tier> tiers = new ObservableCollection<Tier>();
        [ObservableProperty]
        private ObservableCollection<TierItem> tierItems = new ObservableCollection<TierItem>();

        [ObservableProperty]
        private TierItem? selectedItem;

        private List<TierItem> itemsToDelete = new List<TierItem>();

        [RelayCommand]
        private void AddItem()
        {
            List<string>? paths = _tierItemService.ChooseItem();
            if(paths != null)
            {
                foreach(var path in paths)
                {
                    TierItems.Add(new TierItem() { Note = "", Source = path, TierId = null, TierListId = TierListId });
                }
            }
        }

        [RelayCommand]
        private void ChangeSelectedItem(TierItem selectedItem)
        {
            SelectedItem = selectedItem;
        }

        [RelayCommand]
        private void PlaceItem(Tier? tier)
        {
            if(SelectedItem != null)
                _tierItemService.ChangeItemPlace(tier, SelectedItem, Tiers, TierItems);
        }

        [RelayCommand]
        private void SaveTierItems()
        {
            _tierItemService.SaveTierItems(Tiers, TierItems, itemsToDelete);
            SelectedItem = null;
            ReloadView(TierListId);
        }

        [RelayCommand]
        private void DeleteItem()
        {
            _tierItemService.DeleteItem(SelectedItem, Tiers, TierItems, itemsToDelete);
        }

        private void ReloadView(int tierListId)
        {
            TierListId = tierListId;
            TierList? tierList = _tierListService.GetTierListInclude(tierListId);
            if (tierList != null)
            {
                TierListName = tierList.Name;
                Tiers = new ObservableCollection<Tier>(tierList.Tiers);
                TierItems = new ObservableCollection<TierItem>(_tierItemService.GetNotAssignedItems(tierListId));
            }
        }

        public void Receive(TierListIdMessage message)
        {
            ReloadView(message.Id);
        }
    }
}
