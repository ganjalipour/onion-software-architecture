using AutoMapper;
using Consulting.Common.Data;
using Consulting.Common.Model;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.ServiceModel;
using Microsoft.AspNetCore.SignalR;
using Consulting.Applications.AppService.ServiceDto.BasicDto;
using Consulting.Applications.AppService.ServiceDto.Sessions;

namespace Consulting.Applications.Notification
{
    public class NotificationAppService : Hub
    {
        private readonly IMapper mapper;
        private NotificationService notificationService;
        private UserService userService;
        private BranchService branchService;

        private readonly ITransactionManager transactionManager;
        public NotificationAppService(NotificationService _notificationService, ITransactionManager _transactionManager, IMapper _mapper, UserService _userService, BranchService _branchService)
        {
            mapper = _mapper;
            branchService = _branchService;
            notificationService = _notificationService;
            userService = _userService;
            transactionManager = _transactionManager;
        }

        public async Task<ResultObject> SendSessionMessage(SessionMessageDto messageDto)
        {
            ResultObject resultObject = new ResultObject();
            foreach (var item in messageDto.SessionUsers)
            {
                messageDto.Text = $"{item.FirstName + " " + item.LastName} " +
                   $"{Environment.NewLine}   جلسه ی {messageDto.BranchName} در تاریخ و ساعت   {messageDto.SessionDate}  در محل  {messageDto.SessionAddress} برگزار خواهد شد {Environment.NewLine} از شما دعوت میشود در این جلسه حضور به عمل رسانید .";
                this.SendMessage(messageDto.Text, item.PhoneNumber);
            }
            resultObject.ServerErrors = null;
            return resultObject;
        }

        public async Task<ResultObject> SendMessages(string messageBody, List<string> phones)
        {
            List<ServerErr> errors = null;
            ResultObject resultObject = new ResultObject();

            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://smsservice.sko/");
            foreach (var item in phones)
            {
                try
                {
                    //var result = await client.SendMessageAsync(messageBody, item);
                    
                    //if (result == null)
                    //{
                    //    if (errors == null)
                    //        errors = new List<ServerErr>();
                    //    errors.Add(new ServerErr() { Hint = "پیام با موفقیت ارسال نشد" });
                    //    resultObject.Result = null;
                    //    resultObject.ServerErrors = errors;
                    //    return resultObject;
                    //}
                }
                catch
                {
                    if (errors == null)
                        errors = new List<ServerErr>();
                    errors.Add(new ServerErr() { Hint = "پیام با موفقیت ارسال نشد" });
                    resultObject.Result = null;
                    resultObject.ServerErrors = errors;
                    return resultObject;
                }
            }
           

            resultObject.ServerErrors = null;

            return resultObject;
        }

        public async Task<ResultObject> SendMessage(string messageBody, string phoneNumber)
        {
            List<ServerErr> errors = null;
            ResultObject resultObject = new ResultObject();

            var myBinding = new BasicHttpBinding();
            var myEndpoint = new EndpointAddress("http://smsservice.sko/");
            try
            {
                //var result = await client.SendMessageAsync(messageBody, phoneNumber);
                //if (result == null)
                //{
                //    if (errors == null)
                //        errors = new List<ServerErr>();
                //    errors.Add(new ServerErr() { Hint = "پیام با موفقیت ارسال نشد" });
                //    resultObject.Result = null;
                //    resultObject.ServerErrors = errors;
                //    return resultObject;
                //}
            }
            catch
            {
                if (errors == null)
                    errors = new List<ServerErr>();
                errors.Add(new ServerErr() { Hint = "پیام با موفقیت ارسال نشد" });
                resultObject.Result = null;
                resultObject.ServerErrors = errors;
                return resultObject;
            }
            //using (var myChannelFactory = new ChannelFactory<MessageSoap>(myBinding, myEndpoint))
            //{
            //    MessageSoap client = null;

            //try
            //{
            //    client = myChannelFactory.CreateChannel();
            //    MessageService.SendMessageRequest request = new MessageService.SendMessageRequest();
            //    request.Body = new MessageService.SendMessageRequestBody();
            //    request.Body.messageBody = messageBody;
            //    request.Body.phoneNumber = phoneNumber;
            //    var result = client.SendMessageAsync(request);
            //    ((ICommunicationObject)client).Close();
            //    myChannelFactory.Close();
            //    if (result != null)
            //    {

            //    }
            //    else
            //    {
            //        if (errors == null)
            //            errors = new List<ServerErr>();
            //        errors.Add(new ServerErr() { Hint = "پیام با موفقیت ارسال نشد" });
            //        resultObject.Result = null;
            //        resultObject.ServerErrors = errors;
            //        return resultObject;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    (client as ICommunicationObject)?.Abort();
            //    if (errors == null)
            //        errors = new List<ServerErr>();
            //    errors.Add(new ServerErr() { Hint = "پیام با موفقیت ارسال نشد" });
            //    resultObject.Result = null;
            //    resultObject.ServerErrors = errors;
            //    return resultObject;
            //}
            //  }



            resultObject.ServerErrors = null;

            return resultObject;
        }

