using OCMS.Common.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OCMS.Dtos
{
    public class AddUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public HttpPostedFileBase Imagefile { get; set; }
        public string ImageUrl { get; set; }

        public UserStatus? Status { get; set; }

    }
}