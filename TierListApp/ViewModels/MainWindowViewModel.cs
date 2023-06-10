using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using TierListApp.Interfaces;
using TierListApp.Navigation;

namespace TierListApp.ViewModels
{
    partial class MainWindowViewModel : ObservableObject
    {
        private readonly INavigationStore _navigationStore;

        public MainWindowViewModel(INavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        
        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(currentView));
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
