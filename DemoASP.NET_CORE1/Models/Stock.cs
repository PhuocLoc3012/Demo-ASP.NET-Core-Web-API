using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace DemoASP.NET_CORE1.Models
{
    //này là chuẩn lưu xuống db
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;// Mã giao dịch của cổ phiếu (ví dụ: AAPL, GOOGL)
        public string CompanyName { get; set; } = string.Empty;


        [Column(TypeName = "decimal(18, 2)")]
        public decimal Purchase { get; set; }// Giá mua cổ phiếu (ví dụ: 150.50 USD/cổ phiếu)


        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal LastDiv { get; set; }// Cổ tức cuối cùng (ví dụ: 2.50 USD/cổ phiếu)
        //giống tiền lời


        public string Industry { get; set; } = string.Empty;//cổ phiếu về gì
        public long MarketCap { get; set; } //giá trên thị trường

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
