using System.IdentityModel.Tokens.Jwt;

public class JwtTokenHandler
{
    public Task<Guid> ExtractUserIdFromToken(string token)
    {
        token.StartsWith("Bearer ");
        token = token.Substring(7);

        var handler = new JwtSecurityTokenHandler();
        var decodedToken = handler.ReadJwtToken(token);
        var userId = decodedToken.Claims.FirstOrDefault(claim => claim.Type == "UserId")?.Value;
        if (userId != null)
        {
            return Task.FromResult(new Guid(userId));
        }
        else
        {
            throw new InvalidOperationException("UserId not found in token claims.");
        }
    }
}
