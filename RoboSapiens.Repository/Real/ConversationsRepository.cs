using RoboSapiens.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RoboSapiens.Domain.ExtensionMethods;
using Domain.ViewModels;
using RoboSapiens.Core.Services;

namespace RoboSapiens.Repository
{
    public class ConversationsRepository : IConversationsRepository
    {
        private const string URL = "https://sub.domain.com/objects.json";
        SupportSapiensContext dbContext;

        public ConversationsRepository(SupportSapiensContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public long getConversationIdByUsername(string Username)
        {
            CustomerUser User = dbContext.CustomerUser
                .Where(x => x.Name == Username).First();
            if(User != null)
            {
                return dbContext.Conversation
                    .Where(x => x.CustomerId == User.Id).First().Id;
            } else
            {
                return 0;
            }
        }

        public List<ChatMessageVM> GetConversationMessages(long ConversationId)
        {
            List<Message> dbMessages = dbContext.Message
                .Where(x => x.ConversationId == ConversationId)
                .ToList();
            List<ChatMessageVM> messageDTOs = new List<ChatMessageVM>();

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

        public void PutMessageIntoChat(long ChatId, string Message, bool IsFromAgent)
        {
            string PrimaryEmotion = analyzeData(Message);
            Message message = new Message();
            message.ConversationId = ChatId;
            message.IsFromAgent = IsFromAgent;
            message.Text = Message;
            message.Timestamp = DateTime.Now;
            message.PrimaryEmotion = PrimaryEmotion;

            dbContext.Message.Add(message);
            dbContext.SaveChanges();
        }

        public void setTelegramChatIdOnConversation(long ConversationId, long TelegramChatId)
        {
            Conversation Conversation = dbContext.Conversation
                .Where(x => x.Id == ConversationId).First();

            if(Conversation != null)
            {
                Conversation.TelegramChatId= TelegramChatId;
                dbContext.SaveChanges();
            }
        }

        private string analyzeData(string Message)
        {
            PythonService pythonService = new PythonService("", "");
            return PythonService.getMLAnalysis("http://192.168.30.83:5000/api/analyse/" + System.Net.WebUtility.UrlEncode((Message)));
        }
    }
}
