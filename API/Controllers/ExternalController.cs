using System.Collections.Generic;
using System.Threading.Tasks;
using Consulting.Applications.AppService.ServiceDto.CustomerDto;
using Consulting.Common.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SabteAhval;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ExternalController : Controller
    {
        readonly InquiryPersonInfoSoapClient client;
        public ExternalController()
        {

            client = new InquiryPersonInfoSoapClient(InquiryPersonInfoSoapClient.EndpointConfiguration.InquiryPersonInfoSoap);
        }

        [HttpGet]
        [Route("getCustomerInfoByNationalCodeAsync")]
        public async Task<ResultObject> GetCustomerInfoByNationalCodeAsync(string nationalCode , string birthDate)
        {
            List<ServerErr> errors = null;
            CustomerHeadDto cust = new CustomerHeadDto();
            ResultObject resultObject = new ResultObject();

            try
            {
                var result = await client.GetPersonInfoAsync(nationalCode, birthDate, "microfunds", "micro#Funds@");
                if (result != null)
                {
                    cust.FirstName = result.Body.GetPersonInfoResult?.Name;
                    cust.LastName = result.Body.GetPersonInfoResult?.Family;
                    cust.FatherName = result.Body.GetPersonInfoResult?.FatherName;
                    cust.SSH = result.Body.GetPersonInfoResult?.ShenasnameNo;
                    cust.SeriNo = result.Body.GetPersonInfoResult?.ShenasnameSerial;
                    cust.SeriChar = result.Body.GetPersonInfoResult?.ShenasnameSeri;
                }
                else
                {
                    if (errors == null)
                        errors = new List<ServerErr>();
                    errors.Add(new ServerErr() { Hint = "فردی با مشخصات وارد شده یافت نشد"});
                    resultObject.Result = null;
                    resultObject.ServerErrors = errors;
                    return resultObject;
                }
            } catch
            {
                if (errors == null)
                    errors = new List<ServerErr>();
                errors.Add(new ServerErr() { Hint = "فردی با مشخصات وارد شده یافت نشد" });
                resultObject.Result = null;
                resultObject.ServerErrors = errors;
                return resultObject;
            }

            resultObject.Result = cust;
            resultObject.ServerErrors = null;

            return resultObject;
        }


    }
}