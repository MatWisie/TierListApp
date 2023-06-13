using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TierListApp.DTO;
using TierListApp.Interfaces;
using TierListApp.Models;

namespace TierListApp.ViewModels
{
    partial class AddTierListViewModel : ObservableObject
    {
        private readonly ITierService _tierService;
        private readonly INavigationStore _navigationStore;
        public AddTierListViewModel(ITierService tierService, INavigationStore navigationStore)
        {
            _tierService = tierService;
            _navigationStore = navigationStore;
        }

        [ObservableProperty]
        private string tierListName = "";

        [ObservableProperty]
        private ObservableCollection<TierDTO> listOfTiers = new ObservableCollection<TierDTO>();


        [RelayCommand]
        public void AddNewTier()
        {
            TierDTO tmpTier = new TierDTO
            {
                Name = "S",
            };

            ListOfTiers.Add(tmpTier);
        }

        [RelayCommand]
        public void CreateTierList()
        {
            TierListDTO tmpTierList = new TierListDTO
            {
                Name = TierListName
            };

            List<TierDTO> tmpListOfTiers = new List<TierDTO>(listOfTiers);
            _tierService.CreateTierList(tmpTierList, tmpListOfTiers);
            _navigationStore.ReloadTierLists();

            _navigationStore.CurrentViewModel = App.Current.Services.GetService<AddTierListViewModel>();
        }
    }
}
