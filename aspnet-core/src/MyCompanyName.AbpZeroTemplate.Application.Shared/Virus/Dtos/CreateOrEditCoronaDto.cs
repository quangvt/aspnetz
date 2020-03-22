
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace MyCompanyName.AbpZeroTemplate.Virus.Dtos
{
    public class CreateOrEditCoronaDto : EntityDto<int?>
    {

		[Required]
		[StringLength(CoronaConsts.MaxNameLength, MinimumLength = CoronaConsts.MinNameLength)]
		public string Name { get; set; }
		
		
		[StringLength(CoronaConsts.MaxSymptomLength, MinimumLength = CoronaConsts.MinSymptomLength)]
		public string Symptom { get; set; }
		
		

    }
}