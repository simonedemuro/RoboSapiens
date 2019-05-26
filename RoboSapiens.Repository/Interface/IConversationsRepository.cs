using System.Collections.Generic;
using Domain.ViewModels;
using RoboSapiens.EF.Models;

namespace RoboSapiens.Repository
{
    public interface IConversationsRepository
    {
        List<ChatMessageVM> GetConversationMessages(long ConversationId);
        List<ChatPreviewVM> GetConversations();

        void PutMessageIntoChat(long ChatId, string Message, bool IsFromAgent);

        long getConversationIdByUsername(string Username);

        void setTelegramChatIdOnConversation(long ConversationId, long TelegramChatId);

        string FindMoodByMessageId(long MessageId);

        long GetTelegramChatIdByConversationId(long ConversationId);
    }
}