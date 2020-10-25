using geo_auth_data.Interfaces;

namespace geo_auth_data.Hydrators
{
    public class UserToUserDtoHydrator : IHydrator<geo_auth_data.models.domain.User, geo_auth_data.models.dto.User>
    {
        public models.dto.User Hydrate(models.domain.User record)
        {
            return new models.dto.User()
            {
                Id = record.Id,
                FirstName = record.FirstName,
                LastName = record.LastName,
                UserName = record.UserName,
                Email = record.Email,
                IsVerified = record.IsVerified,
                LastLogin = record.LastLogin,
                IsLocked = record.IsLocked,
                LockExpiry = record.LockExpiry
            };
        }
    }
}