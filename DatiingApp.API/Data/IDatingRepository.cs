using System.Collections.Generic;
using System.Threading.Tasks;
using DatiingApp.API.Helpers;
using DatiingApp.API.Models;

namespace DatiingApp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T: class;

        void Delete<T>(T entity) where T: class;

        Task<bool> SaveAll();

        Task<User> GetUser(int id);

        Task<PagedList<User>> GetUsers(UserParams userParams);

        Task<Photo> GetPhoto(int id);

        Task<Photo> GetMainPhoto(int userId);

        Task<Like> GetLike(int userId, int recipientId);
    }
}