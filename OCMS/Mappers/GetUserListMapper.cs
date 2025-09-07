using OCMS.Dtos;
using OCMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace OCMS.Mappers
{
    public static class GetUserListMapper
    {
        public static IEnumerable<GetUserDto> MapGetUserDto(this List<User> user)
        {
            if(user == null)
            {
                return Enumerable.Empty<GetUserDto>();
            }
             
            return user.Select(u => new GetUserDto
            {
                UserId = u.UserId,
                FullName = u.FullName,
                Email = u.Email,
                //Role = u.Role,
                ImageLink = u.ImageLink,
                Status = u.Status,
                CreatedAt = u.CreatedAt,
            });
        }


        public static GetUserDto MapGetUserDto(this User user)
        {
            if (user == null)
                return null;

            return new GetUserDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                //Role = user.Role,
                ImageLink = user.ImageLink,
                Status = user.Status,
                CreatedAt = user.CreatedAt,
            };
        }
    }
}
