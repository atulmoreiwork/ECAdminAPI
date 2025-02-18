using System.Data;
using Dapper;
using ECAdminAPI.Models;
namespace ECAdminAPI.Repositories;

public interface IOrderShippingAddressRepository
{
    Task<OrderShippingAddress> GetOrderShippingAddress(int orderId);
    Task<int> AddUpdateShippingAddress(OrderShippingAddress objOrderShippingAddress);
}

public class OrderShippingAddressRepository : IOrderShippingAddressRepository
{
    private readonly DapperContext _context;
    public OrderShippingAddressRepository(DapperContext context)
    {
        _context = context;
    }
    public async Task<OrderShippingAddress> GetOrderShippingAddress(int orderId)
    {
        OrderShippingAddress objOrderShippingAddress = new OrderShippingAddress();
        using(var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@OrderId", orderId);            
            objOrderShippingAddress= await con.QueryFirstAsync<OrderShippingAddress>("p_GET_OrderShippingAddressByOrderId", param, commandType:CommandType.StoredProcedure);           
        }
        return objOrderShippingAddress;
    }

    public async Task<int> AddUpdateShippingAddress(OrderShippingAddress objOrderShippingAddress)
    {
        int result = 0;
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            if (objOrderShippingAddress.OrderShippingAddressId <= 0) { objOrderShippingAddress.Flag = 1; }
            else { objOrderShippingAddress.Flag = 2; }
            if(objOrderShippingAddress.OrderShippingAddressId > 0) param.Add("@OrderShippingAddressId", objOrderShippingAddress.OrderShippingAddressId);
            if(objOrderShippingAddress.OrderId > 0) param.Add("@OrderId", objOrderShippingAddress.OrderId);
            if (!string.IsNullOrEmpty(objOrderShippingAddress.FullAddress)) param.Add("@FullAddress", objOrderShippingAddress.FullAddress);
            if (!string.IsNullOrEmpty(objOrderShippingAddress.State)) param.Add("@State", objOrderShippingAddress.State);
            if (!string.IsNullOrEmpty(objOrderShippingAddress.City)) param.Add("@City", objOrderShippingAddress.City);
            if (!string.IsNullOrEmpty(objOrderShippingAddress.ZipCode)) param.Add("@ZipCode", objOrderShippingAddress.ZipCode);
            param.Add("@Flag", objOrderShippingAddress.Flag);
            result = await con.ExecuteScalarAsync<int>("p_AUD_OrderShippingAddress", param, commandType: CommandType.StoredProcedure);            
        }
        return result;
    }
}
