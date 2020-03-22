using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.Virus.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
		public string Filter { get; set; }
    }
}