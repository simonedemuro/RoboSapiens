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
            /*List<Message> dbMessages = dbContext.Message
                .Where(x => x.ConversationId == ConversationId)
                .ToList();
            List<MessageDTO> messageDTOs = new List<MessageDTO>();

            dbMessages.ForEach(x => messageDTOs.Add(x.ToMessageDTO()));

            return messageDTOs;*/
            return null;
        }


    }
}
