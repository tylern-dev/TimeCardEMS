using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Security.Claims;
using TimeCard.Api.Services;
using TimeCard.Api.Services.Interfaces;
using TimeCard.Api.Core.Models;
using TimeCard.Api.Core.Data;
using TimeCard.Api.Core.Interfaces;
using AutoMapper;

namespace TimeCard.Api.External
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        private readonly ILogger<Startup> _logger;
        private readonly IHostingEnvironment _env;

        public IConfiguration Configuration;

        public Startup(IConfiguration configuration, ILogger<Startup> logger, IHostingEnvironment env) {
            Configuration = configuration;
            _logger = logger;
            _env = env;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                // .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.Configure<JwtTokenGeneratorOptions>(Configuration.GetSection("Jwt"));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));
            services.AddDbContext<TimeCardDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, UserRole>(options =>{
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;

            })
            .AddEntityFrameworkStores<TimeCardDbContext>()
            .AddDefaultTokenProviders();

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options => {
                var jwtConfig = Configuration.GetSection("Jwt");
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfig["Issuer"],
                    ValidateAudience = true,
                    ValidAudience = jwtConfig["Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig["Key"])),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddCors(options => {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .Build());
            });

            services.AddAuthorization(options => {
            options.AddPolicy("UserId", policy => policy.RequireClaim(ClaimTypes.NameIdentifier));
            });

            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TimeCardDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.Run(async (context) =>
            // {
            //     await context.Response.WriteAsync("Hello World!");
            // });
            app.UseCors("AllowAll");
            dbContext.Database.Migrate();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
