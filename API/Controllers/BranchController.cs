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
    public class BranchController : Controller
    {
        BranchAppService branchAppService;

        public BranchController(BranchAppService _branchAppService)
        {
            branchAppService = _branchAppService;
        }

        [HttpPost("GetBranches")]
        public async Task<ResultListDto> GetBranchesAsync([FromBody] BranchFilterDto branchFilterDto = null)
        {
            ResultListDto branchListdto = await branchAppService.GetBranchesAsync(branchFilterDto);
            return branchListdto;
        }

        [HttpPost("getBranchesBaseOnRoleAsync")]
        public async Task<ResultListDto> GetBranchesBaseOnRoleAsync([FromBody] BranchFilterDto branchFilterDto)
        {
            ResultListDto branchListdto = await branchAppService.GetBranchesBaseOnRoleAsync(branchFilterDto);
            return branchListdto;
        }


        [HttpPost("GetBranchList")]
        public async Task<ResultListDto> GetBranchListAsync([FromBody] BranchFilterDto branchFilterDto = null)
        {
            ResultListDto branchListdto = await branchAppService.GetBranchListAsync(branchFilterDto);
            return branchListdto;
        }

        [Route("GetBrancheByCodeAsync/{branchCode}")]

        public async Task<ResultObject> GetBrancheByCodeAsync(string branchCode)
        {
            var branchDto = await branchAppService.GetBranchByBranchCodeAsync(branchCode);
            var resultobject = new ResultObject { Result = branchDto, ServerErrors = null };
            return resultobject;
        }

        [Route("GetAsync/{id}")]
        public async Task<ResultObject> GetAsync(int id)
        {
            var branchDto = await branchAppService.GetBranchAsync(id);
            var resultobject = new ResultObject { Result = branchDto, ServerErrors = null };
            return resultobject;
        }

        [HttpPost("CreateBranchFromExcel")]
        public async Task<ResultObject> CreateBranchFromExcelAsync([FromBody] BranchDto branchDto)
        {
            if (branchDto.ID == 0)
            {
                return await branchAppService.CreateBranchFromExcelAsync(@"", branchDto);
            }
            return new ResultObject { Result = branchDto, ServerErrors = null };
        }

        [HttpPost("SetAsync")]
        public async Task<ResultObject> SetAsync([FromBody] BranchDto branchDto)
        {
            ResultObject resultobject;
            if (branchDto.ID == 0)
            {
               return await branchAppService.CreateBranchAsync(branchDto);
            }
            else
            {
                await branchAppService.UpdateBranchAsync(branchDto);
            }
            resultobject = new ResultObject { Result = branchDto, ServerErrors = null };

            return resultobject;
        }

        [HttpPost("CreateAsync")]
        [Route("create")]
        public async Task CreateAsync(BranchDto branchDto)
        {
            await branchAppService.CreateBranchAsync(branchDto);
        }

        [HttpPost("UpdateAsync")]
        [Route("update")]
        public async Task<ResultObject> UpdateAsync(BranchDto branchDto)
        {
            var branch = await branchAppService.UpdateBranchAsync(branchDto);
            var resultobject = new ResultObject { Result = branch, ServerErrors = null };
            return resultobject;
        }

        [HttpPost("DeleteAsync")]
        [Route("delete/{id}")]
        public async Task<ResultObject> DeleteAsync(int id)
        {                   
             return await branchAppService.DeleteBranchAsync(id);                       
        }

    }
}