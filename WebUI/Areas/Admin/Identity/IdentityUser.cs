using System;
using Microsoft.AspNet.Identity;

namespace WebUI.Areas.Admin.Identity
{
    public class IdentityUser : IUser<int>
    {
        public IdentityUser()
        {
        }

        public IdentityUser(string userName)
        {
            this.UserName = userName;
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual string SecurityStamp { get; set; }
    }
}