using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Learning.Dto;
using Abp.Authorization;
using MyCompanyName.AbpZeroTemplate.Authorization;

namespace MyCompanyName.AbpZeroTemplate.Learning
{
    public class StudentAppService : AbpZeroTemplateAppServiceBase,
        IStudentAppService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentAppService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ListResultDto<StudentListDto> GetStudent(GetStudentInput input)
        {
            var students = _studentRepository
                .GetAll()
                .WhereIf(
                    !input.Filter.IsNullOrEmpty(),
                    p => p.Name.Contains(input.Filter) ||
                            p.Surname.Contains(input.Filter) ||
                            p.EmailAddress.Contains(input.Filter)
                )
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Surname)
                .ToList();

            return new ListResultDto<StudentListDto>(ObjectMapper.
                Map<List<StudentListDto>>(students));
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Learning_CreateStudent)]
        public async Task CreateStudent(CreateStudentInput input)
        {
            var student = ObjectMapper.Map<Student>(input);
            await _studentRepository.InsertAsync(student);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Learning_DeleteStudent)]
        public async Task DeleteStudent(EntityDto input)
        {
            await _studentRepository.DeleteAsync(input.Id);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Learning_EditStudent)]
        public async Task<GetStudentForEditOutput> GetStudentForEdit(GetStudentForEditInput input)
        {
            var student = await _studentRepository.GetAsync(input.Id);
            return ObjectMapper.Map<GetStudentForEditOutput>(student);
        }

        [AbpAuthorize(AppPermissions.Pages_Tenant_Learning_EditStudent)]
        public async Task EditStudent(EditStudentInput input)
        {
            var student = await _studentRepository.GetAsync(input.Id);
            student.Name = input.Name;
            student.Surname = input.Surname;
            student.EmailAddress = input.EmailAddress;
            await _studentRepository.UpdateAsync(student);
        }
    }
}
