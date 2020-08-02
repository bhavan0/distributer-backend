using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class ItemsRepository : IItemsRepository
    {
        internal DistributerContext Context { get; }

        public ItemsRepository(DistributerContext context)
        {
            Context = context;
        }

        public async Task<IList<ItemEntity>> GetAllItems()
        {
            return await Context.Items.ToListAsync().ConfigureAwait(false);
        }

        public async Task<ItemEntity> GetItemById(int itemId)
        {
            return await Context.Items.Where(x => x.Id == itemId).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<int> AddItem(ItemEntity item)
        {
            await Context.Items.AddAsync(item);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateItem(ItemEntity item)
        {
            Context.Items.Update(item);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
