using DemoASP.NET_CORE1.Dtos.Stock;
using DemoASP.NET_CORE1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace DemoASP.NET_CORE1.Mappers
{
    public static class StockMappers
    {
        //chuyển từ stock lưu ở db sang stockdto (là stock chế thêm)
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Industry = stockModel.Industry,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c => c.ToCommentDTO()).ToList()
            };
        }

        //map request thành object lưu xuống  db
        public static Stock ToStockFromCreateDTO( this CreateStockRequestDTO createStockRequestDTO)
        {
            return new Stock
            {
                Symbol = createStockRequestDTO.Symbol,
                CompanyName = createStockRequestDTO.CompanyName,    
                Purchase = createStockRequestDTO.Purchase,
                LastDiv = createStockRequestDTO.LastDiv,
                MarketCap = createStockRequestDTO.MarketCap,
                Industry = createStockRequestDTO.Industry,
            };
        }


    }
}
