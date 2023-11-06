using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_24BM.Models;
using Web_24BM.Services;

namespace Web_24BM.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailSenderServices _emailSenderService;

        public SendEmailController(IEmailSenderServices emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }

        [HttpPost]
        public IActionResult Send(MensajeViewModel model)

        {
            var result = _emailSenderService.SendEmailWithData(model);
            if((bool)result)
            {
                return Ok(model);
            }
            else
            {
                return BadRequest();
            }
            
        }

    }
}
//jeronimo