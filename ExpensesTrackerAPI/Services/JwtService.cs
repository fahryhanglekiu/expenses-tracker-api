using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExpensesTrackerAPI.Entities;
using ExpensesTrackerAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesTrackerAPI.Services;

public class JwtService : IJwtService
{
    private readonly IConfiguration _config;

    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Name, user.Username), // Name claim name
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()), // Subject claim name, this is must have
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}