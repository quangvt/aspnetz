using System.ComponentModel.DataAnnotations;
using MyCompanyName.AbpZeroTemplate.Constants;

namespace MyCompanyName.AbpZeroTemplate.Learning.Dto
{
    public class CreateStudentInput
    {
        [Required]
        [MaxLength(StudentConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(StudentConsts.MaxSurnameLength)]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(StudentConsts.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}