        public async Task BroadcastMessage(MessageDto message)
        {

            //await Clients.All.SendAsync("broadcastMessage", message);
            var userBranch = mapper.Map<UserBranches>(message.UserBranchDto);
            var users = await userService.GetUsersBasedOnRoleAsync(userBranch);

            Message messagee = new Message()
            {
                Text = message.Text,
                IsSeen = false,
            };

            IList<UserMessage> UserMessagees = new List<UserMessage>();

            foreach (var item in users)
            {
                UserMessage userMessage = new UserMessage()
                {
                    ReceiverUserID = item.ID,
                    SenderUserID = message.SenderID,
                    MessageID = message.Id,
                };

                UserMessagees.Add(userMessage);
            }

            messagee.UserMessages = UserMessagees;
            await notificationService.CreateMessageAsync(messagee);


            await transactionManager.SaveAllAsync();


            foreach (var item in users)
            {
                var userMessages = await notificationService.GetUnSeenUserMessagesAsync(item.ID);
                await Clients.User(item.ID.ToString()).SendAsync("broadcastMessage", userMessages.ToList().Count);
            }


        }

        public async Task SendMessageToUser(MessageDto message)
        {
            Message messagee = new Message()
            {
                Text = message.Text,
                IsSeen = false,
            };

            UserMessage userMessage = new UserMessage()
            {
                ReceiverUserID = message.recivierID,
                SenderUserID = message.SenderID,
                MessageID = message.recivierID,
                Message = messagee,
            };
            // await notificationService.CreateMessageAsync(messagee);
            await notificationService.CreateUserMessageAsync(userMessage);
            await transactionManager.SaveAllAsync();
            var userMessages = await notificationService.GetUnSeenUserMessagesAsync(message.recivierID);
            await Clients.User(message.recivierID.ToString()).SendAsync("broadcastMessage", userMessages.ToList().Count);
        }



        public async Task SendMessageToSessionMembers(MessageDto message , List<int> userIDs)
        {
            Message messagee = new Message()
            {
                Text = message.Text,
                IsSeen = false,
            };

            IList<UserMessage> UserMessagees = new List<UserMessage>();

            foreach (var item in userIDs)
            {
                UserMessage userMessage = new UserMessage()
                {
                    ReceiverUserID = item ,
                    SenderUserID = message.SenderID,
                    MessageID = message.Id,
                };

                UserMessagees.Add(userMessage);
            }

            messagee.UserMessages = UserMessagees;
            await notificationService.CreateMessageAsync(messagee);


            await transactionManager.SaveAllAsync();


            foreach (var item in userIDs)
            {
                var userMessages = await notificationService.GetUnSeenUserMessagesAsync(item);
                await Clients.User(item.ToString()).SendAsync("broadcastMessage", userMessages.ToList().Count);
            }

        }


        public async Task<ResultListDto> getUserMessages(int userID)
        {
            ResultListDto resultListDto = new ResultListDto();

            var result = await notificationService.GetUserMessagesAsync(userID);

            var messagess = mapper.Map<List<MessageDto>>(result);

            resultListDto.TotalRows = messagess.Count();

            resultListDto.Results = messagess;
            resultListDto.ServerErrors = null;
            return resultListDto;
        }

        public async Task<ResultListDto> getUnSeenUserMessages(int userID)
        {
            ResultListDto resultListDto = new ResultListDto();

            var result = await notificationService.GetUnSeenUserMessagesAsync(userID);

            var messagess = mapper.Map<List<MessageDto>>(result);

            resultListDto.TotalRows = messagess.Count();

            resultListDto.Results = messagess;
            resultListDto.ServerErrors = null;
            return resultListDto;
        }

        public async Task<MessageDto> UpdateMessageAsync(MessageDto messageDto)
        {
            var message = mapper.Map<Message>(messageDto);
            var messageTask = await notificationService.UpdateMessageAsync(message);
            await transactionManager.SaveAllAsync();
            var finalMessageDto = mapper.Map<MessageDto>(messageTask);
            return finalMessageDto;
        }




    }


}




