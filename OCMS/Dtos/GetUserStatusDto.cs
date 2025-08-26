using OCMS.Common.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Dtos
{
    public class GetUserStatusDto
    {
        public Guid UserId { get; set; }
        public string Status { get; set; }
    }
}