using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TierListApp.Interfaces;
using TierListApp.Models;

namespace TierListApp.Service
{
    public class TierItemService : ITierItemService
    {
        public string? ChooseItem()
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Multiselect = false;
            OpenFile.Title = "Select image";
            OpenFile.Filter = "Select image| *.jpeg; *.jpg;*.png;";
            if (OpenFile.ShowDialog() == true)
            {
                return OpenFile.FileName;
            }
            return null;
        }

        public void ChangeItemPlace(Tier? tier, TierItem SelectedItem, ObservableCollection<Tier> Tiers, ObservableCollection<TierItem> TierItems)
        {
            if (tier == null)
            {
                Tiers.Where(e => e.Id == SelectedItem.TierId).FirstOrDefault().TierItems.Remove(SelectedItem);
                SelectedItem.TierId = 0;
                TierItems.Add(SelectedItem);
            }
            else
            {

                    if (SelectedItem.TierId == 0)
                    {
                        TierItems.RemoveAt(SelectedItem.Id);
                    }
                    else
                    {
                        Tiers.Where(e => e.Id == SelectedItem.TierId).FirstOrDefault().TierItems.Remove(SelectedItem);
                    }
                    SelectedItem.TierId = tier.Id;
                    Tiers.Where(e => e.Id == tier.Id).FirstOrDefault().TierItems.Add(SelectedItem);

                    //tier.TierItems.Add(SelectedItem);
                    //Tiers.Where(e => e.Id == 1).FirstOrDefault().TierItems.Add(new TierItem() { Id = 1, Note = "blabla", Source = "C:\\Users\\Mateu\\Downloads\\929164_grafika-ewoluuje-ale-do-tylu.jpg", TierId = 1, TierListId = 1 });
                
            }
        }
    }
}
