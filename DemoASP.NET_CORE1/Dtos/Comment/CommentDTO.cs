namespace DemoASP.NET_CORE1.Dtos.Comment
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int StockId { get; set; }
    }
}
