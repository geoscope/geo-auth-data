using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace geo_auth_data.models.domain
{
    [Table("Users")]
    public class User : BaseEntity
    {
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

        [MaxLength(20)]
        public string MobilePhone { get; set; }

        [Required]
        [MaxLength(50)]
        public string PasswordSalt { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; }

        public Guid? UserUuid { get; set; }

        [MaxLength(25)]
        public string UserCode { get; set; }

        public bool IsVerified { get; set; } = false;

        public VerificationType VerificationType { get; set; } = 0;

        [MaxLength(50)]
        public string VerificationCodeSalt { get; set; }

        [MaxLength(10)]
        public string VerificationCode { get; set; }

        public DateTime? VerificationExpiry { get; set; }

        public DateTime? LastLogin { get; set; }

        public int FailedPasswordAttempts { get; set; }

        public bool IsLocked { get; set; } = false;

        public DateTime? LockExpiry { get; set; }

        public List<UserInRole> UserInRoles { get; set; }

        public long OwnerId { get; set; }

        public Owner Owner { get; set; }
    }
}