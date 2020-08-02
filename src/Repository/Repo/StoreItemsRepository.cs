using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class StoreItemsRepository : IStoreItemsRepository
    {
        internal DistributerContext Context { get; }

        public StoreItemsRepository(DistributerContext context)
        {
            Context = context;
        }

        public async Task<IList<StoreItemEntity>> GetAllItemsBoughtByStore(int storeId)
        {
            return await Context.StoreItems.Include(x => x.Item)
                                           .Include(x => x.Store)
                                           .Where(x => x.StoreId == storeId)
                                           .ToListAsync()
                                           .ConfigureAwait(false);
        }

        public async Task<IList<StoreItemEntity>> GetAllItemsBoughtByStoreOnDate(int storeId, string date)
        {
            return await Context.StoreItems.Include(x => x.Item)
                                           .Include(x => x.Store)
                                           .Where(x => x.StoreId == storeId && x.Date.Equals(date))
                                           .ToListAsync()
                                           .ConfigureAwait(false);
        }

        public async Task<int> AddItemBoughtByStore(StoreItemEntity storeItemEntity)
        {
            await Context.StoreItems.AddAsync(storeItemEntity).ConfigureAwait(false);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateItemBoughtByStore(StoreItemEntity storeItemEntity)
        {
            Context.StoreItems.Update(storeItemEntity);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
