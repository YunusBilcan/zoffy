using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly List<Category> _categories;

        public CategoryController()
        {
            // Initialize the list of categories
            _categories = new List<Category>
            {
                new Category { Id = 1, Name = "Category 1" },
                new Category { Id = 2, Name = "Category 2" },
                new Category { Id = 3, Name = "Category 3" }
            };
        }

        // GET api/category
        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            return Ok(_categories);
        }

        // GET api/category/{id}
        [HttpGet("{id}")]
        public ActionResult<Category> Get(int id)
        {
            var category = _categories.Find(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST api/category
        [HttpPost]
        public ActionResult<Category> Post([FromBody] Category category)
        {
            // Generate a new unique ID for the category
            int newId = _categories.Count + 1;
            category.Id = newId;

            _categories.Add(category);

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        // PUT api/category/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Category category)
        {
            var existingCategory = _categories.Find(c => c.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            existingCategory.Name = category.Name;

            return NoContent();
        }

        // DELETE api/category/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var category = _categories.Find(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _categories.Remove(category);

            return NoContent();
        }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}