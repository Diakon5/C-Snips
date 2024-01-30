using System.Data;
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
        /*[HttpGet(Name = "GetSingle", Order = 0)]
        public IEnumerable<WallMessage> Get()
        {
            var reader = SQLiteDatabase.GetMessages(1);
            reader.Read();
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
        }*/
        [HttpGet(Name = "GetAll",Order = 1)]
        public IEnumerable<WallMessage> GetAll()
        {
            var reader = SQLiteDatabase.GetMessages();
            List<WallMessage> list = new();
            while (reader.Read())
            {       
                var message = new WallMessage
                {
                    messageID = reader.GetInt32(0),
                    RespondingTo_ID = reader.GetInt32(1),
                    PostingDate = DateTime.Parse(reader.GetString(2)),
                    LastEditDate = DateTime.Parse(reader.GetString(3)),
                    Message = reader.GetString(5),
                    Author_ID = reader.GetInt32(4),
                };
                list.Add(message);
            }
            return list.ToArray();
            
        }
        [HttpPost]
        public WallMessage Post(WallMessageDTO message)
        {
        var wallMessage = new WallMessage
        {
            messageID = message.messageID,
            RespondingTo_ID = message.RespondingTo_ID,
            PostingDate = message.PostingDate,
            LastEditDate = message.LastEditDate,
            Message = message.Message,
            Author_ID = message.Author_ID
        };
        SQLiteDatabase.AddMessage(wallMessage);
        return wallMessage;
        }
    }
}