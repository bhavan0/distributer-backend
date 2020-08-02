using Domain.Interfaces;
using Repository.Entities;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ItenaryService : IItenaryService
    {
        private readonly IItenaryRepository _itenaryRepository;

        public ItenaryService(IItenaryRepository repo)
        {
            _itenaryRepository = repo;
        }

        public async Task<IList<ItenaryEntity>> GetItenaryForDay(string date)
        {
            return await _itenaryRepository.GetItenaryForDay(date).ConfigureAwait(false);
        }

        public async Task<ItenaryEntity> GetOnDateItenaryOfOneItem(int itemId, string date)
        {
            return await _itenaryRepository.GetOnDateItenaryOfOneItem(itemId, date).ConfigureAwait(false);
        }

        public async Task<IList<ItenaryEntity>> GetTillDateItenary()
        {
            return await _itenaryRepository.GetTillDateItenary().ConfigureAwait(false);
        }

        public async Task<IList<ItenaryEntity>> GetTillDateItenaryOfOneItem(int itemId)
        {
            return await _itenaryRepository.GetTillDateItenaryOfOneItem(itemId).ConfigureAwait(false);
        }

        public async Task<int> AddItemsBoughtForDate(ItenaryEntity itemDate)
        {
            return await _itenaryRepository.AddItemsBoughtForDate(itemDate).ConfigureAwait(false);
        }

        public async Task<int> UpdateItemsBoughtForDate(ItenaryEntity itemDate)
        {
            return await _itenaryRepository.UpdateItemsBoughtForDate(itemDate).ConfigureAwait(false);
        }

        public async Task<int> UpdateItemsSoldForDate(int itenaryId, int soldCount)
        {
            return await _itenaryRepository.UpdateItemsSoldForDate(itenaryId, soldCount).ConfigureAwait(false);
        }
    }
}
