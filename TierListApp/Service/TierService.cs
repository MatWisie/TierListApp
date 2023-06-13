using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TierListApp.DTO;
using TierListApp.Interfaces;
using TierListApp.Models;

namespace TierListApp.Service
{
    public class TierService : ITierService
    {
        private readonly ITierListRepository _tierListRepository;
        private readonly ITierRepository _tierRepository;

        public TierService(ITierListRepository tierListRepository, ITierRepository tierRepository)
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
        
        public List<TierListDTO> GetTierLists()
        {
            var tierLists = _tierListRepository.GetTierLists();
            List<TierListDTO> tmpListOfTiers = new List<TierListDTO>();
            foreach (var tierList in tierLists)
            {
                TierListDTO tmpTierListDTO = new TierListDTO()
                {
                    Name = tierList.Name,
                    CreatedDate = tierList.CreatedDate
                };
                tmpListOfTiers.Add(tmpTierListDTO);
            }
            return tmpListOfTiers;
        }
    }
}
