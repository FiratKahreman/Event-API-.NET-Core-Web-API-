using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using task2_FiratKahreman.Models;

namespace task2_FiratKahreman
{
    public class Startup
    {
        public IConfiguration _configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddXmlDataContractSerializerFormatters();
            services.AddFluentValidation(a => a.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidAudience = "www.etkinlik.com",
                        ValidIssuer = "www.etkinlik.com",
                        ValidateAudience = true,
                        ValidateIssuer = true, //Hata verebilir!
                        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String
                        (_configuration["JwtOptions:key"]))
                    };
                });
            services.AddDbContext<EventContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("MsSQLConnection"));
            }
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();            

            app.UseRouting();

            app.UseAuthorization();
            

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
