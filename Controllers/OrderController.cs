using System.Net;
using ECAdminAPI.Models;
using ECAdminAPI.Repositories;
using ECAdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IOrderRepository _orderRepository;
    public OrderController(ILoggerManager logger, IOrderRepository orderRepository)
    {
        _logger = logger;
        _orderRepository = orderRepository;
    }

    [HttpGet("GetOrders")]
    public async Task<APIResponse<List<Order>>> GetOrders()
    {
        List<Order> lstOrder = new List<Order>();
        try
        {
            lstOrder = await _orderRepository.GetOrders();
            return new APIResponse<List<Order>>(lstOrder, "Orders retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Order => GetOrders =>", ex);
            return new APIResponse<List<Order>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("GetAllOrders")]
    public async Task<APIResponse<PagedResultDto<List<Order>>>> GetAllOrders([FromBody] GridFilter objFilter)
    {
        try
        {
            string OrderId = string.Empty;
            if (objFilter == null)
            {
                ModelState.AddModelError("GridFilter", "Grid Filter object are null");
                return new APIResponse<PagedResultDto<List<Order>>>(HttpStatusCode.BadRequest, "Grid filter object is null", ModelState.AllErrors(), true);
            }
            if (objFilter != null && objFilter.Filter != null && objFilter.Filter.Count > 0)
            {
                var _filter = objFilter.Filter.Find(x => x.ColId.ToLower() == "orderid");
                if (_filter != null && !string.IsNullOrEmpty(_filter.Value)) { OrderId = _filter.Value; }
            }
            var lstOrders = await _orderRepository.GetAllOrders(OrderId, objFilter.PageNumber, objFilter.PageSize);
            return new APIResponse<PagedResultDto<List<Order>>>(lstOrders, "Order retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Order => GetAllOrders =>", ex);
            return new APIResponse<PagedResultDto<List<Order>>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("GetOrderById")]
    public async Task<APIResponse<Order>> GetOrderById(int OrderId)
    {
        Order objOrder = new Order();
        try
        {
            if (OrderId == 0)
            {
                ModelState.AddModelError("OrderId", "Please provide orderId");
                return new APIResponse<Order>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
            }
            objOrder = await _orderRepository.GetOrderById(OrderId);
            return new APIResponse<Order>(objOrder, "Order retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Order => GetOrderById =>", ex);
            return new APIResponse<Order>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }


    [HttpPost("AddUpdateOrder")]
    public async Task<APIResponse<int>> AddUpdateOrder([FromBody] Order objOrder)
    {
        int result = 0;
        try
        {
            if (!ModelState.IsValid)
            {
                return new APIResponse<int>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
            }
            if (objOrder.OrderId <= 0) { objOrder.Flag = 1; }
            else { objOrder.Flag = 2; }
            result = await _orderRepository.AddUpdateOrder(objOrder);
            return new APIResponse<int>(result, "Order created successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Order => AddUpdateOrder =>", ex);
            return new APIResponse<int>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }  
}
