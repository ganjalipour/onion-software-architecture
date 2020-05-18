using Consulting.Common.Model;
using Consulting.Domains.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Service
{
    public class ConsultService
    {
        private IConsultRepository consultRepository;
        public ConsultService(IConsultRepository _consultRepository)
        {
            consultRepository = _consultRepository;
        }

        public async Task<ResultList> GetConsultantsAsync(ConsultantFilter consultantFilter)
        {
            var consultants = await consultRepository.GetConsultantsAsync(consultantFilter);
            return consultants;
        }

        public async Task<ResultObject> GetConsultantByIDAsync(int id)
        {
            return await consultRepository.GetConsultantByIDAsync(id);
        }
    }
}
