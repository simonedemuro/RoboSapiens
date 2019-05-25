using Domain.ViewModels;
using RoboSapiens.Domain.DTO;
using RoboSapiens.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboSapiens.Domain.ExtensionMethods
{
    public static class DTOsExtensionMethods
    {
        public static ChatMessageVM ToMessageDTO(this Message msg)
        {
            return new ChatMessageVM(msg.Text, msg.Timestamp.Date.ToString(), msg.Timestamp.TimeOfDay.ToString(), msg.IsFromAgent);
        }

        public static ConversationDTO ToConversationDTO(this Conversation conv)
        {
            return new ConversationDTO()
            {
                AgentId = conv.AgentId,
                CustomerId = conv.CustomerId,
                Id = conv.Id,
                PrevalentEmotion = conv.PrevalentEmotion,
                State = conv.State,
                TagId = conv.TagId
            };
        }

    }
}
