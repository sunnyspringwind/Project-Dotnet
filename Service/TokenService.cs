using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using wandermate_backend.Models;
using wandermate_backend.Interface;


namespace wandermate_backend.Service
{
  public class TokenService : ITokenService
  {
    private readonly IConfiguration _config;    //iconfig is a direct access to the configuration of the app
    private readonly SymmetricSecurityKey _key;    //symmetric security key is a key that is used to encrypt and decrypt the token
    public TokenService(IConfiguration config)       //constructor injection means that the class is injected into the constructor directly
    {
      _config = config;
      _key = new SymmetricSecurityKey(Encoding.UTF8
      .GetBytes(_config["JWT:SigningKey"]));
    }

    public string CreateToken(AppUser user)
    {
      var claims = new List<Claim>
          /*claims are user information that is stored in the token*/
          {
            new Claim(JwtRegisteredClaimNames.NameId, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
          };

      var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

      var tokenDescriptor = new SecurityTokenDescriptor
      /*token descriptor is the token that is created*/
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddMinutes(1),
        SigningCredentials = creds,
        Issuer = _config["JWT:Issuer"],
        Audience = _config["JWT:Audience"]
      };

      var tokenHandler = new JwtSecurityTokenHandler();   //class that handles the token

      var token = tokenHandler.CreateToken(tokenDescriptor);  //creates the token

      return tokenHandler.WriteToken(token);  //converts the token to a string and returns it

    }
  }
}


