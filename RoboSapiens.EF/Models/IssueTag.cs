using System;
using System.Collections.Generic;

namespace RoboSapiens.EF.Models
{
    public partial class IssueTag
    {
        public IssueTag()
        {
            AgentIssueTag = new HashSet<AgentIssueTag>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<AgentIssueTag> AgentIssueTag { get; set; }
    }
}
