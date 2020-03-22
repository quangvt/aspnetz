using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Virus.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.Virus
{
    public interface ICoronasAppService : IApplicationService 
    {
        Task<PagedResultDto<GetCoronaForViewDto>> GetAll(GetAllCoronasInput input);

        Task<GetCoronaForViewDto> GetCoronaForView(int id);

		Task<GetCoronaForEditOutput> GetCoronaForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditCoronaDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetCoronasToExcel(GetAllCoronasForExcelInput input);

		
    }
}