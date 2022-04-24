using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase 
    {
        //Etkinlik seç katılıyorum de, kontenjan doluysa uyar
        [HttpGet("{id}")]
        public IActionResult Attend(int id)
        {

            //Kontenjan doluysa uyar
            //
            return Ok("biletliyse link");
        }

        //Kayıt iptal (2 gün kalana kadar)
        public IActionResult Refund()
        {
            //iki gün kalana kadar
            //
            return Ok("biletliyse link");
        }

        //Katıldıklarını, katılmadıklarını, iptal edilenleri gör

        
    }
}
