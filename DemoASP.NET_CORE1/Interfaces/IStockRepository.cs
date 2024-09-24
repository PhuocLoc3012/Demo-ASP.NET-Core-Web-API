using DemoASP.NET_CORE1.Dtos.Stock;
using DemoASP.NET_CORE1.Helpers;
using DemoASP.NET_CORE1.Models;

namespace DemoASP.NET_CORE1.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock> GetByIdAsync(int id);//FirstOrDefault can be NULL
        Task<Stock> CreateAsyn(Stock stockModel);
        Task<Stock> UpdateAsyn(int id, UpdateStockRequestDTO stockDTO);
        Task<Stock> DeleteByIdAsync(int id);
        Task<bool> StockExists(int id); 
    }
}
