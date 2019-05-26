using System;
using System.Collections.Generic;
using System.Text;
using Domain.ViewModels;

namespace RoboSapiens.Repository.Mock
{
    public class ConversationsRepositoryMock : IConversationsRepository
    {

        public void PutMessageIntoChat(long ChatId, string Message, bool isFromAgent)
        {
            throw new NotImplementedException();
        }

        List<ChatMessageVM> IConversationsRepository.GetConversationMessages(long ConversationId)
        {
            throw new NotImplementedException();
        }

        List<ChatPreviewVM> IConversationsRepository.GetConversations()
        {
            throw new NotImplementedException();
        }
    }
}
