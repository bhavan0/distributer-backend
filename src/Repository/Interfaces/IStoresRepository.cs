using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStoresRepository
    {
        Task<IList<StoreEntity>> GetAllStores();

        Task<StoreEntity> GetStoreById(int storeId);

        Task<int> AddStore(StoreEntity item);

        Task<int> UpdateStore(StoreEntity item);
    }
}
