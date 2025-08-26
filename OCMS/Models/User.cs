using OCMS.Common.CustomClasses;
using System;

namespace OCMS.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } =string.Empty;
        public Role? Role { get; set; }

        public string ImageLink { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        
        public UserStatus? Status { get; set; }

    }
}