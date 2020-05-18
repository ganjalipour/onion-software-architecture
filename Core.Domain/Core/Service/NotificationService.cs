using Consulting.Domains.Core.Entities;
using Consulting.Domains.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Consulting.Domains.Core.Core.Service;

namespace Consulting.Domains.Core.Service
{
    public class NotificationService
    {

        private INotificationRepository notificationRepository;
        public NotificationService(INotificationRepository _notificationRepository)
        {
            notificationRepository = _notificationRepository;
        }

        public async Task CreateMessageAsync(Message message)
        {
            await notificationRepository.AddAsync(message);
        }

        public async Task<Message> UpdateMessageAsync(Message message)
        {
            return await notificationRepository.UpdateAsync(message, message.ID);
        }


        public async Task CreateUserMessageAsync(UserMessage userMessage)
        {
            await notificationRepository.CreateUserMessageAsync(userMessage);
        }

        public async Task<IEnumerable<MessageJoinModel>> GetUserMessagesAsync(int userID)
        {
            return await notificationRepository.GetUserMessagesAsync(userID);
        }


        public async Task<IEnumerable<MessageJoinModel>> GetUnSeenUserMessagesAsync(int userID)
        {
            return await notificationRepository.GetUnSeenUserMessagesAsync(userID);
        }

    }
}
