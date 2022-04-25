using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        //Etkinlik tanımlama
        [HttpPost]
        public IActionResult AddEvent(Activity activity)
        {
            EventContext context = new EventContext();
            context.Activities.Add(activity);
            context.SaveChanges();
            return Ok();
        }
        //Etkinlik Düzenleme

        
        
    }
}
