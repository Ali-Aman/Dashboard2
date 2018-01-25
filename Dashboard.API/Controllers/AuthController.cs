
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Dashboard.API.Data;
using Dashboard.API.DTOs;
using Dashboard.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;

namespace Dashboard.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
      
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;           
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDTo userForRegisterDTo){

            userForRegisterDTo.Username = userForRegisterDTo.Username.ToLower();

            if(await _repo.UserExits(userForRegisterDTo.Username))
                ModelState.AddModelError("Username","Username is already taken");
            
            if(!ModelState.IsValid){

                return BadRequest(ModelState); 
            }
            var newUser = new User
            {
                Username = userForRegisterDTo.Username
            };
            
            var createdUser = await _repo.Register(newUser, userForRegisterDTo.Password);
            return StatusCode(201);
        }

         [HttpPost("Login")]
         public async Task<IActionResult> Login([FromBody]UserForRegisterDTo userForRegisterDTo)
         {

            var userFromRepo = await _repo.Login(userForRegisterDTo.Username, userForRegisterDTo.Password);
            
            if(userFromRepo == null){

                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("Here is key");
            var TokenDescriptor = new SecurityTokenDescriptor
            {                
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Name, userFromRepo.Username)

                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = 
                new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(TokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok( new {tokenString});
            
        }
    }
}