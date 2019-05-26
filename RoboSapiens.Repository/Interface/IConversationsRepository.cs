using System.Collections.Generic;
using Domain.ViewModels;

namespace RoboSapiens.Repository
{
    public interface IConversationsRepository
    {
        List<ChatMessageVM> GetConversationMessages(long ConversationId);
        List<ChatPreviewVM> GetConversations();

        List<ChatMessageVM> PutMessageIntoChat(long ChatId, string Message, bool isFromAgent);
    }
}