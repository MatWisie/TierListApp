using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TierListApp.DTO;
using TierListApp.Interfaces;
using TierListApp.Models;

namespace TierListApp.Service
{
    public class TierListService : ITierListService
    {
        private readonly ITierListRepository _tierListRepository;
        private readonly ITierRepository _tierRepository;

        public TierListService(ITierListRepository tierListRepository, ITierRepository tierRepository)
        {
            _tierListRepository = tierListRepository;
            _tierRepository = tierRepository;
        }

        public void CreateTierList(TierListDTO tierListDTO, List<TierDTO> tiersDTO)
        {
            TierList tmpTierList = new TierList()
            {
                Name = tierListDTO.Name
            };

            int tierListId = _tierListRepository.AddTierList(tmpTierList);
            List<Tier> tmpTiers = new List<Tier>();
            foreach (var tier in tiersDTO)
            {
                Tier tmpTier = new Tier()
                {
                    Name = tier.Name,
                    TierColor = tier.TierColor,
                    TierListId = tierListId
                };
                tmpTiers.Add(tmpTier);
            }
            _tierRepository.AddTiers(tmpTiers);
        }
        
        public List<TierList> GetTierLists()
        {
            return _tierListRepository.GetTierLists();
        }

        public TierList? GetTierListInclude(int tierListId)
        {
            return _tierListRepository.GetTierListInclude(tierListId);
        }

        public void DeleteTierList(TierList tierList)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if(messageBoxResult == MessageBoxResult.Yes)
            {
                _tierListRepository.DeleteTierList(tierList);
                _tierListRepository.SaveChanges();
            }
        }
    }
}
