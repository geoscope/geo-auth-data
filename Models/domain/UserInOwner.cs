using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geo_auth_data.models.domain
{
    [Table("UsersInOwners")]
    public class UserInOwner
    {
        [Key]
        public long Id { get; set; }
        public long OwnerId { get; set; }
        public Owner Owner { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}