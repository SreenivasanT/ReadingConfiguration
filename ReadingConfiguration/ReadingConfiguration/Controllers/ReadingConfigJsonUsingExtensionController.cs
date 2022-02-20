using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReadingConfiguration.Model;

namespace ReadingConfiguration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingConfigJsonUsingExtensionController : ControllerBase
    {
        private readonly TradingConfiguration _trading;
        private readonly CarConfiguration _car;

        public ReadingConfigJsonUsingExtensionController(IOptionsSnapshot<TradingConfiguration> trading,IOptionsSnapshot<CarConfiguration> car)
        {
            _trading = trading.Value;
            _car = car.Value;
        }
        
        [HttpGet]
        public string ReadingConfigUsingExtension()
        {
            return $"ChartType: {_trading.ChartType} -- Function: {_trading.Function}";
        }

        [HttpGet]
        [Route("ReadingConfigUsingExtensionCar")]
        public string ReadingConfigUsingExtensionCar()
        {
            return $"Manufacturer: {_car.Manufacturer} -- Model: {_car.Model}";
        }



    }
}
