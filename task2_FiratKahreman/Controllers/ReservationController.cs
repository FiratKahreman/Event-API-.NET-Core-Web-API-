using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task2_FiratKahreman.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using task2_FiratKahreman.DTOs;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase 
    {
        
        [HttpGet("{id}")]
        public IActionResult Attend(int eventId,int userId)
        {
            using (var context = new EventContext())
            {                         
                var activity = context.Activities.Where(q => q.ActivityId == eventId).Include(b => b.AttendedUsers).First();
                
                if(activity.AttendedUsers.Count() < activity.Limit)
                {
                    User attendedUser = context.Users.First(a => a.UserId == userId);
                    activity.AttendedUsers.Add(attendedUser);                    
                   
                    if (activity.NeedTicket)
                    {                        
                        List<TicketSellerDTO> ticketSellers = (from a in context.Activities
                                                               join b in context.Companies on a.CompanyId equals b.CompanyId                                                               
                                                               where a.ActivityId == eventId

                                                               select new TicketSellerDTO
                                                               {
                                                                   ActivityId = a.ActivityId,
                                                                   TicketSeller = b.CompanyName,
                                                                   TicketSellerWeb = b.CompanyWeb
                                                               }).ToList();
                        context.SaveChanges();
                        return Ok(ticketSellers);
                    }
                    else
                    {
                        context.SaveChanges();
                        return Ok();
                    }                    
                }   
                else
                {
                    return BadRequest("Maalesef etkinlik kontenjanı dolmuştur.");
                }
            }                               
        }

        //Kayıt iptal (2 gün kalana kadar)
        public IActionResult Refund(int eventId, int userId)
        {
            using (var context = new EventContext())
            {
                var activity = context.Activities.Where(q => q.ActivityId == eventId).Include(b => b.AttendedUsers).First();
                
                    if (activity.NeedTicket)
                    {
                        User attendedUser = context.Users.First(a => a.UserId == userId);
                        activity.AttendedUsers.Add(attendedUser);
                        context.SaveChanges();
                        List<TicketSellerDTO> ticketSellers = (from a in context.Activities
                                                               join b in context.Companies on a.CompanyId equals b.CompanyId
                                                               where a.ActivityId == eventId

                                                               select new TicketSellerDTO
                                                               {
                                                                   ActivityId = a.ActivityId,
                                                                   TicketSeller = b.CompanyName,
                                                                   TicketSellerWeb = b.CompanyWeb
                                                               }).ToList();
                        return Ok(ticketSellers);
                    }
                    else
                    {
                        User attendedUser = context.Users.First(a => a.UserId == userId);
                        activity.AttendedUsers.Add(attendedUser);
                        context.SaveChanges();
                        return Ok("biletliyse link");
                    }

                
                
            }
            //iki gün kalana kadar
            
        }

        //Katıldıklarını, katılmadıklarını, iptal edilenleri gör

        
    }
}
