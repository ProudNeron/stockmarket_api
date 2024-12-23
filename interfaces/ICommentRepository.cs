using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using simple_api.Dtos.Comment;
using simple_api.Models;

namespace simple_api.interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment?> UpdateAsync(int id, Comment commentModel);

    }
}