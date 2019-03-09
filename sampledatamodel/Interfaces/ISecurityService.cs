using sampledatamodel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace sampledatamodel.Interfaces
{
    interface ISecurityService
    {
        
        IUser GetUser(IUser user);

        List<IUserClaim> GetUserClaims(IUser authUser);
        
    }
}
