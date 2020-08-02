using Domain.Models;
using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStoreItemsService
    {
        Task<StoreDetails> GetAllItemBoughtByStore(int storeId);

        Task<StoreDetails> GetAllItemBoughtByStoreOnDate(int storeId, string date);

        Task<int> AddItemBoughtByStoreOnDate(StoreItemEntity storeItemEntity);

        Task<int> UpdateItemBoughtByStoreOnDate(StoreItemEntity storeItemEntity);
    }
}
