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
        private readonly ILogger<UpdateService> _logger;

        public UpdateService(IBotService botService, ILogger<UpdateService> logger)
        {
            _botService = botService;
            _logger = logger;
            Repo = new ConversationsRepository(new SupportSapiensContext());
        }

        public async Task EchoAsync(Update update)
        {
            if (update.Type != UpdateType.Message)
            {
                return;
            }

            var message = update.Message;

            _logger.LogInformation("Received Message from {0}", message.Chat.Id);

            if (message.Type == MessageType.Text)
            {
                Repo.PutMessageIntoChat(3, message.Text, false);
                // Echo each Message
                await _botService.Client.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
        }
    }
}
