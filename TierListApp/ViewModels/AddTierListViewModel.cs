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
        private readonly ITierListService _tierService;
        private readonly INavigationStore _navigationStore;
        public AddTierListViewModel(ITierListService tierService, INavigationStore navigationStore)
        {
            _tierService = tierService;
            _navigationStore = navigationStore;
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(CreateTierListCommand))]
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
            CreateTierListCommand.NotifyCanExecuteChanged();
        }

        [RelayCommand(CanExecute = nameof(CanSaveTierList))]
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

        private bool CanSaveTierList()
        {
            if(TierListName != "" && ListOfTiers.Count > 1)
            {
                return true;
            }
            return false;
        }
    }
}
