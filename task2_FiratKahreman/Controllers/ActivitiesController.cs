using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using task2_FiratKahreman.DTOs;
using task2_FiratKahreman.Models;

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
            EventContext context = new EventContext();
            List<ActivityDTO> activities = context.Activities
                .Select(c => new ActivityDTO()
                {
                    ActivityId = c.ActivityId,
                    ActivityDate = c.ActivityDate,
                    ActivityName = c.ActivityName,
                    Description = c.Description,
                    LastDate = c.LastDate,
                    Adress = c.Adress,
                    Limit = c.Limit,
                    NeedTicket = c.NeedTicket,
                    TicketPrice = c.TicketPrice
                }).ToList();
            return Ok(activities);
        }

        //Firmalar kendine tanımlıysa görecek

        //Listeleme (Filtrelenebilir)

        //Firmalar xml json çekebilir (log kaydı al)
        
        //Katılıyorum Katılmıyorum
        //Biletli Etkinlikse yönlendir

        //İade

    }
}
