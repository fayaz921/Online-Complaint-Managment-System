using OCMS.Common.CustomClasses;
using OCMS.Dtos;
using OCMS.Mappers;
using OCMS.Models;
using OCMS.Repositories;
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

        //method for registertion of user
        public int AddUser(AddUserDto addUser)
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
            return (int)OperationStatus.Success;
        }

        //Get user data service 
        public IEnumerable<GetUserDto> GetUsers(UserRequestType requestType)
        {
            if (UserRequestType.AllUsers == requestType)
            {
                var users = userRepos.GetAllUsersRepo();
                return users.MapGetUserDto();           //mapper class which convert actual model list into dto list

            }

            return userRepos.GetRecordbyrequestType(requestType).MapGetUserDto();  //calling repo and mapper for getting specific user status

        }

        //  Delete user
        public int Removeservice(Guid userid)
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


        public GetUserDto GetbyIDService(Guid userid)
        {
            return userRepos.GetbyIdrepo(userid).MapGetUserDto();
            

        }

        public bool UpdateStatusService(Guid userid, UserStatus userStatus)
        {
            return userRepos.UpdateStatusRepo(userid, userStatus);
        }


        public GetUserDto LoginCheckService(UserLoginDto userLoginDto, out OperationStatus operationStatus)
        {
            var UserGet = userRepos.LoginCheckRepo(userLoginDto.Email);
            if (UserGet != null)
            {
                var userCreads = usercread.GetbyIDCread(UserGet.UserId);

                if (PasswordEncryptor.VerifyPasswordHashandSalt(userLoginDto.Password, userCreads.PasswordHash, userCreads.PasswordSalt))
                {
                    operationStatus = OperationStatus.Success;

                    return UserGet.MapGetUserDto();
                }
            }
            operationStatus = OperationStatus.Failure;
            return null;
        }

    }
}
