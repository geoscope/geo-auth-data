using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace geo_auth_data.models.dto
{
    public class User
    {
        [JsonIgnore]
        public long Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        public bool IsVerified { get; set; } = false;

        public DateTime? LastLogin { get; set; }

        public bool IsLocked { get; set; } = false;

        public DateTime? LockExpiry { get; set; }
    }
}