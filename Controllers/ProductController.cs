using System.Net;
using System.Text.Json;
using ECAdminAPI.Models;
using ECAdminAPI.Repositories;
using ECAdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IProductRepository _productRepository;
    private readonly IDocumentRepository _documentRepository;
    public ProductController(ILoggerManager logger, IProductRepository productRepository, IDocumentRepository documentRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
        _documentRepository = documentRepository;
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

    [HttpPost("AddUpdateProduct")]
    public async Task<APIResponse<int>> AddUpdateProduct()
    {
        try
        {
            Product objModel = new Product();
            var form = await Request.ReadFormAsync();
            var files = form.Files;
            if (files != null || files.Count > 0)
            {
                var supportedTypes = new[] { "pdf","jpg","jpeg", "png" };
                 foreach (var file in files){
                    var fileExt = Path.GetExtension(file.FileName).Substring(1).ToLower();
                    if (!supportedTypes.Contains(fileExt))
                    {
                        ModelState.AddModelError("ImportFile", $"File '{file.FileName}' has an unsupported file type.");
                    }
                 }
            }
            if (!ModelState.IsValid)
            {
                return new APIResponse<int>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
            }
            objModel.ProductId = Convert.ToInt32(Request.Form["ProductId"]);
            objModel.ProductName = Convert.ToString(Request.Form["ProductName"]);
            objModel.CategoryId = Convert.ToInt32(Request.Form["CategoryId"]);
            objModel.Description = Convert.ToString(Request.Form["Description"]);
            objModel.Price = Convert.ToDouble(Request.Form["Price"]);            
            objModel.Status = Convert.ToString(Request.Form["Status"]);
            objModel.ProductVariants = new List<ProductVariant>();
            var productVariantsJson = Request.Form["ProductVariants"];
            objModel.ProductVariants = JsonConvert.DeserializeObject<List<ProductVariant>>(productVariantsJson);
            objModel.StockQuantity = 0;
            if(objModel.ProductId > 0){ objModel.Flag = 2;} else { objModel.Flag = 1;}
            foreach (var variant in objModel.ProductVariants)
            {
                objModel.StockQuantity = objModel.StockQuantity + Convert.ToInt32(variant.StockQuantity);
            }
            var result = await _productRepository.AddUpdateProduct(objModel);
            if(result > 0 && (files != null || files.Count > 0))
            {
               objModel.ImportFile = form.Files.ToArray();
               await _documentRepository.AddProductDocumentWithFile(result, objModel.ImportFile);
            }
            var documentJson = Request.Form["Documents"];
            objModel.Documents = JsonConvert.DeserializeObject<List<Document>>(documentJson);
            for(int i = 0; i < objModel.Documents.Count; i++)
            {
                if(objModel.Documents[i].IsDeleted == true)
                {
                    await _documentRepository.DeleteDocumentById(objModel.Documents[i].DocumentId);
                }                
            }
            return new APIResponse<int>(result, "Product created successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Product => AddProduct =>", ex);
            return new APIResponse<int>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("DeleteProductById")]
    public async Task<APIResponse<int>> DeleteProductById(int ProductId)
    {
        _logger.LogInfo("[CategoryController]|[DeleteProductById]|[Start] => DeleteProductById => ProductId: " + ProductId);
        if (ProductId <= 0)
        {
            ModelState.AddModelError("ProductId", "Please enter ProductId");
            return new APIResponse<int>(HttpStatusCode.BadRequest,"Validation Error",ModelState.AllErrors(),true);
        }
        var result = await _productRepository.DeleteProductById(ProductId);
         string successMessage = "Product deleted successfully";
        return new APIResponse<int>(result, successMessage);
    }
}
