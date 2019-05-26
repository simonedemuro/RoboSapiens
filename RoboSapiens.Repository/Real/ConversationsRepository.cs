﻿using RoboSapiens.Domain.DTO;
using RoboSapiens.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using RoboSapiens.Domain.ExtensionMethods;
using Domain.ViewModels;
using System.Net.Http;

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

        public List<ChatMessageVM> PutMessageIntoChat(long ChatId, string Message, bool isFromAgent)
        {
            //TODO: call Python message analysis
            string PrimaryEmotion = "";
            Message message = new Message();
            message.ConversationId = ChatId;
            message.IsFromAgent = isFromAgent;
            message.Text = Message;
            message.Timestamp = DateTime.Now;
            message.PrimaryEmotion = PrimaryEmotion;

            dbContext.Message.Add(message);
            dbContext.SaveChanges();

            return GetConversationMessages(ChatId);
        }

        private void analyzeData(long ChatId, string Message, bool isFromAgent)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);


        }
    }
}
