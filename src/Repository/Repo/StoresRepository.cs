using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class StoresRepository : IStoresRepository
    {
        internal DistributerContext Context { get; }

        public StoresRepository(DistributerContext context)
        {
            Context = context;
        }

        public async Task<IList<StoreEntity>> GetAllStores()
        {
            return await Context.Stores.ToListAsync().ConfigureAwait(false);
        }

        public async Task<StoreEntity> GetStoreById(int storeId)
        {
            return await Context.Stores.Where(x => x.Id == storeId).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> AddStore(StoreEntity store)
        {
            await Context.Stores.AddAsync(store);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateStore(StoreEntity store)
        {
            Context.Stores.Update(store);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
