using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ReadingConfiguration.Model;

namespace ReadingConfiguration
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingAzureAppConfigurationController : ControllerBase
    {
        private readonly AAConfiguration _aaConfiguration;
        private readonly IConfiguration _configuration; 

        public ReadingAzureAppConfigurationController(IOptionsSnapshot<AAConfiguration> optionsSnapshot,IConfiguration configuration)
        {
            _aaConfiguration = optionsSnapshot.Value;
            _configuration = configuration;
        }

        [HttpGet]
        public string ReadingDynamicAzureAppConfiguration()
        {
            return _aaConfiguration.Message;
        }

        [HttpGet]
        [Route("ReadingAppConfig")]
        public string ReadingAzureAppConfiguration()
        {
            return _configuration["Message"];
        }
    }
}
