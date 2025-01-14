
using System.ComponentModel.DataAnnotations;
namespace ECAdminAPI.Models;
public class Role
{
    public int RoleId { get;set;}
    public string RoleName { get;set;}
    public string RoleDescription { get;set;}
    public int Flag { get; set; }
    public string Row { get; set; }
    public string TotalRowCount { get; set; }
}