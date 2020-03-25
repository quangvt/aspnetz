using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using MyCompanyName.AbpZeroTemplate.Constants;

namespace MyCompanyName.AbpZeroTemplate.Learning
{
    [Table("PbStudents")]
    public class Student : FullAuditedEntity, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }

        [Required]
        [MaxLength(StudentConsts.MaxNameLength)]
        public virtual string Name { get; set; }

        [Required]
        [MaxLength(StudentConsts.MaxSurnameLength)]
        public virtual string Surname { get; set; }

        [MaxLength(StudentConsts.MaxEmailAddressLength)]
        public virtual string EmailAddress { get; set; }
    }
}