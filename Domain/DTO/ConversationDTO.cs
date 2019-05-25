using System;
using System.Collections.Generic;
using System.Text;

namespace RoboSapiens.Domain.DTO
{
    public class ConversationDTO
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public long AgentId { get; set; }
        public string PrevalentEmotion { get; set; }
        public int State { get; set; }
        public long TagId { get; set; }
    }
}
