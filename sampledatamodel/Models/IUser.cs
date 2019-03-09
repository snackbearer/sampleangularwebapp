using System;
using System.Collections.Generic;
using System.Text;

namespace sampledatamodel.Models
{
    interface IUser
    {
        int UserId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
    }
}
