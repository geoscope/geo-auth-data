using System;
using System.ComponentModel.DataAnnotations;

namespace geo_auth_data.models.domain
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        [Range(1, long.MaxValue)]
        public long CreatedBy { get; set; }
        [Required]
        public DateTime Updated { get; set; }
        [Required]
        [Range(1, long.MaxValue)]
        public long UpdatedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsEnabled { get; set; } = true;
        public bool IsVisible { get; set; } = true;
    }
}