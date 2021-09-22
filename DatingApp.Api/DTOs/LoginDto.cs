using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Api.DTOs
{
    public class LoginDto {
        
        public string Username {get; set;}
        
        public string Password {get; set;}
    }
}