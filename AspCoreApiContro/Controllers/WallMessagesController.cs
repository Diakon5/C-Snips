using AspCoreApiContro.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreApiContro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WallMessagesController : ControllerBase
    {
        
        private readonly ILogger<WallMessagesController> _logger;

        public WallMessagesController(ILogger<WallMessagesController> logger)
        {
            _logger = logger;
        }
                [HttpGet(Name = "GetSingleMessage")]
        public IEnumerable<WallMessage> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WallMessage
            {

            })
            .ToArray();
        }
    }
}