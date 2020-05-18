using AutoMapper;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Applications.AppService.RoleManagement
{
    public class ConsultAppService
    {
        public ConsultService consultService;
        private readonly IMapper _mapper;
        private ITransactionManager _transactionManager;
        public ConsultAppService(ConsultService _consultService, ITransactionManager transactionManager, IMapper mapper)
        {
            consultService = _consultService;
            _mapper = mapper;
            _transactionManager = transactionManager;

        }

        public async Task<ResultListDto> GetConsultantsAsync(ConsultantFilterDto consultantFilterDto)
        {

           var consultantFilter = _mapper.Map<ConsultantFilter>(consultantFilterDto);
            var consultList = await consultService.GetConsultantsAsync(consultantFilter);

            var consults = _mapper.Map<IEnumerable<ConsultantDto>>(consultList.entities);

            ResultListDto finalResult = new ResultListDto()
            {
                MaxPageRows = consultList.MaxPageRows,
                TotalRows = 10,
                //TotalRows = consultList.TotalRows,
                Results = consults
            };
            return finalResult;
        }

        public async Task<ResultObject> GetConsultantByIDAsync(int id)
        {
            var res = new ResultObject();
            var consultant = await consultService.GetConsultantByIDAsync(id);
            var consoltantDto = _mapper.Map<ConsultantDto>(consultant.Result);

            res.Result = consoltantDto;
            return res;
        }
    }
}
