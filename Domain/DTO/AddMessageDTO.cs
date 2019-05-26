using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboSapiens.Domain.DTO
{
    [JsonObject]
    [Serializable]
    public class AddMessageDTO
    {
        public long ChatId { get; set; }
        public string Message { get; set; }
        public bool IsFromAgent { get; set; }
    }
}
