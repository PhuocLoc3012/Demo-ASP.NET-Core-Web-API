using System.ComponentModel.DataAnnotations;

namespace DemoASP.NET_CORE1.Dtos.Stock
{
    public class CreateStockRequestDTO
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 chars")]
        public string Symbol { get; set; } = string.Empty;// Mã giao dịch của cổ phiếu (ví dụ: AAPL, GOOGL)
        [Required]
        [MaxLength(20, ErrorMessage = "Company name cannot be over 20 chars")]
        public string CompanyName { get; set; } = string.Empty;


        [Required]
        [Range(1, 1000000000)]
        public decimal Purchase { get; set; }// Giá mua cổ phiếu (ví dụ: 150.50 USD/cổ phiếu)

        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Industry cannot be over 10 chars ")]
        public string Industry { get; set; } = string.Empty;

        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}
