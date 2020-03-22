using System.Collections.Generic;
using MyCompanyName.AbpZeroTemplate.Virus.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;

namespace MyCompanyName.AbpZeroTemplate.Virus.Exporting
{
    public interface ICoronasExcelExporter
    {
        FileDto ExportToFile(List<GetCoronaForViewDto> coronas);
    }
}