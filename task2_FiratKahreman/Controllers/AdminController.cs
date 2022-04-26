using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {                
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCategory(Category category)
        {
            using (var context = new EventContext())
            {
                var query = (from c in context.Categories
                             where c.CategoryName == category.CategoryName
                             select c);
                if (query == null)
                {
                    context.Categories.Add(category);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Aynı isme sahip bir kategori mevcut.");
                }
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(string name)
        {
            using (var context = new EventContext())
            {
                Category category = context.Categories.SingleOrDefault(a => a.CategoryName == name);
                context.Categories.Remove(category);
                context.SaveChanges();
                return Ok();
            }
        }        

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddCity(City city)
        {
            using(var context = new EventContext())
            {
                var query = (from c in context.Cities
                             where c.CityName == city.CityName
                             select c);
                if (query == null)
                {
                    context.Cities.Add(city);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("Aynı isme sahip bir şehir mevcut.");
                }
            }
        }        
    }
}
