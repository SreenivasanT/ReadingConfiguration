using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ReadingConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadConfigJsonBeginnerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ReadConfigJsonBeginnerController(
            IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        [HttpGet]
        [Route("ReadingConfigJsonVeryBasic")]
        public bool ReadingConfigVeryBasic()
        {
            return bool.Parse(_configuration.GetSection("MySettings").GetSection("Parameters").GetSection("IsProduction").Value);
        }

        [HttpGet]
        [Route("ReadingConfigJsonBasic")]
        public bool ReadingConfigJsonBasic()
        {
            return _configuration.GetSection("MySettings").GetSection("Parameters").GetValue<bool>("IsProduction");
        }

        [HttpGet]
        [Route("ReadingConfigJsonBeginner")]
        public bool ReadingConfigJsonBeginner()
        {
            return _configuration.GetValue<bool>("MySettings:Parameters:IsProduction");
        }


    }
}
