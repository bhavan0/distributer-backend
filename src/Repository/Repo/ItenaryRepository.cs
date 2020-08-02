using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repo
{
    public class ItenaryRepository : IItenaryRepository
    {
        internal DistributerContext Context { get; }

        public ItenaryRepository(DistributerContext context)
        {
            Context = context;
        }

        public async Task<IList<ItenaryEntity>> GetItenaryForDay(string date)
        {
            return await Context.Itenary.Include(x => x.Item)
                                               .Where(x => x.Date.Equals(date))
                                               .ToListAsync()
                                               .ConfigureAwait(false);
        }

        public async Task<ItenaryEntity> GetOnDateItenaryOfOneItem(int itemId, string date)
        {
            return await Context.Itenary.Include(x => x.Item)
                                               .Where(x => x.ItemId == itemId && x.Date.Equals(date))
                                               .FirstOrDefaultAsync()
                                               .ConfigureAwait(false);
        }

        public async Task<IList<ItenaryEntity>> GetTillDateItenary()
        {
            return await Context.Itenary.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IList<ItenaryEntity>> GetTillDateItenaryOfOneItem(int itemId)
        {
            return await Context.Itenary.Where(x => x.ItemId == itemId)
                                        .ToListAsync()
                                        .ConfigureAwait(false);
        }

        public async Task<int> AddItemsBoughtForDate(ItenaryEntity itemDate)
        {
            await Context.Itenary.AddAsync(itemDate);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateItemsBoughtForDate(ItenaryEntity itemDate)
        {
            Context.Itenary.Update(itemDate);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<int> UpdateItemsSoldForDate(int itenaryId, int soldCount)
        {
            var itemDate = await Context.Itenary.Where(x => x.Id == itenaryId).FirstOrDefaultAsync().ConfigureAwait(false);
            itemDate.SoldCount = soldCount;
            Context.Itenary.Update(itemDate);
            return await Context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
