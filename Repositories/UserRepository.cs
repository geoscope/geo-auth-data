﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using geo_auth_shared.Models;
using geo_auth_data.Interfaces;
using geo_auth_data.models.domain;
using geo_auth_shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;

namespace geo_auth_data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;
        private readonly AppSettings appSettings;
        private readonly ISecurityHelper securityHelper;

        public UserRepository(IConfiguration configuration, IOptions<AppSettings> appSettings, ISecurityHelper securityHelper)
        {
            if (appSettings == null)
                throw new ArgumentNullException(nameof(appSettings));

            connectionString = configuration.GetConnectionString("AuthDatabase");
            this.appSettings = appSettings.Value;
            this.securityHelper = securityHelper;
        }

        public Task<long> AddAsync(User record)
        {
            throw new NotImplementedException();
        }

        public async Task<User> AuthenticateUserAsync(long ownerId, string username, string password)
        {
            // Get the user record - for the salt
            var user = await GetByUserNameAsync(ownerId, username).ConfigureAwait(false);

            if (user != null)
            {
                var hashedPassword = securityHelper.HashPassword(password, appSettings.SystemPasswordSalt, user.PasswordSalt);

                var sql = "SELECT * FROM \"Users\" u WHERE u.\"UserName\"=@username AND u.\"Password\"=@hashedPassword AND u.\"OwnerId\"=@ownerId AND u.\"IsDeleted\"=false AND u.\"IsEnabled\"=true;";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    var authenticatedUser = await conn.QueryAsync<User>(sql, new { username, hashedPassword, ownerId }).ConfigureAwait(false);

                    return authenticatedUser.FirstOrDefault();
                }
            }

            return null;
        }

        public Task<bool> DeleteAsync(User record)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync(long ownerId)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetByUserNameAsync(long ownerId, string username)
        {
            var sql = "SELECT * FROM \"Users\" u WHERE u.\"UserName\"=@username AND u.\"IsDeleted\"=false AND u.\"IsEnabled\"=true;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var user = await conn.QueryAsync<User>(sql, new { username }).ConfigureAwait(false);

                return user.FirstOrDefault();
            }
        }

        public async Task<User> GetSingleAsync(long id)
        {
            var sql = "SELECT * FROM \"Users\" u WHERE u.\"Id\"=@id AND u.\"IsDeleted\"=false AND u.\"IsEnabled\"=true;";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                var user = await conn.QueryAsync<User>(sql, new { id }).ConfigureAwait(false);

                return user.First();
            }
        }

        public Task<bool> UpdateAsync(User record)
        {
            throw new NotImplementedException();
        }
    }
}
