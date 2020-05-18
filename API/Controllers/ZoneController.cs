using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consulting.Applications.AppService.RoleManagement;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.CustomerDto;
using Consulting.Common.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ZoneController : Controller
    {
        ZoneAppService _zoneAppService;

        public ZoneController(ZoneAppService zoneAppService)
        {
            _zoneAppService = zoneAppService;
        }

        [HttpGet]
        [Route("GetAsync/{id}")]
        public async Task<ResultObject> GetAsync(int id)
        {
            var zonedto = await _zoneAppService.GetZoneByID(id);
            return new ResultObject { Result = zonedto, ServerErrors = null };
        }

        [Route("GetProvinces")]
        public async Task<ResultListDto> GetProvincesAsync()
        {
            IEnumerable<KeyValueDto> zoneListdto = await _zoneAppService.GetProvince();
            var resultlistdto = new ResultListDto { Results = zoneListdto };
            return resultlistdto;
        }

        [Route("GetAllCity")]
        public async Task<ResultListDto> GetAllCityAsync()
        {
            IEnumerable<ZoneDto> zoneListdto = await _zoneAppService.GetAllCity();
            var resultlistdto = new ResultListDto { Results = zoneListdto };
            return resultlistdto;
        }

        [Route("GetCities/{provinceId}")]
        public async Task<ResultListDto> GetCitiesAsync(int provinceId)
        {          
            IEnumerable<KeyValueDto> zoneListdto = await _zoneAppService.GetCities(provinceId);
            var resultlistdto = new ResultListDto { Results = zoneListdto};
            return resultlistdto;
        }

        [Route("GetVillages/{cityId}")]
        public async Task<ResultListDto> GetVillageAsync(int cityId)
        {
            IEnumerable<KeyValueDto> zoneListdto = await _zoneAppService.GetVillages(cityId);
            var resultlistdto = new ResultListDto { Results = zoneListdto };
            return resultlistdto;
        }

        [Route("getZoneInfoByZoneID/{zoneID}")]
        public async Task<ResultObject> GetZoneInfoByZoneIDAsync(int zoneID)
        {
            var result = await _zoneAppService.GetZoneInfoByZoneIDAsync(zoneID);
            ResultObject resultObject = new ResultObject()
            {
                Result = result
            };
            return resultObject;
        }

        [HttpPost("SetAsync")]
        public async Task<ResultObject> SetAsync([FromBody] ZoneDto zoneDto)
        {
            ResultObject resultobject;
            if (zoneDto.ID == 0)
            {
                zoneDto = await _zoneAppService.CreateZoneAsync(zoneDto);

            }
            else
            {
                zoneDto = await _zoneAppService.UpdateZoneAsync(zoneDto);
            }
            resultobject = new ResultObject { Result = zoneDto, ServerErrors = null };

            return resultobject;
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<ResultObject> DeleteAsync(int id)
        {
            try
            {
                await _zoneAppService.DeleteZoneAsync(new ZoneDto { ID = id });
                return new ResultObject { Result = true, ServerErrors = null };
            }
            catch (Exception ex)
            {

                return new ResultObject { Result = false, ServerErrors = new[] { new ServerErr() { Hint = ex.Message, Type = "Err on Delete" } } };
            }
        }

    }
}