using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geo_auth_data.models.domain
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        [Required]
        [MaxLength(260)]
        public string Name { get; set; }

        public List<UserInRole> UserInRoles { get; set; }
    }
}