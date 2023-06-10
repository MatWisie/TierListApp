using System.Collections.Generic;
using TierListApp.DTO;

namespace TierListApp.Interfaces
{
    public interface ITierService
    {
        void CreateTierList(TierListDTO tierListDTO, List<TierDTO> tiersDTO);
    }
}