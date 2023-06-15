using System.Collections.Generic;
using TierListApp.DTO;
using TierListApp.Models;

namespace TierListApp.Interfaces
{
    public interface ITierListService
    {
        void CreateTierList(TierListDTO tierListDTO, List<TierDTO> tiersDTO);
        List<TierListDTO> GetTierLists();
        TierList? GetTierListInclude(int tierListId);
    }
}