using OCMS.Common.CustomClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMS.Models
{
    public class UserRole
    {
        [Key] 
        public Guid UserRoleId { get; set; }
        public Guid UserId { get; set; }
        public Role? Role { get; set; }
    }
}