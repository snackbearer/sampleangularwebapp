using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using sampleangularwebapp.Security;
using sampledata.Models;
using System;
using System.Text;

namespace sampleangularwebapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            // NOTE: Not a proper implementation should build a proper dependancy injection factory
            services.AddDbContext<cmsContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:kevinangularcms"]));
            
            // Get JWT Token Settings from JwtSettings.json file
            JwtSettings settings;
            settings = GetJwtSettings();
            // Create singleton of JwtSettings
            services.AddSingleton<JwtSettings>(settings);

            // Register Jwt as the Authentication service
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters =
              new TokenValidationParameters
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(settings.Key)),
                      ValidateIssuer = true,
                      ValidIssuer = settings.Issuer,

                      ValidateAudience = true,
                      ValidAudience = settings.Audience,

                      ValidateLifetime = true,
                      ClockSkew = TimeSpan.FromMinutes(
                         settings.MinutesToExpiration)
                  };
            });

            services.AddAuthorization(cfg =>
            {
                // NOTE: The claim type and value are case-sensitive
                cfg.AddPolicy("CanAccessProducts", p => p.RequireClaim("CanAccessProducts", "true"));
                cfg.AddPolicy("CanAccessGeneral", p => p.RequireClaim("CanAccessGeneral", "true"));
            });

            services.AddCors();

            services.AddMvc()
            .AddJsonOptions(options =>
              options.SerializerSettings.ContractResolver =
            new CamelCasePropertyNamesContractResolver());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }

        public JwtSettings GetJwtSettings()
        {
            JwtSettings settings = new JwtSettings();

            settings.Key = "This*Is&A!Long)Key(For%Creating@A$SymmetricKey"; //Configuration["JwtSettings:key"];
            settings.Audience = "kevsFriends"; //Configuration["JwtSettings:audience"];
            settings.Issuer = "http://localhost"; // Configuration["JwtSettings:issuer"];
            settings.MinutesToExpiration = 10;
             //Convert.ToInt32(
              //  Configuration["JwtSettings:minutesToExpiration"]);

            return settings;
        }
    }
}
