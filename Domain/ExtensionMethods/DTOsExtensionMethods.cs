using RoboSapiens.Domain.DTO;
using RoboSapiens.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboSapiens.Domain.ExtensionMethods
{
    public static class DTOsExtensionMethods
    {
        public static MessageDTO ToMessageDTO(this Message msg)
        {
            return new MessageDTO()
            {
                Id = msg.Id,
                IsFromAgent = msg.IsFromAgent,
                PrimaryEmotion = msg.PrimaryEmotion,
                Text = msg.Text
            };
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
