using Domain.Interfaces;
using Domain.Models;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class StoreItemsService : IStoreItemsService
    {
        private readonly IStoreItemsRepository _storeItemsRepository;

        public StoreItemsService(IStoreItemsRepository repo)
        {
            _storeItemsRepository = repo;
        }

        public async Task<StoreDetails> GetAllItemBoughtByStore(int storeId)
        {
            var storeItemEntities = await _storeItemsRepository.GetAllItemsBoughtByStore(storeId).ConfigureAwait(false);
            return MapStoreItemEntityToStoreDetails(storeItemEntities);
        }

        public async Task<StoreDetails> GetAllItemBoughtByStoreOnDate(int storeId, string date)
        {
            var storeItemEntities = await _storeItemsRepository.GetAllItemsBoughtByStoreOnDate(storeId, date).ConfigureAwait(false);
            return MapStoreItemEntityToStoreDetails(storeItemEntities);
        }

        public async Task<int> AddItemBoughtByStoreOnDate(StoreItemEntity storeItemEntity)
        {
            return await _storeItemsRepository.AddItemBoughtByStore(storeItemEntity).ConfigureAwait(false);
        }

        public async Task<int> UpdateItemBoughtByStoreOnDate(StoreItemEntity storeItemEntity)
        {
            return await _storeItemsRepository.UpdateItemBoughtByStore(storeItemEntity).ConfigureAwait(false);
        }

        private StoreDetails MapStoreItemEntityToStoreDetails(IList<StoreItemEntity> storeItemEntities)
        {
            var storeDetails = new StoreDetails();
            storeDetails.Id = storeItemEntities[0].StoreId;
            storeDetails.Name = storeItemEntities[0].Store.Name;

            var groupedByDate = storeItemEntities.GroupBy(x => x.Date);
            storeDetails.DateStoreItemsData = new List<DateStoreItemsData>();
            foreach (var group in groupedByDate)
            {
                DateStoreItemsData dateStoreItemsData = new DateStoreItemsData();
                dateStoreItemsData.Date = group.Key;
                dateStoreItemsData.StoreItems = new List<StoreItemsData>();
                foreach (var item in group)
                {
                    StoreItemsData storeItemsData = new StoreItemsData();
                    storeItemsData.ItemId = item.ItemId;
                    storeItemsData.Id = item.Id;
                    storeItemsData.Name = item.Item.Name;
                    storeItemsData.Date = group.Key;
                    storeItemsData.SellingPrice = item.Item.SellingPrice;
                    storeItemsData.BoughtCount = item.BoughtCount;
                    dateStoreItemsData.StoreItems.Add(storeItemsData);
                }
                storeDetails.DateStoreItemsData.Add(dateStoreItemsData);
            }
            return storeDetails;
        }
    }
}
