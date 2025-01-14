using System.Data;
using Dapper;
using ECAdminAPI.Models;
namespace ECAdminAPI.Repositories;

public interface IOrderShippingAddressRepository
{
    Task<OrderShippingAddress> GetOrderShippingAddress(int orderId);
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
}
