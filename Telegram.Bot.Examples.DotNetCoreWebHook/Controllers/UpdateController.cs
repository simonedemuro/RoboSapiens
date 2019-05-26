using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Examples.DotNetCoreWebHook.Services;
using Telegram.Bot.Types;
using RoboSapiens.EF.Models;

namespace Telegram.Bot.Examples.DotNetCoreWebHook.Controllers
{
    [Route("api/[controller]")]
    public class UpdateController : Controller
    {
        private readonly IUpdateService _updateService;

        public UpdateController(IUpdateService updateService)
        {
            _updateService = updateService;
        }

        // POST api/update
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update MessageFromTelegram)
        {
            var ComunicationMessage = new RoboSapiens.EF.Models.Message()
            {
                Text = MessageFromTelegram.Message.ToString()
            };

            await _updateService.EchoAsync(MessageFromTelegram);
            
            return Ok();
        }
    }
}
