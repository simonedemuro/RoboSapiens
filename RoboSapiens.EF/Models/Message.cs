using System;
using System.Collections.Generic;

namespace RoboSapiens.EF.Models
{
    public partial class Message
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool IsFromAgent { get; set; }
        public string PrimaryEmotion { get; set; }
    }
}
