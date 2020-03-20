using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.PhoneBook.Dto;

namespace MyCompanyName.AbpZeroTemplate.PhoneBook
{
    public interface IPersonAppService : IApplicationService
    {
        ListResultDto<PersonListDto> GetPeople(GetPeopleInput input);

        Task CreatePerson(CreatePersonInput input);

        Task DeletePerson(EntityDto input);

        Task DeletePhone(EntityDto<long> input);

        Task<PhoneInPersonListDto> AddPhone(AddPhoneInput input);

        Task<GetPersonForEditOutput> GetPersonForEdit(GetPersonForEditInput input);

        Task EditPerson(EditPersonInput input);
    }
}
