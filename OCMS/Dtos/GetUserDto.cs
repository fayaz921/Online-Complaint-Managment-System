using OCMS.Common.CustomClasses;
using System;

namespace OCMS.Dtos
{
    public class GetUserDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }
        public Role? Role { get; set; }

        public string ImageLink { get; set; }
        public DateTime? CreatedAt { get; set; }

        public UserStatus? Status { get; set; }
    }
}