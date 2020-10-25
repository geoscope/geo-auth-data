using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geo_auth_data.models.domain
{
    [Table("Owners")]
    public class Owner : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        public long ExternalId { get; set; }

        public List<UserInOwner> UserInOwners { get; set; }
    }
}