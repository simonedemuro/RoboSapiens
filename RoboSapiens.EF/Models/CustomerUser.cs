using System;
using System.Collections.Generic;

namespace RoboSapiens.EF.Models
{
    public partial class CustomerUser
    {
        public CustomerUser()
        {
            Conversation = new HashSet<Conversation>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Attributes { get; set; }

        public ICollection<Conversation> Conversation { get; set; }
    }
}
