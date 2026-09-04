using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DragTrans.Application.Services.Jwt;

public class JwtService : IJwtService
{
    private readonly JwtSetting _setting;

    public JwtService(JwtSetting setting)
    {
        _setting = setting;
    }

    public string GenerateToken(Guid userId, string userName)
    {
        var claims = new[]
        {
            new Claim(
                ClaimTypes.NameIdentifier,
                userId.ToString()
            ),

            new Claim(
                ClaimTypes.Name,
                userName
            )
        };

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_setting.Key)
        );

        var credentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _setting.Issuer,
            audience: _setting.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                _setting.ExpiresMinutes
            ),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}