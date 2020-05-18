using AutoMapper;
using Consulting.Common.Data;
using Consulting.Domains.Core.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consulting.Domains.Core.Entities;
using Consulting.Applications.AppService.ServiceDto.CustomerDto;
using Consulting.Applications.AppService.ServiceDto.BasicDto;

namespace Consulting.Applications.AppService.RoleManagement
{
    
    public  class ZoneAppService
    {
        public ZoneService _zoneService;
        private readonly IMapper _mapper;
        private ITransactionManager _transactionManager;
        public ZoneAppService(ZoneService zoneService, ITransactionManager transactionManager, IMapper mapper)
        {
            _zoneService = zoneService;
            _mapper = mapper;
            _transactionManager = transactionManager;
        }        
        public async Task<ZoneDto> CreateZoneAsync(ZoneDto ZoneDto)
        {
            var Zone = _mapper.Map<Zone>(ZoneDto);

            await _zoneService.CreateZoneAsync(Zone);
            await _transactionManager.SaveAllAsync();
            return _mapper.Map<ZoneDto>(Zone);
        }

        public async Task<ZoneDto> UpdateZoneAsync(ZoneDto ZoneDto)
        {
            var Zone = _mapper.Map<Zone>(ZoneDto);
            await _zoneService.UpdateZoneAsync(Zone);
            await _transactionManager.SaveAllAsync();
            return _mapper.Map<ZoneDto>(Zone);
        }

        public async Task<IEnumerable<ZoneDto>> GetZonesByParentID(int? zoneParentId)
        {
           // var zoneList = await _zoneService.GetZonesByParentID(zoneParentId);
           // var ZoneDtoList = _mapper.Map<IEnumerable<ZoneDto>>(zoneList);
            await _transactionManager.SaveAllAsync();
            return null;
        }

        public async Task<IEnumerable<KeyValueDto>> GetZones()
        {
            var zoneList = await _zoneService.GetZones();
            var ZoneDtoList = _mapper.Map<IEnumerable<KeyValueDto>>(zoneList);
            await _transactionManager.SaveAllAsync();
            return ZoneDtoList;
        }

        public async Task<IEnumerable<KeyValueDto>> GetProvince()
        {
            var provinceList = await _zoneService.GetProvince();
            var provinceDtoList = _mapper.Map<IEnumerable<KeyValueDto>>(provinceList);
            await _transactionManager.SaveAllAsync();
            return provinceDtoList;
        }

        public async Task<IEnumerable<ZoneDto>> GetAllCity()
        {
            var cityList = await _zoneService.GetAllCities()  ;
            var CityDtoList = _mapper.Map<IEnumerable<ZoneDto>>(cityList);
            return CityDtoList;
        }

        public async Task<IEnumerable<KeyValueDto>> GetCities(int provinceID)
        {
            var cityList = await _zoneService.GetCities(provinceID);
            var CityDtoList = _mapper.Map<IEnumerable<KeyValueDto>>(cityList);
            return CityDtoList;
        }

        public async Task<IEnumerable<KeyValueDto>> GetVillages(int cityId)
        {
            var villageList = await _zoneService.GetVillages(cityId);
            var villageDtoList = _mapper.Map<IEnumerable<KeyValueDto>>(villageList);
            await _transactionManager.SaveAllAsync();
            return villageDtoList;
        }


        public async Task<ZoneDto> GetZoneByID(int ID)
        {
            var Zone = await _zoneService.GetZoneAsync(ID);
            return _mapper.Map<ZoneDto>(Zone);

        }
        public async Task DeleteZoneAsync(ZoneDto ZoneDto)
        {
            var Zone = _mapper.Map<Zone>(ZoneDto);
            await _zoneService.RemoveZoneAsync(Zone);
            await _transactionManager.SaveAllAsync();

        }

        public async Task<ZoneDto> GetZoneInfoByZoneIDAsync(int zoneID)
        {
            var zone = await _zoneService.GetZoneInfoByZoneIDAsync(zoneID);
            int ProvinceID = await _zoneService.GetProvinceByCode(zone.OSTAN);
            int CityID = await _zoneService.GetCityByCode(zone.OSTAN, zone.SHAHRESTAN);
            var zoneDto = _mapper.Map<ZoneDto>(zone);
            zoneDto.CityID = CityID;
            zoneDto.ProvinceID = ProvinceID;
            return zoneDto;
        }
    }
}
