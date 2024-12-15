using System.Text.Json.Serialization;
namespace ECAdminAPI.Models;

public class TokenConfig
{
    [JsonPropertyName("secret")]
    public string Secret { get;set;}
    
    [JsonPropertyName("issuer")]
    public string Issuer { get;set;}

    [JsonPropertyName("audience")]
    public string Audience { get;set;}
    
    [JsonPropertyName("tokenExpirationSpan")]
    public string TokenExpirationSpan { get;set;}

    [JsonPropertyName("refreshTokenExpirationSpan")]
    public string RefreshTokenExpirationSpan{ get;set; }    
}