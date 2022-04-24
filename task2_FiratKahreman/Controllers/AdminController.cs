using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        //Kategori sil ekle düzenle
        [HttpPost]
        public IActionResult AddCompany(Company company)
        {
            EventContext context = new EventContext();
            context.Companies.Add(company);
            context.SaveChanges();
            return Ok();
        }
        //Şehir ekle
    }
}
