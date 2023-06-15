using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
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
        public TierListViewModel(ITierListService tierListService)
        {
            WeakReferenceMessenger.Default.Register<TierListIdMessage>(this);
            _tierListService = tierListService;
        }

        [ObservableProperty]
        private int tierListId;

        [ObservableProperty]
        private string tierListName;

        [ObservableProperty]
        private ObservableCollection<Tier> tiers = new ObservableCollection<Tier>();

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
