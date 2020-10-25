using System.ComponentModel.DataAnnotations;

namespace geo_auth_data.models.dto
{
    public class LogoutRequest
    {
        [Required]
        [Range(1, long.MaxValue)]
        public long OwnerId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

    }
}
