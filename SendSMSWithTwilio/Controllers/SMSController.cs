using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendSMSWithTwilio.DTOs;
using SendSMSWithTwilio.Services;

namespace SendSMSWithTwilio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _smsService;

        public SMSController(ISMSService smsService)
        {
            _smsService = smsService;
        }
        [HttpPost("send")]
        public IActionResult Send(SMSDto dto)
        {
            var result = _smsService.Send(dto.PhoneNumber, dto.Body);

            if(!string.IsNullOrEmpty(result.ErrorMessage)) 
                return BadRequest(result.ErrorMessage);
            return Ok(result);

        }
    }
}
