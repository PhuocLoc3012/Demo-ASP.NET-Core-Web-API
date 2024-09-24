using DemoASP.NET_CORE1.Data;
using DemoASP.NET_CORE1.Dtos.Stock;
using DemoASP.NET_CORE1.Helpers;
using DemoASP.NET_CORE1.Interfaces;
using DemoASP.NET_CORE1.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoASP.NET_CORE1.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsyn(Stock stockModel)
        {
           await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock> DeleteByIdAsync(int id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stockModel == null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stocks =   _context.Stocks.Include(c => c.Comments).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            if (!string.IsNullOrWhiteSpace(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));

            }

            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stocks = query.IsDecsending ? stocks.OrderByDescending(s => s.Symbol) : stocks.OrderBy(s => s.Symbol);
                }
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await stocks.Skip(skipNumber).Take(query.PageSize). ToListAsync();  
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<bool> StockExists(int id)
        {
            return await _context.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<Stock> UpdateAsyn(int id, UpdateStockRequestDTO stockDTO)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingStock == null)
            {
                return null;
            }
            existingStock.Symbol = stockDTO.Symbol;
            existingStock.MarketCap = stockDTO.MarketCap;
            existingStock.Purchase = stockDTO.Purchase;
            existingStock.CompanyName = stockDTO.CompanyName;
            existingStock.LastDiv = stockDTO.LastDiv;
            existingStock.Industry = stockDTO.Industry;
            await _context.SaveChangesAsync();  
            return existingStock;
        }
    }
}
