
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
    Task<List<User>> GetUsers();
    Task<int> AddUpdateUser(User objUser);
}

public class UserRepository : IUserRepository
{
    private readonly ILoggerManager _logger;
    private readonly DapperContext _context;
    public UserRepository(ILoggerManager logger, DapperContext context)
    {
        _logger = logger;
        _context = context;
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
    public async Task<int> AddUpdateUser(User objUser)
    {
        int userId = 0;
        try
        {
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
                if(!string.IsNullOrEmpty(objUser.PhoneNumber)) param.Add("@PhoneNumber",objUser.PhoneNumber);
                if(!string.IsNullOrEmpty(objUser.Status)) param.Add("@Status",objUser.Status);
                if(!string.IsNullOrEmpty(objUser.RefreshToken)) param.Add("@RefreshToken",objUser.RefreshToken);
                if(objUser.RefreshTokenExpiryTime != null) param.Add("@RefreshTokenExpiryTime",objUser.RefreshTokenExpiryTime);
                param.Add("@Flag",objUser.Flag);
                userId = await con.ExecuteScalarAsync<int>("p_AUD_Users", param, commandType:CommandType.StoredProcedure);
            }
        }
        catch(Exception ex)
        {
            _logger.LogLocationWithException("UsersRepository->AddUpdateUser()->Error->", ex);   
        }
        return userId;
    }
}