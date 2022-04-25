using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using task2_FiratKahreman.DTOs;
using task2_FiratKahreman.Models;


namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            using (var context = new EventContext())
            {
                var newuser = context.Add(user);
                context.SaveChanges();
                return Ok();
            }
            
        }

        [HttpGet]
        public IActionResult Login(string mail, string password)
        {
            using (var context = new EventContext())
            {
                var query = from a in context.Users
                where a.Mail == mail
                 && a.Password == password
                select a;

                if(query.Any())
                {
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SymmetricSecurityKey key = new SymmetricSecurityKey(Convert.FromBase64String
                        ("dandanlangididandansamsakdovecii"));
                    return Ok("Giriş Başarılı");
                }
                else
                {
                    return BadRequest("Hatalı giriş");
                }
            }            
        }

        [HttpGet]
        public IActionResult CompanySignUp(Company company)
        {
            using (var context = new EventContext())
            {
                var newcompanyuser = context.Add(company);
                context.SaveChanges();
                return Ok();
            }
            
        }

        public IActionResult CompanyLogin(string mail, string password)
        {
            using (var context = new EventContext())
            {
                var query = (from a in context.Companies
                            where a.CompanyMail == mail
                             && a.CompanyPassword == password
                            select a);

                if (query != null)
                {
                    return Ok("Şirket girişi Başarılı");
                }
                else
                {
                    return BadRequest("Hatalı giriş");
                }
            }
        }
    }
}
