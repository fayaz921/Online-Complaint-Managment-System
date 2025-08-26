using OCMS.Dtos;
using OCMS.Models;
using OCMS.Common.CustomClasses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OCMS.Common.CustomClasses;

namespace OCMS.Repositories
{
    public class UserRepos
    {
        private readonly OcmsDbContext ocmsDbContext = new OcmsDbContext();

        //for adding user
        public void AddUserRepo(User user)
        {
            ocmsDbContext.Users.Add(user);

            ocmsDbContext.SaveChanges();
        }

        //for dublicate email
        public bool ExistEmail(string email)
        {
            var existuser = ocmsDbContext.Users.Any(u => u.Email == email);
            return existuser;

        }

        //for Getting all data of user and show it in table 
        public List<User> GetAllUsersRepo()
        {
            return ocmsDbContext.Users.ToList();
        }

        //for Getting specific User Status like pending and approved etc 
        public List<User> GetRecordbyrequestType(UserRequestType requestType)
        {
            return ocmsDbContext.Users.Where(u=>u.Status==(UserStatus)requestType).ToList();
        }
        public void RemoveRepo(User user)
        {
            ocmsDbContext.Users.Remove(user);
            ocmsDbContext.SaveChanges();
        }

        public User GetbyIdrepo(Guid userid)
        {
           return ocmsDbContext.Users.Where(u => u.UserId == userid).FirstOrDefault();

        }

        public bool UpdateStatusRepo(Guid userid, UserStatus status)
        {
            var userstatus = ocmsDbContext.Users.FirstOrDefault(u=>u.UserId == userid);
            if (userstatus == null)
            {
                return false;
            }
            userstatus.Status = status;
            ocmsDbContext.Users.Update(userstatus); //
            ocmsDbContext.SaveChanges();
            return true;

        }


        public User LoginCheckRepo(string Email)
        {
            return ocmsDbContext.Users.Where(e=>e.Email==Email).FirstOrDefault();
        }
    }
}