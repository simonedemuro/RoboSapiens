using RoboSapiens.Domain.DTO;
using RoboSapiens.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RoboSapiens.Domain.ExtensionMethods;
using Domain.ViewModels;

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

        public List<ChatPreviewVM> GetConversations()
        {
            // TODO: Consider that in real world there will be the need to paginate it.. consider offset fetch
            List<Conversation> ConversationsChat = dbContext.Conversation.ToList();

            var ConversationsQuery = from conv in ConversationsChat
                                  join cust in dbContext.CustomerUser
                                  on conv.CustomerId equals cust.Id
                                  select new ChatPreviewVM(conv.Id, cust.Name, "", "");

            List<ChatPreviewVM> ConversationsVM = new List<ChatPreviewVM>();

            foreach (var conv in ConversationsQuery.ToList())
            {
                var lastMessage = dbContext.Message
                    .OrderBy(x => x.Timestamp)
                    .FirstOrDefault();

                ConversationsVM.Add(new ChatPreviewVM(conv.ChatID, conv.Username, lastMessage.Text, lastMessage.Timestamp.ToString()));
            }

            return ConversationsVM;
        }

    }
}
