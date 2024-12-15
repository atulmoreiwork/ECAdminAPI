
using System.ComponentModel.DataAnnotations;
namespace ECAdminAPI.Models;

public class User
{
    public int UserId { get;set;}
    public int RoleId { get;set;}

    [Required(ErrorMessage = "Please enter name")]
    public string FirstName { get;set;}
    public string LastName { get;set;}

    [Required(ErrorMessage = "Please enter email")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",ErrorMessage = "Email is invalid")]
    public string Email { get;set;} 
    public string PhoneNumber { get;set;}
    public string Status { get;set;}  
    public string RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
    public int Flag { get;set;}
}