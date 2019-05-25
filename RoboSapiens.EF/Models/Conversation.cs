using System;
using System.Collections.Generic;

namespace RoboSapiens.EF.Models
{
    public partial class Conversation
    {
        public Conversation()
        {
            Message = new HashSet<Message>();
        }

        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long AgentId { get; set; }
        public string PrevalentEmotion { get; set; }
        public int State { get; set; }
        public long TagId { get; set; }

        public AgentUser Agent { get; set; }
        public CustomerUser Customer { get; set; }
        public IssueTag Tag { get; set; }
        public ICollection<Message> Message { get; set; }
    }
}
