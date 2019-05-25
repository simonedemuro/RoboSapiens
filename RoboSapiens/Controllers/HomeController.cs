﻿using System;
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
    public class HomeController : Controller
    {
        ConversationsRepository Repo;

        public IActionResult Index()
        {
            Repo = new ConversationsRepository(new SupportSapiensContext());
            List<MessageDTO> test = Repo.GetConversationMessages(3);
            return View();
        }

        [HttpGet]
        public List<ChatPreviewVM> GetConversationPreview()
        {
            return new List<ChatPreviewVM>()
            {
                new ChatPreviewVM(1, "Marello", "ciao, sono disperato...", "24-MAR"),
                new ChatPreviewVM(2, "Giuseppe", "Vuoi guadagnare 200 euro al secondo quadro stando comodamente seduto a casa?", "22-MAR")
            };
        }

        [HttpGet]
        public List<ChatMessageVM> GetChatMessages()
        {
            return new List<ChatMessageVM>()
            {
                new ChatMessageVM("Ciaoo", "24-Mar", "11:09", "incoming_msg"),
                new ChatMessageVM("Salve, sono un messaggio molto lungo per un test, come sto? Nessuno mai me lo chiede...", "24-Mar", "11:10", "outgoing_msg")
            };
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
