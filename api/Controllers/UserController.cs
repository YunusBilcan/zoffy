using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMongoCollection<User> _users;

        public UserController(IMongoClient client)
        {
            var database = client.GetDatabase("zofy");
            _users = database.GetCollection<User>("users");
        }

        [HttpPost("CreateUser")]
        public async Task<User> CreateUser(User user)
        {
            await _users.InsertOneAsync(user);
            return user;
        }

        [HttpPost("Login")]
        public async Task<User> Login(User loginRequest)
        {
            var user = await _users.Find(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password).FirstOrDefaultAsync();
            return user;
        }

        [HttpGet("GetUser")]
        public async Task<User> GetUser(string email)
        {
            var user = await _users.Find(u => u.Email == email).FirstOrDefaultAsync();
            return user;
        }
    }

    public class User
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    public class LoginRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
