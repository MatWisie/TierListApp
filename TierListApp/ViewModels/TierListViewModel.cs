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

        [RelayCommand]
        private void AddItem()
        {
            /*
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Multiselect = true;
            OpenFile.Title = "Select image";
            OpenFile.Filter = "Select image| *.jpeg; *.jpg;*.png;";
            if (OpenFile.ShowDialog() == true)
            {
                string path = OpenFile.FileName;
                TierItems.Add(new TierItem() { Note = "", Source = OpenFile.FileName, TierId = 0, TierListId = 0 });
            }
            */
            string? path = _tierItemService.ChooseItem();
            if(path != null)
            {
                TierItems.Add(new TierItem() { Note = "", Source = path, TierId = 0, TierListId = TierListId });
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
            /*
            if(tier == null && SelectedItem != null)
            {
                Tiers.Where(e => e.Id == SelectedItem.TierId).FirstOrDefault().TierItems.Remove(SelectedItem);
                SelectedItem.TierId = 0;
                TierItems.Add(SelectedItem);
            }
            else
            {
                if (SelectedItem != null)
                {
                    if (SelectedItem.TierId == 0)
                    {
                        TierItems.RemoveAt(SelectedItem.Id);
                    }
                    else
                    {
                        Tiers.Where(e => e.Id == SelectedItem.TierId).FirstOrDefault().TierItems.Remove(SelectedItem);
                    }
                    SelectedItem.TierId = tier.Id;
                    Tiers.Where(e => e.Id == tier.Id).FirstOrDefault().TierItems.Add(SelectedItem);

                    //tier.TierItems.Add(SelectedItem);
                    //Tiers.Where(e => e.Id == 1).FirstOrDefault().TierItems.Add(new TierItem() { Id = 1, Note = "blabla", Source = "C:\\Users\\Mateu\\Downloads\\929164_grafika-ewoluuje-ale-do-tylu.jpg", TierId = 1, TierListId = 1 });
                }
            }
            */
            if(SelectedItem != null)
                _tierItemService.ChangeItemPlace(tier, SelectedItem, Tiers, TierItems);
        }


        public void Receive(TierListIdMessage message)
        {
            TierListId = message.Id;
            TierList? tierList = _tierListService.GetTierListInclude(message.Id);
            if(tierList != null)
            {
                TierListName = tierList.Name;
                Tiers = new ObservableCollection<Tier>(tierList.Tiers);
            }
        }
    }
}
