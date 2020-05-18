using System;
using System.Threading.Tasks;
using Consulting.Applications.AppService.AuthAppService;
using Consulting.Applications.AppService.RoleManagement;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Common.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class ConsultController : Controller
    {
        ConsultAppService consultAppService;

        public ConsultController(ConsultAppService _consultAppService)
        {
            consultAppService = _consultAppService;
        }

        [HttpPost]
        [Route("getConsultants")]
        public async Task<ResultListDto> GetConsultantsAsync([FromBody] ConsultantFilterDto consultantFilterDto = null)
        {
            ResultListDto consultantList = await consultAppService.GetConsultantsAsync(consultantFilterDto);
            return consultantList;
        }


        [Route("getConsultantById/{id}")]
        public async Task<ResultObject> GetConsultantsAsync(int id)
        {
            ResultObject ConsultantObj = await consultAppService.GetConsultantByIDAsync(id);
            return ConsultantObj;
        }

    }
}