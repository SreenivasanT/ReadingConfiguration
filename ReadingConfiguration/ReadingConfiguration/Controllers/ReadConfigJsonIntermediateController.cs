using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReadingConfiguration.Model;

namespace ReadingConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadConfigJsonIntermediateController : ControllerBase
    {
        private readonly MySettingsConfiguration _settings;

        public ReadConfigJsonIntermediateController(
            IConfiguration configuration)
        {
            _settings = new MySettingsConfiguration();
            configuration.GetSection("MySettings").Bind(_settings);
        }
        
        [HttpGet]
        public bool ReadConfigIntermediate()
        {
            return _settings?.Parameters?.IsProduction ?? false;
        }
    }
}
