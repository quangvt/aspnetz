using System.ComponentModel.DataAnnotations;
using MyCompanyName.AbpZeroTemplate.Constants;

namespace MyCompanyName.AbpZeroTemplate.PhoneBook.Dto
{
    public class CreatePersonInput
    {
        [Required]
        [MaxLength(PersonConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(PersonConsts.MaxSurnameLength)]
        public string Surname { get; set; }

        [EmailAddress]
        [MaxLength(PersonConsts.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }
    }
}
