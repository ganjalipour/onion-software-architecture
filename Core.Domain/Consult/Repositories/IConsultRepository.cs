using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Consult.Entities;
using Consulting.Domains.Core.Service;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
    public interface IConsultRepository : IRepository<Consultant>
    {
        Task<ResultList> GetConsultantsAsync(ConsultantFilter consultantFilter);
        Task<ResultObject> GetConsultantByIDAsync(int id);
    } 
}
