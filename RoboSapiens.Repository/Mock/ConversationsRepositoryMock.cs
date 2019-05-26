using System;
using System.Collections.Generic;
using System.Text;
using Domain.ViewModels;

namespace RoboSapiens.Repository.Mock
{
    public class ConversationsRepositoryMock : IConversationsRepository
    {
        public string FindMoodByMessageId(long MessageId)
        {
            throw new NotImplementedException();
        }

        public long getConversationIdByUsername(string Username)
        {
            throw new NotImplementedException();
        }

        public List<ChatMessageVM> GetConversationMessages(long ConversationId)
        {
            throw new NotImplementedException();
        }
        public long GetTelegramChatIdByConversationId(long ConversationId)
        {
            throw new NotImplementedException();
        }

        public void PutMessageIntoChat(long ChatId, string Message, bool isFromAgent)
        {
            throw new NotImplementedException();
        }

        public List<ChatPreviewVM> GetConversations()
        {
            throw new NotImplementedException();
        }

        public void setTelegramChatIdOnConversation(long ConversationId, long TelegramChatId)
        {
            throw new NotImplementedException();
        }
    }
}
