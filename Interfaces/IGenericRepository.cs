﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace geo_auth_data.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<T> GetSingleAsync(long id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<long> AddAsync(T record);

        Task<bool> UpdateAsync(T record);

        Task<bool> DeleteAsync(T record);
    }
}
