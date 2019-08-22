using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using TimeCard.Api.Services.Interfaces;
using System.Text;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace TimeCard.Api.Services {
  public class JwtTokenGeneratorOptions {
      public string Issuer { get; set; }
      public string Key { get; set; }
      public int ExpireDays { get; set; }
  }

  public class JwtTokenGenerator : IJwtTokenGenerator
  {
    private readonly JwtTokenGeneratorOptions _options;
    public DateTime Lifetime { get; set; }
    public string Audience { get; set; }

     public JwtTokenGenerator(
        IOptions<JwtTokenGeneratorOptions> optionsAccessor
    ) {
        _options = optionsAccessor.Value;
        Lifetime = DateTime.Now.AddMinutes(60 * 24 * 2); // 2 days default
        Audience = _options.Issuer;
    }

    public string GenerateToken(string userId)
    {
        return new JwtSecurityTokenHandler().WriteToken(BuildToken(new List<Claim>() {
            new Claim(JwtRegisteredClaimNames.Sub, userId)
        }));
    }

    public string GenerateToken(int userId)
    {
        return GenerateToken(userId.ToString());
    }

    private JwtSecurityToken BuildToken(IEnumerable<Claim> claims) {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: Audience,
            claims: claims,
            expires: Lifetime,
            signingCredentials: credentials
        );
    }
  }
}