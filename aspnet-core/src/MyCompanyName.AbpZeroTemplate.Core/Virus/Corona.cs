using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using Abp.Auditing;

namespace MyCompanyName.AbpZeroTemplate.Virus
{
	[Table("Coronas")]
    [Audited]
    public class Corona : FullAuditedEntity 
    {

		[Required]
		[StringLength(CoronaConsts.MaxNameLength, MinimumLength = CoronaConsts.MinNameLength)]
		public virtual string Name { get; set; }
		
		[StringLength(CoronaConsts.MaxSymptomLength, MinimumLength = CoronaConsts.MinSymptomLength)]
		public virtual string Symptom { get; set; }
		

    }
}