using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TierListApp.Interfaces;

namespace TierListApp.Navigation
{
    public class NavigationStore : INavigationStore
    {
        private ObservableObject _currentViewModel;
        public ObservableObject CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;



        public void ReloadTierLists()
        {
            CurrentTierListsChanged?.Invoke();
        }

        public event Action CurrentTierListsChanged;


    }
}

