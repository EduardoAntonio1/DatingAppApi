using DatingApp.Api.Data;
using DatingApp.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Api.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(string username, string password)
        {
            // Ejecutar el método Dispose de la clase que estoy instanciando
            //HMACSHA512 implementa la interfaz IDisposable
            // Otras clases que implementan IDisposable: todas las que generan conexiones a BD o archivos.
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = username,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}