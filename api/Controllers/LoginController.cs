using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMongoCollection<User> _users;

        public LoginController(IMongoClient client)
        {
            var database = client.GetDatabase("zofy");
            _users = database.GetCollection<User>("users");
        }

        [HttpPost]
        public async Task<User> Login(User loginRequest)
        {
            var user = await _users.Find(u => u.Email == loginRequest.Email && u.Password == loginRequest.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
