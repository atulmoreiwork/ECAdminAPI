using System.Net;
using Microsoft.AspNetCore.Mvc;
using ECAdminAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using ECAdminAPI.Models;
using ECAdminAPI.Services;

namespace ECAdminAPI.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly ILoggerManager _logger;
	private readonly IUserRepository _usersRepository;
    public UsersController(IUserRepository userrepository, ILoggerManager logger)
	{
        _logger = logger;
		_usersRepository = userrepository;
    }
    
    [HttpGet("GetUsers")]
    public async Task<APIResponse<List<User>>> GetUsers()
    {
        List<User> lstUser = new List<User>();
        try
        {
            lstUser = await _usersRepository.GetUsers();
            return new APIResponse<List<User>>(lstUser, "Users retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("UsersController => GetCustomers =>", ex);
            return new APIResponse<List<User>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("GetAllUsers")]
    public async Task<APIResponse<PagedResultDto<List<User>>>> GetAllUsers([FromBody] GridFilter objFilter)
    {
        try
        {
            _logger.LogInfo("[UsersController]|[GetAllUsers]|[Start] => Get All users records.");
            string UserId = string.Empty; 
            if (objFilter == null)
            {
                ModelState.AddModelError("GridFilter", "Grid Filter object are null");
            return new APIResponse<PagedResultDto<List<User>>>(HttpStatusCode.BadRequest, "Grid filter object is null", ModelState.AllErrors(), true);
            }
            if (objFilter != null && objFilter.Filter != null && objFilter.Filter.Count > 0)
            {
                var _filter = objFilter.Filter.Find(x => x.ColId.ToLower() == "userid");
                if (_filter != null && !string.IsNullOrEmpty(_filter.Value)) { UserId = _filter.Value; }
            }
            var lstUser = await _usersRepository.GetAllUsers(UserId, objFilter.PageNumber, objFilter.PageSize);
            return new APIResponse<PagedResultDto<List<User>>>(lstUser, "Users retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("UsersController => GetAllUsers =>", ex);
            return new APIResponse<PagedResultDto<List<User>>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("GetUserById")]
    public  async Task<APIResponse<User>> GetUserById(int UserId)
    {
        _logger.LogInfo("[UsersController]|[GetUserById]|[Start] => Get user by id.");
        if (UserId == 0)
        {
           ModelState.AddModelError("UserId", "Please provide userid");
           return new APIResponse<User>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
        }
        var result =  await _usersRepository.GetUserById(UserId);
        return new APIResponse<User>(result, "User retrived successfully.");
    }
    
    [HttpPost("AddUpdateUser")]
    public async Task<APIResponse<int>> AddUpdateUser([FromBody] User objModel)
    {
        int result = 0;
        try
        {
            if (!ModelState.IsValid)
            {
                return new APIResponse<int>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
            }
            if (objModel.UserId <= 0) { objModel.Flag = 1; }
            else { objModel.Flag = 2; }
            result = await _usersRepository.AddUpdateUser(objModel);
            return new APIResponse<int>(result, "User created successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("UsersController => AddUser =>", ex);
            return new APIResponse<int>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("DeleteUserById")]
    public async Task<APIResponse<int>> DeleteUserById(int UserId)
    {
        _logger.LogInfo("[UsersController]|[DeleteUserById]|[Start] => DeleteUserById => UserId: " + UserId);
        if (UserId <= 0)
        {
            ModelState.AddModelError("UserId", "Please enter UserId");
            return new APIResponse<int>(HttpStatusCode.BadRequest,"Validation Error",ModelState.AllErrors(),true);
        }
        var result = await _usersRepository.DeleteUser(UserId);
         string successMessage = "User deleted successfully";
        return new APIResponse<int>(result, successMessage);
    }    
}