using System.Data;
using Dapper;
using ECAdminAPI.Models;
namespace ECAdminAPI.Repositories;

public interface IShippingAddressRepository
{
    Task<List<ShippingAddress>> GetAllShippingAddress();
    Task<ShippingAddress> GetShippingAddressById(int shippingAddressId);
    Task<ShippingAddress> GetShippingAddressByCustomerId(int customerId);
    Task<OrderShippingAddress> GetOrderShippingAddress(int orderId, int shippingAddressId);
    Task<int> AddUpdateShippingAddress(ShippingAddress objShippingAddress);
    Task<int> AddUpdateOrderShippingAddress(OrderShippingAddress objOrderShippingAddress);
}

public class ShippingAddressRepository : IShippingAddressRepository
{
    private readonly DapperContext _context;
    public ShippingAddressRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<List<ShippingAddress>> GetAllShippingAddress()
    {
        List<ShippingAddress> lstShippingAddress = new List<ShippingAddress>();
        using(var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            var _result = await con.QueryAsync<ShippingAddress>("p_GET_ShippingAddress", param, commandType:CommandType.StoredProcedure);
            lstShippingAddress  = _result.ToList();
        }
        return lstShippingAddress;
    }
    public async Task<ShippingAddress> GetShippingAddressById(int shippingAddressId)
    {
        ShippingAddress objShippingAddress = new ShippingAddress();
        using(var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ShippingAddressId", shippingAddressId);
            objShippingAddress= await con.QueryFirstAsync<ShippingAddress>("p_GET_ShippingAddress", param, commandType:CommandType.StoredProcedure);           
        }
        return objShippingAddress;
    }
    public async Task<ShippingAddress> GetShippingAddressByCustomerId(int customerId)
    {
        ShippingAddress objShippingAddress = new ShippingAddress();
        using(var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CustomerId", customerId);
            objShippingAddress= await con.QueryFirstAsync<ShippingAddress>("p_GET_ShippingAddressByCustomerId", param, commandType:CommandType.StoredProcedure);           
        }
        return objShippingAddress;
    }
    public async Task<OrderShippingAddress> GetOrderShippingAddress(int orderId, int shippingAddressId)
    {
        OrderShippingAddress objOrderShippingAddress = new OrderShippingAddress();
        using(var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrderId", orderId);
            param.Add("@ShippingAddressId", shippingAddressId);
            objOrderShippingAddress= await con.QueryFirstAsync<OrderShippingAddress>("p_GET_OrderShippingAddressByOrderId", param, commandType:CommandType.StoredProcedure);           
        }
        return objOrderShippingAddress;
    }
    public async Task<int> AddUpdateShippingAddress(ShippingAddress objShippingAddress)
    {
        int result = 0;
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            if(objShippingAddress.ShippingAddressesId > 0) param.Add("@ShippingAddressId", objShippingAddress.ShippingAddressesId);
            if(objShippingAddress.CustomerId > 0) param.Add("@CustomerId", objShippingAddress.CustomerId);
            if (!string.IsNullOrEmpty(objShippingAddress.FullAddress)) param.Add("@FullAddress", objShippingAddress.FullAddress);
            if (!string.IsNullOrEmpty(objShippingAddress.State)) param.Add("@State", objShippingAddress.State);
            if (!string.IsNullOrEmpty(objShippingAddress.City)) param.Add("@City", objShippingAddress.City);
            if (!string.IsNullOrEmpty(objShippingAddress.ZipCode)) param.Add("@PostalCode", objShippingAddress.ZipCode);
            param.Add("@Flag", objShippingAddress.Flag);
            result = await con.ExecuteScalarAsync<int>("p_AUD_ShippingAddress", param, commandType: CommandType.StoredProcedure);            
        }
        return result;
    }
    public async Task<int> AddUpdateOrderShippingAddress(OrderShippingAddress objOrderShippingAddress)
    {
        int result = 0;
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            if(objOrderShippingAddress.OrderShippingAddressId > 0) param.Add("@OrderShippingAddressId", objOrderShippingAddress.OrderShippingAddressId);
            if(objOrderShippingAddress.OrderId > 0) param.Add("@OrderId", objOrderShippingAddress.OrderId);
            if(objOrderShippingAddress.ShippingAddressId > 0) param.Add("@ShippingAddressId", objOrderShippingAddress.ShippingAddressId);
            if (!string.IsNullOrEmpty(objOrderShippingAddress.FullAddress)) param.Add("@FullAddress", objOrderShippingAddress.FullAddress);
            if (!string.IsNullOrEmpty(objOrderShippingAddress.State)) param.Add("@State", objOrderShippingAddress.State);
            if (!string.IsNullOrEmpty(objOrderShippingAddress.City)) param.Add("@City", objOrderShippingAddress.City);
            if (!string.IsNullOrEmpty(objOrderShippingAddress.ZipCode)) param.Add("@PostalCode", objOrderShippingAddress.ZipCode);
            param.Add("@Flag", objOrderShippingAddress.Flag);
            result = await con.ExecuteScalarAsync<int>("p_AUD_OrderShippingAddress", param, commandType: CommandType.StoredProcedure);            
        }
        return result;
    }
}
