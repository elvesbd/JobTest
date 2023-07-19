using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

public class JwtTokenHandler
{
    /* private readonly string chaveSecreta;

    public JwtTokenHandler(string chaveSecreta)
    {
        this.chaveSecreta = chaveSecreta;
    } */

    public Task<string>? ExtractUserIdFromToken(string token)
    {
        if (token.StartsWith("Bearer "))
        {
            token = token.Substring(7);

            /*    var parametrosValidacao = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta)),
                   ValidateIssuer = false,
                   ValidateAudience = false
               }; */

            var handler = new JwtSecurityTokenHandler();
            try
            {
                var decodedToken = handler.ReadJwtToken(token);
                return Task.FromResult<string>(decodedToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value);
            }
            catch (SecurityTokenException)
            {
                // Token inválido ou ocorreu um erro durante a decodificação.
                return Task.FromResult<string>(null);
            }
        }

        return Task.FromResult<string>(null);
    }
}
