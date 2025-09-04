using OCMS.Common.CustomClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMS.Dtos
{
    public class AddUserDto
    {
        [Required(ErrorMessage ="Please Enter FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Upload Image")]
        public HttpPostedFileBase Imagefile { get; set; }
        public string ImageUrl { get; set; }

    }
}