using Consulting.Infrastructure.Data.Repositories.EFCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Consulting.Infrastructure.Core.ContextFactory;
using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using Consulting.Domains.Core.Core.Service;

namespace Consulting.Infrastructure.Core.Data.Repositories.EFCore
{
    public class NotificationRepository : EFCoreRepository<Message>, INotificationRepository
    {
      //  private AppDBContext Context { set; get; }
        private int _take;
        private IConfiguration _configuration;
        public NotificationRepository(IContextProviderFactory contextProvider , IConfiguration configuration) : base(contextProvider)
        {
          //  Context = context;
            _configuration = configuration;
            _take = int.Parse(_configuration.GetSection("paging").GetSection("Take").Value);
        }

        public async Task  CreateUserMessageAsync(UserMessage userMessage)
        {          
          await  Context.AddAsync(userMessage);
        }

        public async Task<IEnumerable<MessageJoinModel>> GetUserMessagesAsync(int userID)
        {       
            var result = await (from message in Context.Messages
                                join userMessage in Context.UserMessages
                                on message.ID equals userMessage.MessageID
                                join user in Context.Users on userMessage.ReceiverUserID equals user.ID                               
                                where  (userMessage.ReceiverUserID == userID)
                                select new MessageJoinModel
                                {
                                    Id = message.ID,
                                    Text = message.Text ,
                                    IsSeen = message.IsSeen,
                                    SenderName = userMessage.SenderUser.UserName ,
                                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<MessageJoinModel>> GetUnSeenUserMessagesAsync(int userID)
        {
            var result = await (from message in Context.Messages
                                join userMessage in Context.UserMessages
                                on message.ID equals userMessage.MessageID
                                join user in Context.Users on userMessage.ReceiverUserID equals user.ID
                                where message.IsSeen == false && (userMessage.ReceiverUserID == userID)
                                select new MessageJoinModel
                                {
                                    Id = message.ID,
                                    Text = message.Text,
                                    IsSeen = message.IsSeen,
                                    SenderName = userMessage.SenderUser.UserName,
                                }).ToListAsync();
            return result;
        }


    }

   

}
