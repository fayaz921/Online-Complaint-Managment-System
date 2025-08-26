using OCMS.Models;
using OCMS.Common.CustomClasses.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}