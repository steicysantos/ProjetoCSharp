using DTO;
using Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
namespace Controller.Controllers;


[ApiController]
[Route("owner")]
public class OwnerController : ControllerBase
{
    public IConfiguration _configuration;

    public OwnerController(IConfiguration config){
        _configuration = config;
    }

    [HttpPost]
    [Route("register")]
    public object registerOwner(OwnerDTO owner)
    {
        var ownerr=Model.Owner.convertDTOToModel(owner);
        var id=ownerr.save();
        return new{
            name=owner.name,
            date_of_birth=owner.date_of_birth,
            document=owner.document,
            email=owner.email,
            phone=owner.name,
            login=owner.login,
            passwd=owner.passwd,
            address=owner.address,
            id=id
        };
    }
    [Authorize]
    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(string document)
    {
        var client=Model.Owner.find(document);
        return client;
    }


    [HttpPost]
    [Route("api")]
    public IActionResult tokenGenerate([FromBody] OwnerDTO login){
        if(login != null && login.login != null && login.passwd != null){
            var user = Model.Owner.findByUser(login.login, login.passwd);
            if(user != null){
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.id.ToString()),
                    new Claim("UserName", user.name.ToString()),
                    new Claim("Email", user.email.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["JwtAudience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }
        else
        {
            return BadRequest("Empty credentials");
        }
    }
}