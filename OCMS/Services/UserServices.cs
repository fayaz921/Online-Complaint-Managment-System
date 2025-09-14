using OCMS.Common.CustomClasses;
using OCMS.Dtos;
using OCMS.Mappers;
using OCMS.Models;
using OCMS.Repositories;
using OCMS.Repositories.UserRoleRepo;
using System;
using System.Collections.Generic;
using System.IdentityModel.Protocols.WSTrust;

namespace OCMS.Services
{
    public class UserServices
    {
        //calling userrepo and usercreadrepo

        PasswordEncryptor PasswordEncryptor = new PasswordEncryptor();
        private readonly UserRepos userRepos = new UserRepos();
        private readonly UserCreadentialRepository usercread = new UserCreadentialRepository();  //usercreadentials repo will separate it later
        private readonly UserRoleRepository userRoleRepository = new UserRoleRepository();
        //method for registertion of user
        public int AddUser(AddUserDto addUser)
        {
            try
            {

                //checking email
                var result = userRepos.ExistEmail(addUser.Email);
                if (result)
                {
                    return (int)OperationStatus.EmailDuplicate;            //if email already exist it will stop here
                }

                //logic
                //for user
                var UserDomain = addUser.AddUserDtotoUser();
                //for usercreadentials

                var UserCreadDomain = PasswordEncryptor.Map(UserDomain.UserId, addUser.Password);
                //repo
                userRepos.AddUserRepo(UserDomain);
                usercread.AddUserCreadential(UserCreadDomain);
                userRoleRepository.AddUserRole(UserDomain.UserId, Role.User);

                return (int)OperationStatus.Success;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get user data service 
        //public IEnumerable<GetUserDto> GetUsers(UserRequestType requestType)
        //{
        //    if (UserRequestType.AllUsers == requestType)
        //    {
        //        var users = userRepos.GetAllUsersRepo();
        //        return users.MapGetUserDto();           //mapper class which convert actual model list into dto list

        //    }

        //    return userRepos.GetRecordbyrequestType(requestType).MapGetUserDto();  //calling repo and mapper for getting specific user status

        //}

        public IEnumerable<GetUserDto> GetUsers(UserRequestType requestType)
        {
            try
            {

                if (UserRequestType.AllUsers == requestType)
                {
                    return userRepos.GetAllUsersRepo();
                }

                return userRepos.GetRecordbyrequestType(requestType);
            }
            catch (Exception)
            {
                throw;
            }
        }


        //  Delete user
        public int Removeservice(Guid userid)
        {
            try
            {

                var user = userRepos.GetbyIdrepo(userid);           //get user from repo
                if (user == null)                                  //if id is null return false and stop here, so user will not be deleted
                {
                    return (int)OperationStatus.Failure;
                }

                var userCreadential = usercread.GetbyIDCread(userid);     //get creadential for creadrepo by id 
                if (userCreadential == null)
                {
                    return (int)OperationStatus.Failure;
                }

                //remove user 
                userRepos.RemoveRepo(user);
                usercread.RemoveCreadential(userCreadential);
                return (int)OperationStatus.Success;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public GetUserDto GetbyIDService(Guid userid)
        {
            try
            {

                return userRepos.GetbyIdrepo(userid).MapGetUserDto();
            }
            catch (Exception)
            {
                throw;
            }


        }

        public bool UpdateStatusService(Guid userid, UserStatus userStatus)
        {
            try
            {

                return userRepos.UpdateStatusRepo(userid, userStatus);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public GetUserDto LoginCheckService(UserLoginDto userLoginDto, out OperationStatus operationStatus)
        {
            try
            {

                var UserGet = userRepos.LoginCheckRepo(userLoginDto.Email);
                if (UserGet != null)
                {
                    var userCreads = usercread.GetbyIDCread(UserGet.UserId);

                    if (PasswordEncryptor.VerifyPasswordHashandSalt(userLoginDto.Password, userCreads.PasswordHash, userCreads.PasswordSalt))
                    {
                        var role = userRoleRepository.GetRoleByUserId(UserGet.UserId);

                        operationStatus = OperationStatus.Success;

                        return new GetUserDto
                        {
                            UserId = UserGet.UserId,
                            FullName = UserGet.FullName,
                            Email = UserGet.Email,
                            Role = role,
                            ImageLink = UserGet.ImageLink,
                            Status = UserGet.Status,
                            CreatedAt = UserGet.CreatedAt
                        };
                        //operationStatus = OperationStatus.Success;

                        //return UserGet.MapGetUserDto();
                    }
                }
                operationStatus = OperationStatus.Failure;
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GetUserDto GetUserByEmail(string email)
        {
            try
            {

                return userRepos.LoginCheckRepo(email).MapGetUserDto();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void SaveOtp(Guid userid, string otp)
        {
            try
            {

                usercread.SaveOtp(userid, otp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool VerifyOtp(Guid userid, string otp)
        {
            try
            {

                return usercread.VerifyOtp(userid, otp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdatePassword(Guid userid, string newpassword)
        {
            try
            {

                PasswordEncryptor.CreatePasswordHashandSalt(newpassword, out byte[] hash, out byte[] salt);
                usercread.UpdatePassword(userid, hash, salt);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
