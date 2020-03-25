using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Learning.Dto;

namespace MyCompanyName.AbpZeroTemplate.Learning
{
    public interface IStudentAppService : IApplicationService
    {
        ListResultDto<StudentListDto> GetStudent(GetStudentInput input);
        Task CreateStudent(CreateStudentInput input);
        Task DeleteStudent(EntityDto input);
        Task<GetStudentForEditOutput> GetStudentForEdit(GetStudentForEditInput input);
        Task EditStudent(EditStudentInput input);
    }
}
