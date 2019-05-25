using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RoboSapiens.Domain.DTO;
using RoboSapiens.EF.Models;
using RoboSapiens.Models;
using RoboSapiens.Repository;
using RoboSapiens.UI.Controllers;

namespace RoboSapiens.Controllers
{
    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            //List<MessageDTO> test = Repo.GetConversationMessages(3);
            //List <ConversationDTO> testConversations = Repo.GetConversations();
            return View();
        }

        [HttpGet]
        public List<ChatPreviewVM> GetConversationPreview() => Repo.GetConversations();

        [HttpGet]
        public List<ChatMessageVM> GetChatMessages(long ChatId)
        {
            return Repo.GetConversationMessages(ChatId);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
