namespace Nusuk.Services.AuthServices.GenerateToken;

public interface  IGenerateTokenJwt
{
    public string GenerateAccessToken(Guid userId, Guid roleId, string Name,string? email = null);
}
