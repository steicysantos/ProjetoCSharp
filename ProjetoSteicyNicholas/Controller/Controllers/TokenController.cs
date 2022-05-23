// namespace Controller.Controllers;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;
// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;

// using DTO;
// using model;

// [ApiController]
// [Route("Token")]
// public class TokenController : ControllerBase
// {
//     public IConfiguration _configuration;

//     public TokenController(IConfiguration config){
//         _configuration = config;
//     }

//     [HttpPost]
//     [Route("api")]
//     public IActionResult tokenGenerate([FromBody] LoginDTO login){
//         if(login != null && login.login != null && login.password != null){
//             var user = model.Client.findLogin(login);
//             if(user != null){
//                 var claims = new[] {
//                     new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
//                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                     new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
//                     new Claim("UserId", user.getId().ToString()),
//                     new Claim("UserName", user.getName()),
//                     new Claim("Email", user.getEmail())
//                 };

//                 var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt: Key"]));
//                 var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
//                 var token = new JwtSecurityToken(
//                     _configuration["Jwt:Issuer"],
//                     _configuration["JwtAudience"],
//                     claims,
//                     expires: DateTime.UtcNow.AddMinutes(10),
//                     signingCredentials: signIn);
//                 return Ok(new JwtSecurityTokenHandler().WriteToken(token));
//             }
//             else
//             {
//                 return BadRequest("Invalid credentials");
//             }
//         }
//         else
//         {
//             return BadRequest("Empty credentials");
//         }
//     }
// }