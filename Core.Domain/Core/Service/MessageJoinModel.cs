using Consulting.Domains.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Consulting.Domains.Core.Core.Service
{
    public class MessageJoinModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int SenderID { get; set; }

        public int recivierID { get; set; }

        public string SenderName { get; set; }

        public bool IsSeen { get; set; }

        public ICollection<UserMessage> UserMessages { get; set; }
    }
}
