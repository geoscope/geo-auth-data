using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geo_auth_data.models.domain
{
    [Table("UsersInRoles")]
    public class UserInRole
    {
        [Key]
        public long Id { get; set; }
        public long RoleId { get; set; }
        public Role Role { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}