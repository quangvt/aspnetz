using Abp.Application.Services.Dto;

namespace MyCompanyName.AbpZeroTemplate.Learning.Dto
{
    public class StudentListDto : FullAuditedEntityDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }
    }
}
