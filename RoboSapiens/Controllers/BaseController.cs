using Microsoft.AspNetCore.Mvc;
using RoboSapiens.EF.Models;
using RoboSapiens.Repository;
using Telegram.Bot.Examples.DotNetCoreWebHook.Services;

namespace RoboSapiens.UI.Controllers
{
    public class BaseController : Controller
    {
        public IConversationsRepository Repo;

        public BaseController()
        {
            Repo = new ConversationsRepository(new SupportSapiensContext());
        }
    }
}