using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TierListApp.Models;

namespace TierListApp.ViewModels
{
    partial class AddTierListViewModel : ObservableObject
    {
        [ObservableProperty]
        private string tierListName = "LALAL";

        [ObservableProperty]
        private ObservableCollection<Tier> listOfTiers = new ObservableCollection<Tier>();


        [RelayCommand]
        public void AddNewTier()
        {
            Tier tmpTier = new Tier
            {
                Id = 1,
                Name = "S",
                TierListId = 1
            };

            ListOfTiers.Add(tmpTier);
        }
    }
}
