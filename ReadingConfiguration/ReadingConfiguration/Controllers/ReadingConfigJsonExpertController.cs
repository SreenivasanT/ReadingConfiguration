using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReadingConfiguration.Model;

namespace ReadingConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingConfigJsonExpertController : ControllerBase
    {
        private readonly MySettingsConfiguration _mySettingsConfiguration;

        public ReadingConfigJsonExpertController(IOptionsSnapshot<MySettingsConfiguration> mySettingsConfiguration)
        {
            _mySettingsConfiguration = mySettingsConfiguration.Value;
        }

        [HttpGet]
        public bool ReadingConfigExpert()
        {
            return _mySettingsConfiguration.Parameters?.IsProduction ?? false;
        }

    }
}
