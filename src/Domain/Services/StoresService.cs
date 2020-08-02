using Domain.Interfaces;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class StoresService : IStoresService
    {
        private readonly IStoresRepository _storesRpository;

        public StoresService(IStoresRepository repo)
        {
            _storesRpository = repo;
        }

        public async Task<IList<StoreEntity>> GetAllStores()
        {
            return await _storesRpository.GetAllStores().ConfigureAwait(false);
        }

        public async Task<StoreEntity> GetStoreById(int storeId)
        {
            return await _storesRpository.GetStoreById(storeId).ConfigureAwait(false);
        }

        public async Task<int> AddStore(StoreEntity store)
        {
            return await _storesRpository.AddStore(store).ConfigureAwait(false);
        }

        public async Task<int> UpdateStore(StoreEntity store)
        {
            return await _storesRpository.UpdateStore(store).ConfigureAwait(false);
        }
    }
}
