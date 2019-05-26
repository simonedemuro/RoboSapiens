using System.IO;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RoboSapiens.EF.Models;
using RoboSapiens.Repository;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Examples.DotNetCoreWebHook.Services
{
    public class UpdateService : IUpdateService
    {
        public IConversationsRepository Repo;
        private readonly IBotService _botService;

        public UpdateService(IBotService botService, ILogger<UpdateService> logger)
        {
            _botService = botService;
            Repo = new ConversationsRepository(new SupportSapiensContext());
        }

        public async Task EchoAsync(Update Update)
        {
            if (Update.Type != UpdateType.Message)
            {
                return;
            }

            var Message = Update.Message;

            if (Message.Type == MessageType.Text)
            {
                var Username = Update.Message.From.Username;
                long ConversationId = Repo.getConversationIdByUsername(Username);
                if(ConversationId != 0)
                {
                    Repo.PutMessageIntoChat(ConversationId, Message.Text, false);
                    Repo.setTelegramChatIdOnConversation(ConversationId, Message.Chat.Id);
                }
            }
        }


        void IUpdateService.SendMessageToTelegram(long TelegramChatId, string Message)
        {
            _botService.Client.SendTextMessageAsync(TelegramChatId, Message);
        }
    }
}
