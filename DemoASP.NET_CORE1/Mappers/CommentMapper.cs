using DemoASP.NET_CORE1.Dtos.Comment;
using DemoASP.NET_CORE1.Models;

namespace DemoASP.NET_CORE1.Mappers
{
    public static class CommentMapper
    {

        public static CommentDTO ToCommentDTO(this Comment commentModel)
        {
            return new CommentDTO
            {
                Id = commentModel.Id,
                Content = commentModel.Content,
                Title = commentModel.Title,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId,
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDTO commentDTO, int stockId)
        {
            return new Comment
            {
                Content = commentDTO.Content,
                Title = commentDTO.Title,
                StockId = stockId,
            };
        }
        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDTO commentDTO)
        {
            return new Comment
            {
                Content = commentDTO.Content,
                Title = commentDTO.Title
            };
        }

    }
}
