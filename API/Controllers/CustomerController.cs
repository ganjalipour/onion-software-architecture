using System;
using System.Threading.Tasks;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.CustomerDto;
using Consulting.Applications.Customer;
using Consulting.Common.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class CustomerController : Controller
    {
        CustomerAppService customerAppService;
        public CustomerController(CustomerAppService _customerAppService )
        {
            customerAppService = _customerAppService;
        }

        #region CustomerServices

        [Route("getCustomerById/{customerId}")]
        public async Task<ResultObject> GetCustomerByCustomerIdAsync(int customerId)
        {
            var result = await customerAppService.GetCustomerByCustomerIdAsync(customerId);
            ResultObject resultObject = new ResultObject()
            {
                Result = result
            };
            return resultObject;
        }

        [Route("getCustomers/{customerNumber}")]
        public async Task<ResultObject> GetCustomersByCustomerNumberAsync(int customerNumber)
        {
            var result = await customerAppService.GetCustomerAsync(customerNumber);
            ResultObject resultObject = new ResultObject()
            {
                Result = result
            };
            return resultObject;
        }

        [Route("getCustomersByUserID/{userID}")]
        public async Task<ResultObject> GetCustomersByUserIDAsync(int userID)
        {
            var result = await customerAppService.GetCustomerByUserIDAsync(userID);
            ResultObject resultObject = new ResultObject()
            {
                Result = result
            };
            return resultObject;
        }

        [Route("getCustomers")]
        [System.Web.Http.Authorize]
        public async Task<ResultListDto> GetCustomersAsync()
        {
            ResultListDto customerListDto = await customerAppService.GetCustomersAsync();
            return customerListDto;
        }

        [HttpPost("GetCustomersByFilter")]
        [System.Web.Http.Authorize]
        public async Task<ResultListDto> GetCustomersByFilter([FromBody] CustomerFilterDto customerFilterDto = null)
        {
            ResultListDto branchListdto = await customerAppService.GetCustomersByFilterAsync(customerFilterDto);
            return branchListdto;
        }

        [HttpPost("GetAllBranchCustomerHeads")]
        public async Task<ResultListDto> GetAllBranchCustomerHeadsAsync(CustomerFilterDto customerFilterDto)
        {
            ResultListDto branchListdto = await customerAppService.GetAllBranchCustomerHeadsAsync(customerFilterDto);
            return branchListdto;
        }

        [Route("getMilitaryServiceStatus")]
        public async Task<ResultListDto> GetMilitaryServiceStatus()
        {
            var glItemtypelist = await customerAppService.GetMilitaryServiceStatus();
            var resultlistdto = new ResultListDto { Results = glItemtypelist };
            return resultlistdto;
        }

        [Route("getNationalities")]
        public async Task<ResultListDto> GetNationalities()
        {
            var glItemtypelist = await customerAppService.GetNationalities();
            var resultlistdto = new ResultListDto { Results = glItemtypelist };
            return resultlistdto;
        }

        [Route("getEducationLevels")]
        public async Task<ResultListDto> GetEducationLevels()
        {
            var glItemtypelist = await customerAppService.GetEducationLevels();
            var resultlistdto = new ResultListDto { Results = glItemtypelist };
            return resultlistdto;
        }

        [Route("getSkills")]
        public async Task<ResultListDto> GetSkills()
        {
            var skillList = await customerAppService.GetSkills();
            var resultlistdto = new ResultListDto { Results = skillList };
            return resultlistdto;
        }

        [HttpPost("SetAsync")]
        public async Task<ResultObject> SetAsync([FromBody] CustomerHeadDto customerDto)
        {
            if (customerDto.ID == 0)
            {
                return await customerAppService.CreateCustomerAsync(customerDto);
            }
            else
            {
                return await customerAppService.UpdateCustomerAsync(customerDto);
            }

        }

        [HttpPost("DeleteAsync")]
        [Route("delete/{id}")]
        public async Task<ResultObject> DeleteAsync(int id)
        {
            try
            {
                await customerAppService.DeleteCustomerAsync(id);
                return new ResultObject { Result = true, ServerErrors = null };
            }
            catch (Exception ex)
            {
                return new ResultObject { Result = false, ServerErrors = new[] { new ServerErr() { Hint = ex.Message, Type = "Err on Delete" } } };
            }
        }

        #endregion #region CustomerServices
    }



}