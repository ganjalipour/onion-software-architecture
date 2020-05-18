using Consulting.Common.Data;
using Consulting.Domains.Core.Core.Service;
using Consulting.Domains.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Consulting.Domains.Core.Repositories
{
    public interface INotificationRepository : IRepository<Message>
    {
        Task CreateUserMessageAsync(UserMessage userMessage);

        Task<IEnumerable<MessageJoinModel>> GetUserMessagesAsync(int userID);

        Task<IEnumerable<MessageJoinModel>> GetUnSeenUserMessagesAsync(int userID);
    } 
}
