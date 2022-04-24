using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using task2_FiratKahreman.DTOs;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Login
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            using (var context = new EventContext())
            {
                var newuser = context.Add(user);
                context.SaveChanges();
            }
            return Ok();
        }

        public IActionResult Login(User user)
        {
            using (var context = new EventContext())
            {
                List<UserLoginDTO> newuser = context.Users.Select(c => new UserLoginDTO() { LoginMail = c.Mail, LoginPassword = c.Password }).ToList();                                                      

            }
            return Ok();
        }

        //Sign Up
    }
}
