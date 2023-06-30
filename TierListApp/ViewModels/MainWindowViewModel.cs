using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using TierListApp.DTO;
using TierListApp.Interfaces;
using TierListApp.Models;
using TierListApp.Navigation;

namespace TierListApp.ViewModels
{
    partial class MainWindowViewModel : ObservableObject
    {
        private readonly INavigationStore _navigationStore;
        private readonly ITierListService _tierListService;

        public MainWindowViewModel(INavigationStore navigationStore, ITierListService tierService)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _tierListService = tierService;
            tierLists = new ObservableCollection<TierList>(_tierListService.GetTierLists());
            _navigationStore.CurrentTierListsChanged += ReloadListOfTiers;
        }


        [ObservableProperty]
        private ObservableCollection<TierList> tierLists;


        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(currentView));
        }

        private void ReloadListOfTiers()
        {
            TierLists = new ObservableCollection<TierList>(_tierListService.GetTierLists());
        }

        [RelayCommand]
        public void GoToAdd()
        {
            currentView = App.Current.Services.GetService<AddTierListViewModel>();
        }

        [RelayCommand]
        public void GoToTierList(int tierListId)
        {
            currentView = App.Current.Services.GetService<TierListViewModel>();
            WeakReferenceMessenger.Default.Send(new TierListIdMessage(tierListId));
        }

        public ObservableObject? currentView
        {
            get
            {
                return _navigationStore.CurrentViewModel;
            }
            set
            {
                _navigationStore.CurrentViewModel = value;
                OnPropertyChanged(nameof(currentView));
            }
        }
        [RelayCommand]
        private void DeleteTierList(TierList tierList)
        {
            _tierListService.DeleteTierList(tierList, TierLists);
            currentView = null;
        }
    }
}
