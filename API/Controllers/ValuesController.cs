using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Consulting.Applications.AppService.RoleManagement;
using Microsoft.AspNetCore.Cors;
using Consulting.Applications.AppService.AuthAppService;
using Consulting.Common.Constants;
using Consulting.Common.Model;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class ValuesController : ControllerBase
    {
        RoleAppService roleAppService;
        public ValuesController(RoleAppService _roleAppService)
        {
            roleAppService = _roleAppService;
        }

        // GET api/values
        [ServiceFilter(typeof(ActionFilterMicroFund))]
        [MicroFundAuthorize(ConstActivities.userManagement)]
        //[Authorize]
        [HttpGet]
        public ResultObject Get()
        {
            var roleDto = roleAppService.GetRoleOfMine();
            var resultobject = new ResultObject { Result = roleDto, ServerErrors = null };
            return resultobject;
        }

        //[Authorize]
        [HttpGet("GetAsync")]
        public async Task<ResultObject> GetAsync(int id)
        {
            var roleDto = await roleAppService.GetRoleOfMineAsync(id);
            var resultobject = new ResultObject { Result = roleDto, ServerErrors = null };

            return resultobject;
        }


        // GET api/values/5
        [HttpGet("{id}")]
        //[ServiceFilter(typeof(ActionFilterMicroFund))]
        //[MicroFundAuthorize(ConstActivities.userManagement)]
        public ActionResult<Object> Get(int id)
        {
            var res = new ResultObject() { Result = new { id = 1, name = "mohsem" }, ServerErrors = null };
            return res;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
