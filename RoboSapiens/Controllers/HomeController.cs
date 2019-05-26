using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using RoboSapiens.Core.Services;
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
            return View();
        }

        [HttpGet]
        public List<ChatPreviewVM> GetConversationPreview() => Repo.GetConversations();

        [HttpGet]
        public List<ChatMessageVM> GetChatMessages(long ChatId)
        {
            return Repo.GetConversationMessages(ChatId);
        }

        [HttpGet]
        public void ReceiveMessage()
        {
            PythonService pythonService = new PythonService("","");
            PythonService.DownloadPageAsync("http://192.168.30.83:5000/api/analyse/I%20could%20watch%20Leonardo%20Di%20Caprios%20films%20all%20day%20as%20he%20is%20a%20very%20talented%20actor.");
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
