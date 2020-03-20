using System.Collections.ObjectModel;
using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.PhoneBook.Dto
{
    public class PersonListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public Collection<PhoneInPersonListDto> Phones { get; set; }
    }
}
