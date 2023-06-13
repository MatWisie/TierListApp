using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace TierListApp.Interfaces
{
    public interface INavigationStore
    {
        ObservableObject CurrentViewModel { get; set; }

        event Action CurrentViewModelChanged;

        void ReloadTierLists();
        event Action CurrentTierListsChanged;


    }
}