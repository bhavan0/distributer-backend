using Repository.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IItemsService
    {
        Task<IList<ItemEntity>> GetAllItems();

        Task<ItemEntity> GetItemById(int itemId);

        Task<int> AddItem(ItemEntity item);

        Task<int> UpdateItem(ItemEntity item);
    }
}
