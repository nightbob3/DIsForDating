using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DatiingApp.API.Data;
using DatiingApp.API.Dtos;
using DatiingApp.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatiingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _repo;
        private readonly IConfiguration _config;
        private readonly IMapper _map;

        public AuthController(IAuthRepo repo, IConfiguration config, IMapper map)
        {
            _repo = repo;
            _config = config;
            _map = map;
        }


        [HttpPost("Register")]

        public async Task<IActionResult> Register(UserForRegisterDto userForRegister)
        {
            // validate request under construction

            
            userForRegister.Username = userForRegister.Username.ToLower();

            if(await _repo.UserExists(userForRegister.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToCreate = _map.Map<User>(userForRegister);
            

            var createdUser = await _repo.Register(userToCreate, userForRegister.Password);

            var userToReturn = _map.Map<UserForDetailedDto>(createdUser);

            return CreatedAtRoute("GetUser", new {controller = "Users", id = createdUser.Id}, userToReturn);
            
        }
        
        [HttpPost("Login")]

        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            
            var userFromRepo = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);
            

            if(userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username),
                new Claim(ClaimsIdentity.DefaultIssuer, "Your dad luvved me <3")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(_config.GetSection("Appsettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims), 
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var user = _map.Map<UserForListDto>(userFromRepo);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token),
                user
            });
            
            

        }
    }
}