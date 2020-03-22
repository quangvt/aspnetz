

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using MyCompanyName.AbpZeroTemplate.Virus.Exporting;
using MyCompanyName.AbpZeroTemplate.Virus.Dtos;
using MyCompanyName.AbpZeroTemplate.Dto;
using Abp.Application.Services.Dto;
using MyCompanyName.AbpZeroTemplate.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MyCompanyName.AbpZeroTemplate.Virus
{
	[AbpAuthorize(AppPermissions.Pages_Coronas)]
    public class CoronasAppService : AbpZeroTemplateAppServiceBase, ICoronasAppService
    {
		 private readonly IRepository<Corona> _coronaRepository;
		 private readonly ICoronasExcelExporter _coronasExcelExporter;
		 

		  public CoronasAppService(IRepository<Corona> coronaRepository, ICoronasExcelExporter coronasExcelExporter ) 
		  {
			_coronaRepository = coronaRepository;
			_coronasExcelExporter = coronasExcelExporter;
			
		  }

		 public async Task<PagedResultDto<GetCoronaForViewDto>> GetAll(GetAllCoronasInput input)
         {
			
			var filteredCoronas = _coronaRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Symptom.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.SymptomFilter),  e => e.Symptom == input.SymptomFilter);

			var pagedAndFilteredCoronas = filteredCoronas
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

			var coronas = from o in pagedAndFilteredCoronas
                         select new GetCoronaForViewDto() {
							Corona = new CoronaDto
							{
                                Name = o.Name,
                                Symptom = o.Symptom,
                                Id = o.Id
							}
						};

            var totalCount = await filteredCoronas.CountAsync();

            return new PagedResultDto<GetCoronaForViewDto>(
                totalCount,
                await coronas.ToListAsync()
            );
         }
		 
		 public async Task<GetCoronaForViewDto> GetCoronaForView(int id)
         {
            var corona = await _coronaRepository.GetAsync(id);

            var output = new GetCoronaForViewDto { Corona = ObjectMapper.Map<CoronaDto>(corona) };
			
            return output;
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Coronas_Edit)]
		 public async Task<GetCoronaForEditOutput> GetCoronaForEdit(EntityDto input)
         {
            var corona = await _coronaRepository.FirstOrDefaultAsync(input.Id);
           
		    var output = new GetCoronaForEditOutput {Corona = ObjectMapper.Map<CreateOrEditCoronaDto>(corona)};
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditCoronaDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Coronas_Create)]
		 protected virtual async Task Create(CreateOrEditCoronaDto input)
         {
            var corona = ObjectMapper.Map<Corona>(input);

			

            await _coronaRepository.InsertAsync(corona);
         }

		 [AbpAuthorize(AppPermissions.Pages_Coronas_Edit)]
		 protected virtual async Task Update(CreateOrEditCoronaDto input)
         {
            var corona = await _coronaRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, corona);
         }

		 [AbpAuthorize(AppPermissions.Pages_Coronas_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _coronaRepository.DeleteAsync(input.Id);
         } 

		public async Task<FileDto> GetCoronasToExcel(GetAllCoronasForExcelInput input)
         {
			
			var filteredCoronas = _coronaRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Symptom.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name == input.NameFilter)
						.WhereIf(!string.IsNullOrWhiteSpace(input.SymptomFilter),  e => e.Symptom == input.SymptomFilter);

			var query = (from o in filteredCoronas
                         select new GetCoronaForViewDto() { 
							Corona = new CoronaDto
							{
                                Name = o.Name,
                                Symptom = o.Symptom,
                                Id = o.Id
							}
						 });


            var coronaListDtos = await query.ToListAsync();

            return _coronasExcelExporter.ExportToFile(coronaListDtos);
         }


    }
}