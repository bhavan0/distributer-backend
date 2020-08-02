using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IStoresService
    {
        Task<IList<StoreEntity>> GetAllStores();

        Task<StoreEntity> GetStoreById(int storeId);

        Task<int> AddStore(StoreEntity store);

        Task<int> UpdateStore(StoreEntity store);
    }
}
