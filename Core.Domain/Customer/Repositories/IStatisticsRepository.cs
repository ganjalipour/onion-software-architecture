using Consulting.Common.Data;
using Consulting.Domains.Customer.Entities;
using Consulting.Domains.Customer.Service;
using System.Threading.Tasks;

namespace Consulting.Domains.Customer.Repositories
{
    public interface IStatisticsRepository : IRepository<GeneralStatisticsDAO>
    {
        Task<GeneralStatisticsDAO> GetGeneralStatisticsAsync(GeneralStatisticsFilter filter);
    }
}