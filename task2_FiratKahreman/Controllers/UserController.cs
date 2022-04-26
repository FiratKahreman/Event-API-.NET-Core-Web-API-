using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using task2_FiratKahreman.DTOs;
using task2_FiratKahreman.Models;


namespace task2_FiratKahreman.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IConfiguration _configuration { get; set; }

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
        public IActionResult Login(string mail, string password, bool isOrganizer)
        {
            if (mail == "admin@etkinlik.com" && password == "sifremcokzor")
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, mail));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SymmetricSecurityKey key = new SymmetricSecurityKey(Convert.FromBase64String
                    (_configuration["JwtOptions:key"]));
                SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "www.etkinlik.com",
                    audience: "www.etkinlik.com",
                    signingCredentials: signingCredentials,
                    expires: DateTime.Now.AddHours(2),
                    claims: claims
                    );
                string adminToken = tokenHandler.WriteToken(token);

                return Ok(adminToken);
            }

            using (var context = new EventContext())
            {
                var query = from a in context.Users
                            where a.Mail == mail
                             && a.Password == password
                             && a.IsOrganizer == isOrganizer
                            select a;

                if (query != null)
                {
                    var orgstat = isOrganizer? "Organizer" : "User";
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(JwtRegisteredClaimNames.Email, mail));
                    claims.Add(new Claim(ClaimTypes.Role, orgstat));

                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SymmetricSecurityKey key = new SymmetricSecurityKey(Convert.FromBase64String
                        (_configuration["JwtOptions:key"]));
                    SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    JwtSecurityToken token = new JwtSecurityToken(
                        issuer: "www.etkinlik.com",
                        audience: "www.etkinlik.com",
                        signingCredentials: signingCredentials,
                        expires: DateTime.Now.AddHours(2),
                        claims: claims
                        );
                    string userToken = tokenHandler.WriteToken(token);

                    return Ok(userToken);
                }
                else
                {
                    return NotFound("Girilen mail veya şifre yanlış");
                }
            }
        }

        [HttpPost]
        public IActionResult CompanySignUp(Company company)
        {
            using (var context = new EventContext())
            {
                var newcompanyuser = context.Add(company);
                context.SaveChanges();
                return Ok();
            }

        }

        [HttpGet]
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
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(JwtRegisteredClaimNames.Email, mail));
                    claims.Add(new Claim(ClaimTypes.Role, "Company"));

                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SymmetricSecurityKey key = new SymmetricSecurityKey(Convert.FromBase64String
                        (_configuration["JwtOptions:key"]));
                    SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    JwtSecurityToken token = new JwtSecurityToken(
                        issuer: "www.etkinlik.com",
                        audience: "www.etkinlik.com",
                        signingCredentials: signingCredentials,
                        expires: DateTime.Now.AddHours(2),
                        claims: claims
                        );
                    string userToken = tokenHandler.WriteToken(token);
                    return Ok(token);
                }
                else
                {
                    return BadRequest("Girilen mail veya şifre yanlış");
                }
            }
        }
    }
}
