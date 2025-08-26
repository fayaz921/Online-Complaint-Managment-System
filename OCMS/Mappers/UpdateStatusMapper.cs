using Microsoft.Ajax.Utilities;
using OCMS.Common.CustomClasses;
using OCMS.Dtos;
using OCMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Mappers
{
    public static class UpdateStatusMapper
    {
        public static User  UserToUpdateStatusdto(this UpdateStatusDto dto)
        {
            return new User
            {
                UserId = Guid.NewGuid(),
               Status = dto.Status,
                     
            };
        }
    }
}