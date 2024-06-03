using BlackService;
using Microsoft.AspNetCore.Mvc;

namespace SoapServiceConsume.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlackController : ControllerBase
    {
        

        private readonly ILogger<BlackController> _logger;

        public BlackController(ILogger<BlackController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<BlackDataContract>> GetPersons()
        {
            IBlackService blackService = new BlackServiceClient(BlackServiceClient.EndpointConfiguration.BasicHttpBinding_IBlackService);
            var data = await blackService.GetPersonsAsync();
            return [.. data];
        }

        [Route("GetPerson")]
        [HttpGet]
        public async Task<BlackDataContract> GetPerson()
        {
            IBlackService blackService = new BlackServiceClient(BlackServiceClient.EndpointConfiguration.BasicHttpBinding_IBlackService);
            return await blackService.GetPersonAsync();
        }

        [Route("Hello")]
        [HttpGet]
        public async Task<IActionResult> Hello()
        {
            BlackServiceClient blackService = new(BlackServiceClient.EndpointConfiguration.BasicHttpBinding_IBlackService);
            return Ok(await blackService.HelloAsync());
        }

        [Route("Hi")]
        [HttpGet]
        public async Task<IActionResult> Hi()
        {
            BlackServiceClient blackService = new(BlackServiceClient.EndpointConfiguration.BasicHttpBinding_IBlackService);
            return Ok(await blackService.GetHiAsync());
        }
    }
}
