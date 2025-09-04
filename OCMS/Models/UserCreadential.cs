using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OCMS.Models
{
    public class UserCreadential
    {
        [Key]
        public Guid CreadId { get; set; }
        public Guid UserId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string OTP {  get; set; } 
    }
}