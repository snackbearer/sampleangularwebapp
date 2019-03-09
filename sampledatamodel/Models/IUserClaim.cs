using System;
using System.Collections.Generic;
using System.Text;

namespace sampledatamodel.Models
{
    interface IUserClaim
    {
        int ClaimId { get; set; }
        int? UserId { get; set; }
        string ClaimType { get; set; }
        string ClaimValue { get; set; }
    }
}
