using System;
using System.Collections.Generic;

namespace RoboSapiens.EF.Models
{
    public partial class AgentUser
    {
        public AgentUser()
        {
            AgentIssueTag = new HashSet<AgentIssueTag>();
            Conversation = new HashSet<Conversation>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<AgentIssueTag> AgentIssueTag { get; set; }
        public ICollection<Conversation> Conversation { get; set; }
    }
}
