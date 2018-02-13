using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Domain.Entities;

namespace Sevice
{
    public class UserManagerService
    {
        private static UserManagerService instance;
        public User CurrentUser { get; private set; }
        

        private UserManagerService() 
        {
        }

        public static UserManagerService Instance
        {
            get
            {
                return instance ?? (instance = new UserManagerService());
               
            }
        }


        public bool Login(User user, string password)
        {
           
            if (user.PasswordHash == password)
            {
                CurrentUser = user;
                return true;
            }

            return false;
        }

        public User UserInContext(IUnitOfWork context)
        {
            return context.UserRepository.FindById(CurrentUser.UserId);
        }

        public bool UserInRole(string role)
        {
            return CurrentUser.Roles.Any(c => c.Name == role);
        }
    }
}
