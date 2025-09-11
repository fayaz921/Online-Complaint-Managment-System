using OCMS.Models;
using OCMS.Common.CustomClasses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace OCMS.Repositories
{
    
    public class UserCreadentialRepository
    {
        private readonly OcmsDbContext ocmsDb = new OcmsDbContext();

        public void AddUserCreadential(UserCreadential userCreadential)
        {
            ocmsDb.UsersCreadentials.Add(userCreadential);
            ocmsDb.SaveChanges();
        }

        public void RemoveCreadential(UserCreadential userCreadential)
        {
            ocmsDb.UsersCreadentials.Remove(userCreadential);
            ocmsDb.SaveChanges();
        }

        public UserCreadential GetbyIDCread(Guid userid)
        {
            return ocmsDb.UsersCreadentials.Where(u => u.UserId == userid).FirstOrDefault();
        }

        public void SaveOtp(Guid userid,string otp)
        {
            var cred = ocmsDb.UsersCreadentials.Where(x=>x.UserId == userid).FirstOrDefault();
            if(cred != null)
            {
                cred.OTP = otp;
                ocmsDb.SaveChanges();
            }
        }

        public bool VerifyOtp(Guid userid,string otp)
        {
            var cred = ocmsDb.UsersCreadentials.FirstOrDefault(x => x.UserId == userid);

            if (cred == null || cred.OTP != otp)
                return false;

            // OTP matched , invalidate immediately
            cred.OTP = null;
            ocmsDb.SaveChanges();

            return true;
        }

        public void UpdatePassword(Guid userId, byte[] passwordHash, byte[] passwordSalt)
        {
            var cred = ocmsDb.UsersCreadentials.FirstOrDefault(c => c.UserId == userId);
            if (cred != null)
            {
                cred.PasswordHash = passwordHash;
                cred.PasswordSalt = passwordSalt;
                cred.OTP = null;                   // clear OTP after successful reset
                ocmsDb.SaveChanges();
            }
        }

    }
}