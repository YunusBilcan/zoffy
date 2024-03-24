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
        public async Task<ActionResult<User>> Login(Login login)
        {
            var logindata = await _users.Find(u => u.Email == login.Email && u.Password == login.Password).FirstOrDefaultAsync();
            string result = logindata.Id.ToString();
            return Ok(result);
        }
    }
}
