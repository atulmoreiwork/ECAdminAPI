using System.Net;
using ECAdminAPI.Models;
using ECAdminAPI.Repositories;
using ECAdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IProductRepository _productRepository;
    public ProductController(ILoggerManager logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    [HttpGet("GetProducts")]
    public async Task<APIResponse<List<Product>>> GetProducts()
    {
        List<Product> lstProduct = new List<Product>();
        try
        {
            lstProduct = await _productRepository.GetProducts();
            return new APIResponse<List<Product>>(lstProduct, "Products retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Product => GetProducts =>", ex);
            return new APIResponse<List<Product>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("GetAllProducts")]
    public async Task<APIResponse<PagedResultDto<List<Product>>>> GetAllProducts([FromBody] GridFilter objFilter)
    {
        try
        {
            string ProductId = string.Empty;
            if (objFilter == null)
            {
                ModelState.AddModelError("GridFilter", "Grid Filter object are null");
                return new APIResponse<PagedResultDto<List<Product>>>(HttpStatusCode.BadRequest, "Grid filter object is null", ModelState.AllErrors(), true);
            }
            if (objFilter != null && objFilter.Filter != null && objFilter.Filter.Count > 0)
            {
                var _filter = objFilter.Filter.Find(x => x.ColId.ToLower() == "productid");
                if (_filter != null && !string.IsNullOrEmpty(_filter.Value)) { ProductId = _filter.Value; }
            }
            var lstProducts = await _productRepository.GetAllProducts(ProductId, objFilter.PageNumber, objFilter.PageSize);
            return new APIResponse<PagedResultDto<List<Product>>>(lstProducts, "Products retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Product => GetAllProducts =>", ex);
            return new APIResponse<PagedResultDto<List<Product>>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("GetProductById")]
    public async Task<APIResponse<Product>> GetProductById(int ProductId)
    {
        Product objProduct = new Product();
        try
        {
            if (ProductId == 0)
            {
                ModelState.AddModelError("ProductId", "Please provide productId");
                return new APIResponse<Product>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
            }
            objProduct = await _productRepository.GetProductById(ProductId);
            return new APIResponse<Product>(objProduct, "Product retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Product => GetProductById =>", ex);
            return new APIResponse<Product>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("AddProduct")]
    public async Task<APIResponse<int>> AddProduct([FromBody] Product objProduct)
    {
        int result = 0;
        try
        {
            if (!ModelState.IsValid)
            {
                return new APIResponse<int>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
            }
            result = await _productRepository.AddProduct(objProduct);
            return new APIResponse<int>(result, "Product created successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Product => AddProduct =>", ex);
            return new APIResponse<int>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("UpdateProduct")]
    public async Task<APIResponse<int>> UpdateProduct([FromBody] Product objProduct)
    {
        int result = 0;
        try
        {
            if (!ModelState.IsValid)
            {
                return new APIResponse<int>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
            }
            result = await _productRepository.UpdateProduct(objProduct);
            return new APIResponse<int>(result, "Product updated successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Product => UpdateProduct =>", ex);
            return new APIResponse<int>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }
}
