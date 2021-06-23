using GlobalmanticsSQSWebAPI.Interfaces;
using GlobalmanticsSQSWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GlobalmanticsSQSWebAPI.Controllers
{
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly ISQSService _sQSService;

        public QueueController(ISQSService sQSService)
        {
            _sQSService = sQSService;
        }

        [HttpPost]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(TicketRequest dto)
        {
            var response = await _sQSService.SendMessageToQueueAsync(dto);

            if(response == null)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
