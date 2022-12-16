using Microsoft.AspNetCore.Mvc;
using OtpNet;
using OTPServices.Entity;
using OTPServices.Models;
using OTPServices.Services.IRepository;

namespace OTPapi.Controllers
{    
    [Route("api/v0.0.1/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly IOTPGenerateService _oTPGenerateService1;
        public OtpController(IOTPGenerateService oTPGenerateService)
        {
            _oTPGenerateService1 = oTPGenerateService;
        }
        [HttpPost]
        [Route("generateOTP")]
        public IActionResult Generate(UserDetailsModel model)
        {
            var result = _oTPGenerateService1.generateOTP(model);
            return Ok(result);
        }
        [HttpPost]
        [Route("validateOTP")]
        public IActionResult Validate(UserOTPModel model)
        {
            var result = _oTPGenerateService1.validateOTP(model);
            return Ok(result);
        }
    }
}
