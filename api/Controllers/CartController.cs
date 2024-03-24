using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditCardController : ControllerBase
    {
        private readonly IMongoCollection<Cart> _cart;
<<<<<<< HEAD
        private readonly IMongoCollection<User> _user;
=======
>>>>>>> ef125a3cde044403fae8ef5fc66a3af2e4cf0343

        public CreditCardController(IMongoClient client)
        {
            var database = client.GetDatabase("zofy");
            _cart = database.GetCollection<Cart>("carts");
<<<<<<< HEAD
            _user = database.GetCollection<User>("users");
=======
>>>>>>> ef125a3cde044403fae8ef5fc66a3af2e4cf0343
        }

        // GET: api/creditcard
        [HttpGet]
        public ActionResult<IEnumerable<Cart>> Get()
        {
            var creditCards = _cart.Find(_ => true).ToList();
            return Ok(creditCards);
        }

        // GET: api/creditcard/{id}
        [HttpGet("{id}")]
        public ActionResult<Cart> Get(ObjectId id)
        {
            var creditCard = _cart.Find(c => c.Id == id).FirstOrDefault();
            if (creditCard == null)
            {
                return NotFound();
            }
            return Ok(creditCard);
        }

        // POST: api/creditcard
        [HttpPost]
<<<<<<< HEAD
        public ActionResult<Cart> Post(string creditCard)
        {
            var objectId = new ObjectId(creditCard);
            var user = _user.Find(user => user.Id == objectId).FirstOrDefault();
            if (user != null)
            {
                Random rnd = new Random();

                Cart new_cart = new Cart
                {
                    UserId = objectId.ToString(),
                    CartNumber = rnd.Next(100000000, 999999999).ToString(),
                    CartName = user.Name?.ToUpper()+" "+user.Surname?.ToUpper(),
                    expireMonth = rnd.Next(1, 12),
                    expireYear = rnd.Next(2025, 2035),
                    Cvv = rnd.Next(100, 999)
                };

                _cart.InsertOne(new_cart);
                return Ok(new_cart);
            }
            else
            {
                return NotFound();
            }
        }

=======
        public ActionResult<Cart> Post(Cart creditCard)
        {
            _cart.InsertOne(creditCard);
            return CreatedAtAction(nameof(Get), new { id = creditCard.Id }, creditCard);
        }
        // DELETE: api/creditcard/{id}
>>>>>>> ef125a3cde044403fae8ef5fc66a3af2e4cf0343
        [HttpDelete("{id}")]
        public IActionResult Delete(ObjectId id)
        {
            var result = _cart.DeleteOne(c => c.Id == id);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}