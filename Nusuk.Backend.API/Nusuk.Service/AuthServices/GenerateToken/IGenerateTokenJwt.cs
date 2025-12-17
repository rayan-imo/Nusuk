namespace Nusuk.Services.AuthServices.GenerateToken;

public interface  IGenerateTokenJwt
{
    public string GenerateAccessToken(Guid userId,  string Name,string? email = null);
}
