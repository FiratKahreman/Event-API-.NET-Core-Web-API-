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

        //EDIT KALDI


        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            using (var context = new EventContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            using (var context = new EventContext())
            {
                Category category = context.Categories.SingleOrDefault(a => a.CategoryId == id);
                context.Categories.Remove(category);
                context.SaveChanges();
                return Ok();
            }
        }

        

        [HttpPost]
        public IActionResult AddCity(City city)
        {
            using(var context = new EventContext())
            {
                context.Cities.Add(city);
                context.SaveChanges();
                return Ok();
            }
        }
        
    }
}
