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
            var reader = SQLiteDatabase.GetMessages(1);
            reader.GetString(1);
            return Enumerable.Range(1, 1).Select(index => new WallMessage
            {
                messageID = reader.GetInt32(0),
                RespondingTo_ID = reader.GetInt32(1),
                PostingDate = (DateTime)reader.GetValue(2),
                LastEditDate = (DateTime)reader.GetValue(3),
                Message = reader.GetString(4),
                Author_ID = reader.GetInt32(5),
            })
            .ToArray();
        }
    }
}