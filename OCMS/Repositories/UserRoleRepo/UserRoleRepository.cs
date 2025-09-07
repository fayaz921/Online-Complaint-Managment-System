using OCMS.Common.CustomClasses;
using OCMS.Common.CustomClasses.Data;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Repositories.UserRoleRepo
{
    public class UserRoleRepository
    {
        private readonly OcmsDbContext ocmsDbContext = new OcmsDbContext();

        // Add role for user
        public void AddUserRole(Guid userId, Role role)
        {
            var userRole = new UserRole
            {
                UserRoleId = Guid.NewGuid(),
                UserId = userId,
                Role = role
            };

            ocmsDbContext.UserRoles.Add(userRole);
            ocmsDbContext.SaveChanges();
        }

        // Get role by userId
        public Role? GetRoleByUserId(Guid userId)
        {
            return ocmsDbContext.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role)
                .FirstOrDefault();
        }

        // Update role
        public void UpdateRole(Guid userId, Role newRole)
        {
            var userRole = ocmsDbContext.UserRoles.FirstOrDefault(ur => ur.UserId == userId);
            if (userRole != null)
            {
                userRole.Role = newRole;
                ocmsDbContext.SaveChanges();
            }
        }
    }
}