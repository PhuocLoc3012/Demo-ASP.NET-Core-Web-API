namespace DemoASP.NET_CORE1.Dtos.Stock
{
    public class UpdateStockRequestDTO
    {
        public string Symbol { get; set; } = string.Empty;// Mã giao dịch của cổ phiếu (ví dụ: AAPL, GOOGL)
        public string CompanyName { get; set; } = string.Empty;


        public decimal Purchase { get; set; }// Giá mua cổ phiếu (ví dụ: 150.50 USD/cổ phiếu)



        public decimal LastDiv { get; set; }
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}
