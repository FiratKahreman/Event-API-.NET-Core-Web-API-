using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase 
    {
        //Etkinlik seç katılıyorum de, kontenjan doluysa uyar

        //Kayıt iptal (2 gün kalana kadar)

        //Katıldıklarını, katılmadıklarını, iptal edilenleri gör

        //Biletli etkinlik ise firmalar görüntülenir, iade de aynı
    }
}
