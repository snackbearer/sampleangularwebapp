using sampledata.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace sampledata.Data
{
    public class SecurityService : IDisposable
    {
        
        private cmsContext _context;
        public SecurityService(cmsContext context)
        {
            _context = context;
            
        }

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }

        public User GetUser(User user)
        {
         
            return _context.User.Where(
                u => u.UserName.ToLower() == user.UserName.ToLower()
                && u.Password == user.Password).FirstOrDefault();
            
        }

        public List<UserClaim> GetUserClaims(User authUser)
        {
            
            return _context.UserClaim.Where(
                            u => u.UserId == authUser.UserId).ToList();
             
        }
        
        
    }
}
