
using ECAdminAPI.Models;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using ECAdminAPI.Services;

namespace ECAdminAPI.Repositories;
public interface IRoleRepository
{
    Task<List<Role>> GetRoles();
    Task<Role> GetRoleById(int RoleId);
    Task<PagedResultDto<List<Role>>> GetAllRoles(string RoleId, int PageIndex = 0, int PageSize = 0);
    Task<int> AddUpdateRole(Role objRole);
    Task<int> DeleteRole(int RoleId);   
}

public class RoleRepository : IRoleRepository
{
    private readonly ILoggerManager _logger;
    private readonly DapperContext _context;
    private readonly IGridDataHelperRepository _gridDataHelperRepository;
    public RoleRepository(ILoggerManager logger, DapperContext context, IGridDataHelperRepository gridDataHelperRepository)
    {
        _logger = logger;
        _context = context;
        _gridDataHelperRepository = gridDataHelperRepository;
    }
    public async Task<Role> GetRoleById(int RoleId)
    {
        Role objRole = new Role();
        using(var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RoleId", RoleId);
            objRole = await con.QueryFirstAsync<Role>("p_GET_Roles", param, commandType: CommandType.StoredProcedure);
        }
        return objRole;
    }
    public async Task<List<Role>> GetRoles()
    {
        List<Role> lstRoles = new List<Role>();
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            var _result = await con.QueryAsync<Role>("p_GET_Roles", param, commandType: CommandType.StoredProcedure);
            lstRoles = _result.ToList();
        }
        return lstRoles;
    }
    public async Task<PagedResultDto<List<Role>>> GetAllRoles(string RoleId, int PageIndex = 0, int PageSize = 0)
    {
        var objResp = new PagedResultDto<List<Role>>();
        string logParams = "RoleId:" + RoleId + "|PageIndex:" + PageIndex + "|PageSize:" + PageSize;
        _logger.LogInfo("[RoleRepository]|[GetAllRoles]|logParams: " + logParams);
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        List<FilterDetails> lstFilterDetail = new List<FilterDetails>();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Roles";
            con.Open();
            DynamicParameters param = new DynamicParameters();
            if(!string.IsNullOrEmpty(RoleId))param.Add("@RoleId", RoleId); 
            if (PageSize > 0) { param.Add("@PageSize", PageSize); } else { param.Add("@PageSize", null); }
            if (PageIndex > 0) { param.Add("@PageIndex", PageIndex); } else { param.Add("@PageIndex", null); }
            var result = await con.QueryAsync<Role>(query, param,  commandType: CommandType.StoredProcedure);
            if (result == null) return null;
            int count = 0;
            if (result.Count() > 0)
            {
                var elm = result.First();
                count = Convert.ToInt32(elm.TotalRowCount);
                lstColumnDetail = _gridDataHelperRepository.GetRolesColumnDetails();
                lstFilterDetail = _gridDataHelperRepository.GetRolesFilterDetails();
            }
            objResp = new PagedResultDto<List<Role>>(PageIndex, PageSize, count, result.ToList(), lstColumnDetail, lstFilterDetail);
        }
        return objResp;
    }
    public async Task<int> AddUpdateRole(Role objRole)
    {
        int userId = 0;
        string logParams = "RoleName:" + objRole.RoleName + "|Flag:" + objRole.Flag;
        _logger.LogInfo("RoleRepository:AddUpdateRole:logParams: " + logParams);
        using(IDbConnection con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
             if(objRole.RoleId >0) param.Add("@RoleId", objRole.RoleId);
            if(!string.IsNullOrEmpty(objRole.RoleName)) param.Add("@RoleName", objRole.RoleName);
            if(!string.IsNullOrEmpty(objRole.RoleDescription)) param.Add("@RoleDescription",objRole.RoleDescription);
            param.Add("@Flag",objRole.Flag);
            userId = await con.ExecuteScalarAsync<int>("p_AUD_Roles", param, commandType:CommandType.StoredProcedure);
        }
        return userId;
    }
    public async Task<int> DeleteRole(int RoleId)
    {
        int result = 0;
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@RoleId", RoleId);            
            param.Add("@Flag", 3);
            result = await con.ExecuteScalarAsync<int>("p_AUD_Roles", param, commandType: CommandType.StoredProcedure);            
        }
        return result;
    }
}