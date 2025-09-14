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
            try
            {
                ocmsDbContext.Users.Add(user);

                ocmsDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //for dublicate email
        public bool ExistEmail(string email)
        {
            try
            {
                var existuser = ocmsDbContext.Users.Any(u => u.Email == email);
                return existuser;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //for Getting all data of user and show it in table 
        //public List<User> GetAllUsersRepo()
        //{
        //    return ocmsDbContext.Users.ToList();
        //}

        public List<GetUserDto> GetAllUsersRepo()
        {
            try
            {
                var result = (from u in ocmsDbContext.Users
                              join ur in ocmsDbContext.UserRoles
                              on u.UserId equals ur.UserId
                              select new GetUserDto
                              {
                                  UserId = u.UserId,
                                  FullName = u.FullName,
                                  Email = u.Email,
                                  Role = ur.Role,    // ✅ coming from UserRole table
                                  ImageLink = u.ImageLink,
                                  Status = u.Status,
                                  CreatedAt = u.CreatedAt
                              }).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //for Getting specific User Status like pending and approved etc 
        //public List<User> GetRecordbyrequestType(UserRequestType requestType)
        //{
        //    return ocmsDbContext.Users.Where(u=>u.Status==(UserStatus)requestType).ToList();
        //}

        public List<GetUserDto> GetRecordbyrequestType(UserRequestType requestType)
        {
            try
            {
                var result = (from u in ocmsDbContext.Users
                              join ur in ocmsDbContext.UserRoles
                              on u.UserId equals ur.UserId
                              where u.Status == (UserStatus)requestType
                              select new GetUserDto
                              {
                                  UserId = u.UserId,
                                  FullName = u.FullName,
                                  Email = u.Email,
                                  Role = ur.Role,
                                  ImageLink = u.ImageLink,
                                  Status = u.Status,
                                  CreatedAt = u.CreatedAt
                              }).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void RemoveRepo(User user)
        {
            try
            {
                ocmsDbContext.Users.Remove(user);
                ocmsDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetbyIdrepo(Guid userid)
        {
            try
            {
                return ocmsDbContext.Users.Where(u => u.UserId == userid).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateStatusRepo(Guid userid, UserStatus status)
        {
            try
            {
                var userstatus = ocmsDbContext.Users.FirstOrDefault(u => u.UserId == userid);
                if (userstatus == null)
                {
                    return false;
                }
                userstatus.Status = status;
                ocmsDbContext.Users.Update(userstatus); //
                ocmsDbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public User LoginCheckRepo(string Email)
        {
            try
            {
                return ocmsDbContext.Users.Where(e => e.Email == Email).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}