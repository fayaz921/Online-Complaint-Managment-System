using OCMS.Dtos;
using OCMS.Models;
using System;
using OCMS.Common.CustomClasses;

namespace OCMS.Mappers
{
    public static class AddUserMapper
    {
        public static User AddUserDtotoUser(this AddUserDto Dto)
        {
            User user = new User
            {
                UserId = Guid.NewGuid(),
                FullName= Dto.FirstName+" "+Dto.LastName,
                Email= Dto.Email,
                Role = Role.User,
                ImageLink = Dto.ImageUrl,
                CreatedAt = DateTime.Now.Date,
                Status = UserStatus.Pending,
            };
            return user;
        }
    }
}
