using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using geo_auth_data.Interfaces;
using geo_auth_data.models.domain;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace geo_auth_data.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly string connectionString;

        public UserRoleRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("AuthDatabase");
        }

        public Task<long> AddAsync(Role record)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteAsync(Role record)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetRolesByUserId(long userId)
        {
            var sql = @"SELECT * FROM ""Roles"" r 
                INNER JOIN ""UsersInRoles"" uir ON uir.""RoleId"" = r.""Id""  
                INNER JOIN ""Users"" u ON u.""Id"" = uir.""UserId"" 
                WHERE u.""Id""=@userId AND u.""IsDeleted""=false AND u.""IsEnabled""=true;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                return await conn.QueryAsync<Role>(sql, new { userId }).ConfigureAwait(false);
            }
        }

        public Task<Role> GetSingleAsync(long id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Role record)
        {
            throw new System.NotImplementedException();
        }
    }
}