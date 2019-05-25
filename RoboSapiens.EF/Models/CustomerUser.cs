using System;
using System.Collections.Generic;

namespace RoboSapiens.EF.Models
{
    public partial class CustomerUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Attributes { get; set; }
    }
}
