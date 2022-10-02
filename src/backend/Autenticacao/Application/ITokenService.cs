using Application.Services.Dto;

namespace Application
{
    public interface ITokenService
    {
        string GerarToken(TokenPropertiesDto usuario, string jwtSecretToken);
    }
}