using RoboSapiens.Domain.DTO;
using RoboSapiens.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RoboSapiens.Domain.ExtensionMethods;

namespace RoboSapiens.Repository
{
    public class ConversationsRepository
    {
        SupportSapiensContext dbContext;

        public ConversationsRepository(SupportSapiensContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MessageDTO> GetConversationMessages(long ConversationId)
        {
            List<Message> dbMessages = dbContext.Message
                .Where(x => x.ConversationId == ConversationId)
                .ToList();
            List<MessageDTO> messageDTOs = new List<MessageDTO>();

            dbMessages.ForEach(x => messageDTOs.Add(x.ToMessageDTO()));

            return messageDTOs;
        }

        public List<ConversationDTO> GetConversations()
        {
            // TODO: Consider that in real world there will be the need to paginate it.. consider offset fetch
            List<Conversation> ConversationsChat = dbContext.Conversation.ToList();
            List<ConversationDTO> conversationDTOs = new List<ConversationDTO>();
            ConversationsChat.ForEach(x => conversationDTOs.Add(x.ToConversationDTO()));
            return conversationDTOs;
        }

    }
}
