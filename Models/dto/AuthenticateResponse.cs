using System;

namespace geo_auth_data.models.dto
{
    public class AuthenticateResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; } = false;
        public bool IsLocked { get; set; } = false;
        public DateTime? LastLogin { get; set; }
        public DateTime? LockExpiry { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.UserName;
            Email = user.Email;
            IsVerified = user.IsVerified;
            IsLocked = user.IsLocked;
            LockExpiry = user.LockExpiry;
            LastLogin = user.LastLogin;
            Token = token;
        }
    }
}
