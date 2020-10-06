using System.Collections.Generic;
using System.Threading.Tasks;
using DatiingApp.API.Models;

namespace DatiingApp.API.Data
{
    public interface IDatingRepository
    {
        void Add<T>(T entity) where T: class;

        void Delete<T>(T entity) where T: class;

        Task<bool> SaveAll();

        Task<User> GetUser(int id);

        Task<IEnumerable<User>> GetUsers();

        Task<Photo> GetPhoto(int id);

        Task<Photo> GetMainPhoto(int userId);
    }
}