using System.Data;
using Dapper;
using ECAdminAPI.Models;
using Microsoft.Data.SqlClient;

namespace ECAdminAPI.Repositories;
public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomers();
    Task<PagedResultDto<List<Customer>>> GetAllCustomers(string CustomerId, int PageIndex = 0, int PageSize = 0);
    Task<Customer> GetCustomerById(int CustomerId);
    Task<int> AddUpdateCustomer(Customer objCustomer);
    Task<int> DeleteCustomer(int CustomerId);
}

public class CustomerRepository : ICustomerRepository
{
    private readonly DapperContext _context;
    private readonly IGridDataHelperRepository _gridDataHelperRepository;
    public CustomerRepository(DapperContext context, IGridDataHelperRepository gridDataHelperRepository)
    {
        _context = context;
        _gridDataHelperRepository = gridDataHelperRepository;
    }

    public async Task<List<Customer>> GetCustomers()
    {
        List<Customer> lstCustomers = new List<Customer>();
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            var _result = await con.QueryAsync<Customer>("p_GET_Customers", param, commandType: CommandType.StoredProcedure);
            lstCustomers = _result.ToList();
        }
        return lstCustomers;
    }
    public async Task<PagedResultDto<List<Customer>>> GetAllCustomers(string CustomerId, int PageIndex = 0, int PageSize = 0)
    {
        var objResp = new PagedResultDto<List<Customer>>();
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        List<FilterDetails> lstFilterDetail = new List<FilterDetails>();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Customers";
            DynamicParameters param = new DynamicParameters();
            if (!string.IsNullOrEmpty(CustomerId)) param.Add("@CustomerId", CustomerId);
            if (PageSize > 0) { param.Add("@PageSize", PageSize); } else { param.Add("@PageSize", null); }
            if (PageIndex > 0) { param.Add("@PageIndex", PageIndex); } else { param.Add("@PageIndex", null); }
            var result = await con.QueryAsync<Customer>(query, param, commandType: CommandType.StoredProcedure);
            if (result == null) return null;
            int count = 0;
            if (result.Count() > 0)
            {
                var elm = result.First();
                count = Convert.ToInt32(elm.TotalRowCount);
                lstColumnDetail = _gridDataHelperRepository.GetCustomersColumnDetails();
                lstFilterDetail = _gridDataHelperRepository.GetCategoriesFilterDetails();
            }
            objResp = new PagedResultDto<List<Customer>>(PageIndex, PageSize, count, result.ToList(), lstColumnDetail, lstFilterDetail);
        }
        return objResp;
    }
    public async Task<Customer> GetCustomerById(int CustomerId)
    {
        Customer objCustomer = new Customer();
        using(var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", CustomerId);
            objCustomer = await con.QueryFirstAsync<Customer>("p_GET_Customers", param, commandType: CommandType.StoredProcedure);
        }
        return objCustomer;
    }
    public async Task<int> AddUpdateCustomer(Customer objCustomer)
    {
        int result = 0;
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            if(objCustomer.CustomerId > 0) param.Add("@CustomerId", objCustomer.CustomerId);
            if (!string.IsNullOrEmpty(objCustomer.FirstName)) param.Add("@FirstName", objCustomer.FirstName);
            if (!string.IsNullOrEmpty(objCustomer.LastName)) param.Add("@LastName", objCustomer.LastName);
            if (!string.IsNullOrEmpty(objCustomer.Status)) param.Add("@Status", objCustomer.Status);
            if (!string.IsNullOrEmpty(objCustomer.Address)) param.Add("@Address", objCustomer.Address);
            if (!string.IsNullOrEmpty(objCustomer.City)) param.Add("@City", objCustomer.City);
            if (!string.IsNullOrEmpty(objCustomer.PostalCode)) param.Add("@PostalCode", objCustomer.PostalCode);
            if (!string.IsNullOrEmpty(objCustomer.State)) param.Add("@State", objCustomer.State);
            if (!string.IsNullOrEmpty(objCustomer.Country)) param.Add("@Country", objCustomer.Country);
            if (!string.IsNullOrEmpty(objCustomer.PhoneNumber)) param.Add("@PhoneNumber", objCustomer.PhoneNumber);
            if (!string.IsNullOrEmpty(objCustomer.Email)) param.Add("@Email", objCustomer.Email);
            if (!string.IsNullOrEmpty(objCustomer.Password)) param.Add("@Password", objCustomer.Password);
            param.Add("@Flag", objCustomer.Flag);
            result = await con.ExecuteScalarAsync<int>("p_AUD_Customer", param, commandType: CommandType.StoredProcedure);            
        }
        return result;
    }
    public async Task<int> DeleteCustomer(int CustomerId)
    {
        int result = 0;
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", CustomerId);
            param.Add("@Status", "inactive");
            param.Add("@Flag", 3);
            result = await con.ExecuteScalarAsync<int>("p_AUD_Customer", param, commandType: CommandType.StoredProcedure);            
        }
        return result;
    }
}