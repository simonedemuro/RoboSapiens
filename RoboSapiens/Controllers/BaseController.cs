using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoboSapiens.EF.Models;
using RoboSapiens.Repository;

namespace RoboSapiens.UI.Controllers
{
    public class BaseController : Controller
    {
        public ConversationsRepository Repo;

        public BaseController()
        {
            Repo = new ConversationsRepository(new SupportSapiensContext());
        }
    }
}