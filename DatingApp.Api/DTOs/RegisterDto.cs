using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Api.DTOs
{
    public class RegisterDto {
        [Required]
        public string Username {get; set;}
        
        [Required]
        public string Password {get; set;}
    }
}