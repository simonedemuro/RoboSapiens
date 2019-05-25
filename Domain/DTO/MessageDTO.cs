using System;
using System.Collections.Generic;
using System.Text;

namespace RoboSapiens.Domain.DTO
{
    public class MessageDTO
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public bool IsFromAgent { get; set; }
        public string PrimaryEmotion { get; set; }
    }
}
