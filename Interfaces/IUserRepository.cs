using System.Collections.Generic;
using System.Threading.Tasks;
using geo_auth_data.models.domain;

namespace geo_auth_data.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetByUserNameAsync(long ownerId, string username);

        Task<User> AuthenticateUserAsync(long ownerId, string username, string password);

        Task<IEnumerable<User>> GetAllAsync(long ownerId);
    }
}
