using System;
using System.Collections.Generic;
using System.Text;

namespace sampledata.Models
{
    public class AppUserAuth
    {
        public AppUserAuth() : base()
        {
            UserName = "Not authorized";
            BearerToken = string.Empty;
        }

        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }

        public List<UserClaim> Claims { get; set; }
    }
}
