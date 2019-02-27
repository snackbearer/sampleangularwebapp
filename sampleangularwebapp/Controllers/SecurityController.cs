using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using sampleangularwebapp.Security;

using sampledata.Models;

namespace sampleangularwebapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : Controller
    {
        private readonly IConfiguration configuration;
        private string connectionString;

        private JwtSettings _settings;
        public SecurityController(IConfiguration Configuration, JwtSettings settings)
        {
            this.configuration = Configuration;
            this.connectionString = this.configuration.GetConnectionString("kevinangularcms");

            _settings = settings;
        }

            
        [HttpGet("test")]
        public string test()
        {
            return "test";
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody]User user)
        {
            IActionResult ret = null;
            try
            {
                AppUserAuth auth = new AppUserAuth();
                SecurityManager mgr = new SecurityManager(this.connectionString, _settings);
            
                auth = mgr.ValidateUser(user);
                if (auth.IsAuthenticated)
                {
                    ret = StatusCode(StatusCodes.Status200OK, auth);
                }
                else
                {
                    ret = StatusCode(StatusCodes.Status404NotFound,
                                     "Invalid User Name/Password. dsd " + this.connectionString);
                }
                } catch(Exception ex)
                {
                    ret = StatusCode(StatusCodes.Status404NotFound,
                                     "Error with Login " + ex.Message);
            }

            return ret;
        }
    }
}