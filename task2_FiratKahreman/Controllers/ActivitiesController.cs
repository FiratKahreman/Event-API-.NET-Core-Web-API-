using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        //Katılımcılar görecek
        [HttpGet]
        public IActionResult GetActivities()
        {

            return Ok();
        }

        //Firmalar kendine tanımlıysa görecek

        //Listeleme (Filtrelenebilir)

        //Firmalar xml json çekebilir (log kaydı al)
        
        //Katılıyorum Katılmıyorum
        //Biletli Etkinlikse yönlendir

        //İade

    }
}
