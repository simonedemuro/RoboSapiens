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
            List<MessageDTO> test = Repo.GetConversationMessages(3);
            return View();
        }

        [HttpGet]
        public List<ChatPreviewVM> GetConversationPreview()
        {
            return new List<ChatPreviewVM>()
            {
                new ChatPreviewVM("Marello", "ciao, sono disperato...", "24-MAR")
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
