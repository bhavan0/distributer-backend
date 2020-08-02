using Domain.Interfaces;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IItemsRepository _itemsRepository;

        public ItemsService(IItemsRepository repo)
        {
            _itemsRepository = repo;
        }

        public async Task<IList<ItemEntity>> GetAllItems()
        {
            return await _itemsRepository.GetAllItems().ConfigureAwait(false);
        }

        public async Task<ItemEntity> GetItemById(int itemId)
        {
            return await _itemsRepository.GetItemById(itemId).ConfigureAwait(false);
        }

        public async Task<int> AddItem(ItemEntity item)
        {
            return await _itemsRepository.AddItem(item).ConfigureAwait(false);
        }

        public async Task<int> UpdateItem(ItemEntity item)
        {
            return await _itemsRepository.UpdateItem(item).ConfigureAwait(false);
        }
    }
}
