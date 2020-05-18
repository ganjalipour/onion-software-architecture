using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Service
{
   public class ZoneService
    {
        private readonly IZoneRepository _zoneRepository;
        public ZoneService(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        public async Task CreateZoneAsync(Zone Zone)
        {
            await _zoneRepository.AddAsync(Zone);
        }   

        public async Task<Zone> GetZoneAsync(int id)
        {
            return await _zoneRepository.FindByFirstOrDefaultAsync(item => item.ID == id);
        }

        public async Task<IEnumerable<Zone>> GetZones()
        {
            return await _zoneRepository.GetByPredicateAsync();
        }


        public async Task<IEnumerable<Zone>> GetProvince()
        {
            return await _zoneRepository.GetProvince();
        }


        public async Task<IEnumerable<Zone>> GetCities(int provinceId)
        {
            return await _zoneRepository.GetCities(provinceId);
        }


        public async Task<IEnumerable<Zone>> GetAllCities()
        {
            return await _zoneRepository.GetAllCity();
        }

        public async Task<IEnumerable<Zone>> GetVillages(int cityId)
        {
            return await _zoneRepository.GetVillages(cityId);                 ;
        }

        public async Task<Zone> UpdateZoneAsync(Zone Zone)
        {
            return await _zoneRepository.UpdateAsync(Zone, Zone.ID);
        }

        public async Task RemoveZoneAsync(Zone Zone)
        {
            await _zoneRepository.RemoveAsync(Zone.ID);
        }

        public async Task<List<Branch>> GetProvinceBranchesByProvinceCode(string ostanCode)
        {
           return await _zoneRepository.GetProvinceBranchesByProvinceCode(ostanCode);
        }

        public async Task<Zone> GetZoneInfoByZoneIDAsync(int zoneID)
        {
            return await _zoneRepository.GetZoneInfoByZoneIDAsync(zoneID);
        }

        public async Task<int> GetProvinceByCode(string oSTAN)
        {
            return await _zoneRepository.GetProvinceByCode(oSTAN);
        }

        public async Task<int> GetCityByCode(string oSTAN, string sHAHRESTAN)
        {
            return await _zoneRepository.GetCityByCode(oSTAN, sHAHRESTAN);
        }

        public async Task<Zone> GetZoneByBranchIDAsync(int branchID)
        {
            return await _zoneRepository.GetZoneByBranchIDAsync(branchID);
        }
    }
}
