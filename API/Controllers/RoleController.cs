using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consulting.Applications.AppService.AuthAppService;
using Consulting.Applications.AppService.RoleManagement;
using Consulting.Applications.AppService.ServiceDto;
using Consulting.Common.Constants;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.SecurityDto;
using Consulting.Common.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        readonly RoleAppService roleAppService;

        public RoleController(RoleAppService _roleAppService)
        {
            this.roleAppService = _roleAppService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ResultObject> GetAsync(int id)
        {
            var roledto = await roleAppService.GetRoleByID(id);
            return new ResultObject { Result = roledto, ServerErrors = null };
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ResultListDto> GetRolesAsync()
        {
            IEnumerable<RoleDto> roleListdto = await roleAppService.GetRolesAsync();
            var resultList = new ResultListDto { Results = roleListdto, TotalRows = 100, MaxPageRows = 20 };
            return resultList;
        }
        [HttpPost]
        [Route("set")]
        public async Task<ResultObject> SetAsync([FromBody] RoleDto roleDto)
        {
            ResultObject resultobject;

            if (roleDto.ID == 0)
            {
                roleDto = await roleAppService.CreateRoleAsync(roleDto);

            }
            else
            {
                roleDto = await roleAppService.UpdateRoleAsync(roleDto);
            }
            resultobject = new ResultObject { Result = roleDto, ServerErrors = null };

            return resultobject;
        }

        [HttpPost]
        [Route("delete/{id}")]
        public async Task<ResultObject> DeleteAsync(int id)
        {
            try
            {
                await roleAppService.DeleteRoleAsync(new RoleDto { ID = id });
                return new ResultObject { Result = true, ServerErrors = null };
            }
            catch (Exception ex)
            {

                return new ResultObject { Result = false, ServerErrors = new[] { new ServerErr() { Hint = ex.Message, Type = "Err on Delete" } } };
            }
        }

    }
}