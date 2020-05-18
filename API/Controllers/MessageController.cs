using System;
using System.Threading.Tasks;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.Sessions;
using Consulting.Applications.Notification;
using Consulting.Common.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    public class MessageController : Controller 
    {

        private IHubContext<NotificationAppService> _hub;

        private NotificationAppService notificationAppService;

        public MessageController(IHubContext<NotificationAppService> hub , NotificationAppService _notificationAppService)
        {
            _hub = hub;
            notificationAppService = _notificationAppService;
        }

        public IActionResult Get()
        {
            return Ok(new { Message = "Request Completed", x = 10 });
        }


        [Route("SendMessages")]
        public async Task<ResultObject> SendMessages(SessionMessageDto messageDto)
        {
           var result = await  this.notificationAppService.SendSessionMessage(messageDto);
            return result;
        }

        [Route("getUserMessages/{userID}")]
        //[ServiceFilter(typeof(ActionFilterMicroFund))]
        //[MicroFundAuthorize(ConstActivities.GetLoanByIDAsync)]
        public async Task<ResultListDto> GetUserMessagesAsync(int userID)
        {
            var result = await notificationAppService.getUserMessages(userID);
            return result;
        }

        [Route("getUnSeenUserMessages/{userID}")]
        //[ServiceFilter(typeof(ActionFilterMicroFund))]
        //[MicroFundAuthorize(ConstActivities.GetLoanByIDAsync)]
        public async Task<ResultListDto> getUnSeenUserMessagesAsync(int userID)
        {
            var result = await notificationAppService.getUnSeenUserMessages(userID);
            return result;
        }



        [HttpPost("UpdateMessageAsync")]
        [Route("update")]
        public async Task<ResultObject> UpdateMessageAsync(MessageDto messageDto)
        {
            var message = await notificationAppService.UpdateMessageAsync(messageDto);
            var resultobject = new ResultObject { Result = message, ServerErrors = null };
            return resultobject;
        }


    }
}