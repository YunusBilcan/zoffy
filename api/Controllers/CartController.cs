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

        public CreditCardController(IMongoClient client)
        {
            var database = client.GetDatabase("zofy");
            _cart = database.GetCollection<Cart>("carts");
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
        public ActionResult<Cart> Post(Cart creditCard)
        {
            _cart.InsertOne(creditCard);
            return CreatedAtAction(nameof(Get), new { id = creditCard.Id }, creditCard);
        }
        // DELETE: api/creditcard/{id}
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