
using ECAdminAPI.Models;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using ECAdminAPI.Services;

namespace ECAdminAPI.Repositories;
public interface IUserRepository
{
    Task<User> ValidateUser(string UserName, string Password);
    Task<User> GetUserByUserName(string LoginName);
    Task<User> GetUserById(int UserId);
    Task<PagedResultDto<List<User>>> GetAllUsers(string UserId, int PageIndex = 0, int PageSize = 0);
    Task<int> AddUpdateUser(User objUser);
    Task<int> DeleteUser(int UserId);
    Task<List<User>> GetUsers();
}

public class UserRepository : IUserRepository
{
    private readonly ILoggerManager _logger;
    private readonly DapperContext _context;
    private readonly IGridDataHelperRepository _gridDataHelperRepository;
    public UserRepository(ILoggerManager logger, DapperContext context, IGridDataHelperRepository gridDataHelperRepository)
    {
        _logger = logger;
        _context = context;
        _gridDataHelperRepository = gridDataHelperRepository;
    }
    public async Task<User> ValidateUser(string UserName, string Password)
    {
        string logParams = "UserName: " + UserName + "|Password: " + Password;
        _logger.LogInfo("[UserRepository]|[ValidateUser]|logParams: " + logParams);
        try
        {
            using (var con = _context.CreateConnection)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Email", UserName);
                param.Add("@Password", Password);
                var result = await con.QueryFirstAsync<User>("p_GET_UserLogin", param, commandType: CommandType.StoredProcedure);
                if (result == null) return null;
                return result;
            }
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("UsersRepository->ValidateUser()->Error->", ex);
            return null;
        }
    }
    public async Task<User> GetUserByUserName(string LoginName)
    {
        string logParams = "LoginName: " + LoginName;
        _logger.LogInfo("[UserRepository]|[GetUserByUserName]|logParams: " + logParams);
        try
        {
            using (var con = _context.CreateConnection)
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Email", LoginName);
                var result = await con.QueryFirstAsync<User>("p_GET_UserLogin", param, commandType: CommandType.StoredProcedure);
                if (result == null) return null;
                return result;
            }
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("UsersRepository->ValidateUser()->Error->", ex);
            return null;
        }
    }
    public async Task<User> GetUserById(int UserId)
    {
        User objUser = new User();
        using(var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", UserId);
            objUser = await con.QueryFirstAsync<User>("p_GET_Users", param, commandType: CommandType.StoredProcedure);
        }
        return objUser;
    }
    public async Task<List<User>> GetUsers()
    {
        List<User> lstUsers = new List<User>();
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            var _result = await con.QueryAsync<User>("p_GET_Users", param, commandType: CommandType.StoredProcedure);
            lstUsers = _result.ToList();
        }
        return lstUsers;
    }
    public async Task<PagedResultDto<List<User>>> GetAllUsers(string UserId, int PageIndex = 0, int PageSize = 0)
    {
        var objResp = new PagedResultDto<List<User>>();
        string logParams = "UserId:" + UserId + "|PageIndex:" + PageIndex + "|PageSize:" + PageSize;
        _logger.LogInfo("[UsersRepository]|[GetAllUsers]|logParams: " + logParams);
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        List<FilterDetails> lstFilterDetail = new List<FilterDetails>();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Users";
            con.Open();
            DynamicParameters param = new DynamicParameters();
            if(!string.IsNullOrEmpty(UserId))param.Add("@UserId", UserId); 
            if (PageSize > 0) { param.Add("@PageSize", PageSize); } else { param.Add("@PageSize", null); }
            if (PageIndex > 0) { param.Add("@PageIndex", PageIndex); } else { param.Add("@PageIndex", null); }
            var result = await con.QueryAsync<User>(query, param,  commandType: CommandType.StoredProcedure);
            if (result == null) return null;
            int count = 0;
            if (result.Count() > 0)
            {
                var elm = result.First();
                count = Convert.ToInt32(elm.TotalRowCount);
                lstColumnDetail = _gridDataHelperRepository.GetUsersColumnDetails();
                lstFilterDetail = _gridDataHelperRepository.GetUsersFilterDetails();
            }
            objResp = new PagedResultDto<List<User>>(PageIndex, PageSize, count, result.ToList(), lstColumnDetail, lstFilterDetail);
        }
        return objResp;
    }
    public async Task<int> AddUpdateUser(User objUser)
    {
        int userId = 0;
        string logParams = "FirstName:" + objUser.FirstName + "|LastName:" + objUser.LastName + "|Email:"
        + objUser.Email + "|PhoneNumber:" + objUser.PhoneNumber + "|RefreshToken:" + objUser.RefreshToken
        + "|RefreshTokenExpiryTime:" + objUser.RefreshTokenExpiryTime + "|Flag:" + objUser.Flag;
        _logger.LogInfo("UsersRepository:AddUpdateUser:logParams: " + logParams);
        using(IDbConnection con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            if(objUser.UserId >0) param.Add("@UserId",objUser.UserId);
            if(objUser.RoleId >0) param.Add("@RoleId",objUser.RoleId);
            if(!string.IsNullOrEmpty(objUser.FirstName)) param.Add("@FirstName",objUser.FirstName);
            if(!string.IsNullOrEmpty(objUser.LastName)) param.Add("@LastName",objUser.LastName);
            if(!string.IsNullOrEmpty(objUser.Email)) param.Add("@Email",objUser.Email);
            if(!string.IsNullOrEmpty(objUser.Password)) param.Add("@Password",objUser.Password);
            if(!string.IsNullOrEmpty(objUser.PhoneNumber)) param.Add("@PhoneNumber",objUser.PhoneNumber);
            if(!string.IsNullOrEmpty(objUser.Status)) param.Add("@Status",objUser.Status);
            //if(!string.IsNullOrEmpty(objUser.RefreshToken)) param.Add("@RefreshToken",objUser.RefreshToken);
            // if(objUser.RefreshTokenExpiryTime != null) param.Add("@RefreshTokenExpiryTime",objUser.RefreshTokenExpiryTime);
            param.Add("@Flag",objUser.Flag);
            userId = await con.ExecuteScalarAsync<int>("p_AUD_Users", param, commandType:CommandType.StoredProcedure);
        }
        return userId;
    }
    public async Task<int> DeleteUser(int UserId)
    {
        int result = 0;
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@UserId", UserId);            
            param.Add("@Flag", 3);
            result = await con.ExecuteScalarAsync<int>("p_AUD_Users", param, commandType: CommandType.StoredProcedure);            
        }
        return result;
    }
}