using System;
using System.Collections.Generic;
using System.Text;
using Domain.ViewModels;

namespace RoboSapiens.Repository.Mock
{
    public class ConversationsRepositoryMock : IConversationsRepository
    {
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
