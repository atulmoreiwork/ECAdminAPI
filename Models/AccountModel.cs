using System.ComponentModel.DataAnnotations;
namespace ECAdminAPI.Models;
public class LoginModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}

public class LoginResponse
{
    public string Token { get;set;}
    public string RefreshToken { get;set;}
}

public class TokenModel
{
    public string AccessToken { get;set;}
    public string RefreshToken { get;set;}
}