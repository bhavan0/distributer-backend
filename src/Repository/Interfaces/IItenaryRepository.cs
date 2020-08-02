using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IItenaryRepository
    {
        Task<int> AddItemsBoughtForDate(ItenaryEntity itemDate);

        Task<int> UpdateItemsBoughtForDate(ItenaryEntity itemDate);

        Task<int> UpdateItemsSoldForDate(int itenaryId, int soldCount);

        Task<IList<ItenaryEntity>> GetItenaryForDay(string date);

        Task<IList<ItenaryEntity>> GetTillDateItenary();

        Task<IList<ItenaryEntity>> GetTillDateItenaryOfOneItem(int itemId);

        Task<ItenaryEntity> GetOnDateItenaryOfOneItem(int itemId, string date);
    }
}
