using System.Collections.Generic;
using System.Threading.Tasks;
using geo_auth_data.models.domain;

namespace geo_auth_data.Interfaces
{
    public interface IUserRoleRepository : IGenericRepository<Role>
    {
        Task<IEnumerable<Role>> GetRolesByUserId(long userId);
    }
}
