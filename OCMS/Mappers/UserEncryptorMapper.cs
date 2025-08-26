using OCMS.Models;
using OCMS.Common.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace OCMS.Mappers
{
    public static class UserEncryptorMapper
    {
        public static UserCreadential Map(this PasswordEncryptor passwordEncryptor, Guid userid , string password)
        {
            passwordEncryptor.CreatePasswordHashandSalt(password, out byte[] hash,out byte[] salt);

            UserCreadential userCreadential = new UserCreadential
            {
                CreadId = Guid.NewGuid(),
                UserId = userid,
                PasswordHash = hash,
                PasswordSalt = salt,
                OTP = null,
            };
            return userCreadential;

        }
    }
}