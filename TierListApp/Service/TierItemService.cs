﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TierListApp.Interfaces;
using TierListApp.Models;

namespace TierListApp.Service
{
    public class TierItemService : ITierItemService
    {
        private readonly ITierItemRepository _tierItemRepository;
        public TierItemService(ITierItemRepository tierItemRepository)
        {
            _tierItemRepository = tierItemRepository;
        }
        public List<string>? ChooseItem()
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Multiselect = true;
            OpenFile.Title = "Select image";
            OpenFile.Filter = "Select image| *.jpeg; *.jpg;*.png;";
            if (OpenFile.ShowDialog() == true)
            {
                List<string> files = new List<string>();
                foreach(var file in OpenFile.FileNames)
                {
                    files.Add(file);
                }
                return files;
            }
            return null;
        }

        public List<TierItem> GetNotAssignedItems(int tierListId)
        {
            return _tierItemRepository.GetNotAssignedItems(tierListId);
        }

        public void ChangeItemPlace(Tier? tier, TierItem SelectedItem, ObservableCollection<Tier> Tiers, ObservableCollection<TierItem> TierItems)
        {
            if (tier == null)
            {
                Tiers.Where(e => e.Id == SelectedItem.TierId).FirstOrDefault().TierItems.Remove(SelectedItem);
                SelectedItem.TierId = null;
                TierItems.Add(SelectedItem);
            }
            else
            {

                    if (SelectedItem.TierId == null)
                    {
                        TierItems.Remove(SelectedItem);
                    }
                    else
                    {
                        Tiers.Where(e => e.Id == SelectedItem.TierId).FirstOrDefault().TierItems.Remove(SelectedItem);
                    }
                    SelectedItem.TierId = tier.Id;
                    Tiers.Where(e => e.Id == tier.Id).FirstOrDefault().TierItems.Add(SelectedItem);
                
            }
        }

        public void DeleteItem(TierItem? SelectedItem, ObservableCollection<Tier> Tiers, ObservableCollection<TierItem> TierItems, List<TierItem> ItemsToDelete)
        {
            if (SelectedItem != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (SelectedItem.TierId == null)
                    {
                        TierItems.Remove(SelectedItem);
                    }
                    else
                    {
                        Tiers.Where(e => e.Id == SelectedItem.TierId).FirstOrDefault().TierItems.Remove(SelectedItem);
                    }
                    if (SelectedItem.Id != 0)
                    {
                        ItemsToDelete.Add(SelectedItem);
                    }
                    SelectedItem = null;
                }
            }
        }

        public void SaveTierItems(ObservableCollection<Tier> Tiers, ObservableCollection<TierItem> TierItems, List<TierItem> ItemsToDelete)
        {
            List<TierItem> tmpTierItems = new List<TierItem>();
            foreach (var tier in Tiers)
            {
                foreach (var tieritem in tier.TierItems)
                {
                    tmpTierItems.Add(tieritem);
                }
            }
            foreach (var tierItem in TierItems)
            {
                tmpTierItems.Add(tierItem);
            }

            _tierItemRepository.RemoveItems(ItemsToDelete);
            ItemsToDelete.Clear();

            List<TierItem> tierItemsDB = _tierItemRepository.GetTierItemsByTierList(Tiers.First().TierListId);
            for(int i = 0; i < tmpTierItems.Count; i++)
            {
                _tierItemRepository.UpdateTierItem(tmpTierItems[i]);
            }
            _tierItemRepository.SaveChanges();
        }
    }
}
