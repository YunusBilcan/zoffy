using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _users;

        public UserController(IMongoClient client)
        {
            var database = client.GetDatabase("zofy");

            _users = database.GetCollection<User>("users");
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var users = _users.Find(user => true).ToList();
            return users;
        }

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var _id = new ObjectId(id);

            var user = _users.Find(user => user.Id == _id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _users.InsertOne(user);
            return Ok(user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(ObjectId id, User updatedUser)
        {
            var user = _users.Find(user => user.Id == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            _users.ReplaceOne(user => user.Id == id, updatedUser);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(ObjectId id)
        {
            var user = _users.Find(user => user.Id == id).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            _users.DeleteOne(user => user.Id == id);
            return NoContent();
        }
    }

}