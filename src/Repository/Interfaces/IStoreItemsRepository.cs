using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStoreItemsRepository
    {
        Task<IList<StoreItemEntity>> GetAllItemsBoughtByStore(int storeId);

        Task<IList<StoreItemEntity>> GetAllItemsBoughtByStoreOnDate(int storeId, string date);

        Task<int> AddItemBoughtByStore(StoreItemEntity storeItemEntity);

        Task<int> UpdateItemBoughtByStore(StoreItemEntity storeItemEntity);
    }
}
