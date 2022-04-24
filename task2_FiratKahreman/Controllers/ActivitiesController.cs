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
        //Katılımcılar görecek OK
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

        //Firmalar kendine tanımlıysa görecek OK
        [HttpGet("{id}")]
        public IActionResult GetActivitiesByCompanyId(int id)
        {
            using (var context = new EventContext())
            {
                var query = (from c in context.Activities where c.CompanyId == id select c);
                return Ok(query);
            }
        }
        
        //Katılımcı katılıyorum derse:
        [HttpGet("{id}")]
        public IActionResult Attend(int id)
        {

            return Ok("link");
        }
        
        //Listeleme (Filtrelenebilir)
        public IActionResult GetListByCity(string city)
        {
            return Ok();
        }

        public IActionResult Refund()
        {
            return Ok();
        }
        //Firmalar xml json çekebilir (log kaydı al)


    }
}
