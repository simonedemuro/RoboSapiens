using System;
using System.Collections.Generic;

namespace RoboSapiens.EF.Models
{
    public partial class AgentIssueTag
    {
        public long Id { get; set; }
        public long AgentId { get; set; }
        public long IssueTagId { get; set; }

        public AgentUser Agent { get; set; }
        public IssueTag IssueTag { get; set; }
    }
}
