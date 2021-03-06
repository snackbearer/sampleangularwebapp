﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using sampledata.Data;
using sampledata.Models;

namespace sampleangularwebapp.Security
{
    public class SecurityManager
    {
        private JwtSettings _settings = null;
        private cmsContext _context;
        public SecurityManager(cmsContext context, JwtSettings settings)
        {
            _settings = settings;
            _context = context;
        }

        public AppUserAuth ValidateUser(User user)
        {
            AppUserAuth ret = new AppUserAuth();
            User authUser = null;

            using (var sec = new SecurityService(_context)) { 

                authUser = sec.GetUser(user);
            
                if (authUser != null)
                {
                    // Build User Security Object
                    ret = BuildUserAuthObject(authUser);
                }

                return ret;
            }
        }

        protected List<UserClaim> GetUserClaims(User authUser)
        {

            using (var sec = new SecurityService(_context)) { 

                return sec.GetUserClaims(authUser);

            }
        }

        protected AppUserAuth BuildUserAuthObject(User authUser)
        {
            AppUserAuth ret = new AppUserAuth();
            var claims = new List<UserClaim>();

            // Set User Properties
            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid().ToString();

            // Get all claims for this user
            ret.Claims = GetUserClaims(authUser);

            // Set JWT bearer token
            ret.BearerToken = BuildJwtToken(ret);

            return ret;
        }

        protected string BuildJwtToken(AppUserAuth authUser)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(_settings.Key));

            // Create standard JWT claims
            List<Claim> jwtClaims = new List<Claim>();
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub,
                authUser.UserName));
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString()));

            // Add custom claims
            foreach (var claim in authUser.Claims)
            {
                jwtClaims.Add(new Claim(claim.ClaimType, claim.ClaimValue));
            }

            // Create the JwtSecurityToken object
            var token = new JwtSecurityToken(
              issuer: _settings.Issuer,
              audience: _settings.Audience,
              claims: jwtClaims,
              notBefore: DateTime.UtcNow,
              expires: DateTime.UtcNow.AddMinutes(
                  _settings.MinutesToExpiration),
              signingCredentials: new SigningCredentials(key,
                          SecurityAlgorithms.HmacSha256)
            );

            // Create a string representation of the Jwt token
            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }
    }
}
