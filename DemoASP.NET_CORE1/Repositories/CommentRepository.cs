using DemoASP.NET_CORE1.Data;
using DemoASP.NET_CORE1.Interfaces;
using DemoASP.NET_CORE1.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoASP.NET_CORE1.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _context;
        public CommentRepository(ApplicationDBContext context)
        {
            _context  = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var commenModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if (commenModel == null)
            {
                return null;
            }
            _context.Comments.Remove(commenModel);  
            await _context.SaveChangesAsync();
            return commenModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if (existingComment == null)
            {
                return null;
            }
            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;
            await _context.SaveChangesAsync();
            return existingComment;
        }
    }
}
