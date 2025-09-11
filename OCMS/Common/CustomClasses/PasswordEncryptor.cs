using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OCMS.Common.CustomClasses
{
    public class PasswordEncryptor
    {
        public void CreatePasswordHashandSalt(string password,out byte[] hash, out byte[] salt)
        {
            using(var hmac= new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHashandSalt(string password, byte[] hash, byte[] salt)
        {
            using(var hmac=new HMACSHA512(salt))
            {
                var Computehash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return hash.SequenceEqual(Computehash);
            }
        }
    }
}
