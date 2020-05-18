using System;
using Consulting.Common.Data;
using System.Collections.Generic;
using System.Text;
using Consulting.Domains.Core.Entities;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Consulting.Domains.Core.Service;

namespace Consulting.Domains.Core.Repositories
{
   public interface IZoneRepository:IRepository<Zone>
    {

       Task<IEnumerable<Zone>> GetProvince();

        Task<IEnumerable<Zone>> GetAllCity();

        Task<IEnumerable<Zone>> GetCities(int provinceId);

       Task<IEnumerable<Zone>> GetVillages(int cityId);
        Task<Zone> GetZoneInfoByZoneIDAsync(int zoneID);
        Task<int> GetProvinceByCode(string oSTAN);
        Task<int> GetCityByCode(string oSTAN, string sHAHRESTAN);
        Task<Zone> GetZoneByBranchIDAsync(int branchID);
        Task<List<Branch>> GetProvinceBranchesByProvinceCode(string ostanCode);
    }
}
