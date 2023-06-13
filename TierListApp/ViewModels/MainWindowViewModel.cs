﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TierListApp.DTO;
using TierListApp.Interfaces;
using TierListApp.Navigation;

namespace TierListApp.ViewModels
{
    partial class MainWindowViewModel : ObservableObject
    {
        private readonly INavigationStore _navigationStore;
        private readonly ITierService _tierService;

        public MainWindowViewModel(INavigationStore navigationStore, ITierService tierService)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            _tierService = tierService;
            tierLists = new ObservableCollection<TierListDTO>(_tierService.GetTierLists());
            _navigationStore.CurrentTierListsChanged += ReloadListOfTiers;
        }


        [ObservableProperty]
        private ObservableCollection<TierListDTO> tierLists;


        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(currentView));
        }

        private void ReloadListOfTiers()
        {
            TierLists = new ObservableCollection<TierListDTO>(_tierService.GetTierLists());
        }

        [RelayCommand]
        public void GoToAdd()
        {
            currentView = App.Current.Services.GetService<AddTierListViewModel>();
        }

        public ObservableObject currentView
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
    }
}
