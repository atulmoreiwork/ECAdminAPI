using System.Data;
using Dapper;
using ECAdminAPI.Models;
namespace ECAdminAPI.Repositories;
public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<List<ProductVariant>> GetProductVariants(int ProductId);
    Task<PagedResultDto<List<Product>>> GetAllProducts(string ProductId, int PageIndex = 0, int PageSize = 0);
    Task<Product> GetProductById(int ProductId);
    Task<ProductVariant> GetProductVariantByProductId(int ProductVariantId);
    Task<int> AddUpdateProduct(Product objProduct);
    Task<bool> DeleteProduct(int ProductId);
}

public class ProductRepository : IProductRepository
{
    private readonly DapperContext _context;
    private readonly IGridDataHelperRepository _gridDataHelperRepository;
    public ProductRepository(DapperContext context, IGridDataHelperRepository gridDataHelperRepository)
    {
        _context = context;
        _gridDataHelperRepository = gridDataHelperRepository;
    }

    public async Task<List<Product>> GetProducts()
    {
        List<Product> lstProducts = new List<Product>();
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            var result = await con.QueryAsync<Product>("p_GET_Products", param, commandType: CommandType.StoredProcedure);
            lstProducts = result.ToList();
        }
        return lstProducts;
    }
    public async Task<PagedResultDto<List<Product>>> GetAllProducts(string ProductId, int PageIndex = 0, int PageSize = 0)
    {
        var objResp = new PagedResultDto<List<Product>>();
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        List<FilterDetails> lstFilterDetail = new List<FilterDetails>();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Products";
            DynamicParameters param = new DynamicParameters();
            if (!string.IsNullOrEmpty(ProductId)) param.Add("@ProductId", ProductId);
            if (PageSize > 0) { param.Add("@PageSize", PageSize); } else { param.Add("@PageSize", null); }
            if (PageIndex > 0) { param.Add("@PageIndex", PageIndex); } else { param.Add("@PageIndex", null); }
            var result = await con.QueryAsync<Product>(query, param, commandType: CommandType.StoredProcedure);
            if (result == null) return null;
            int count = 0;
            if (result.Count() > 0)
            {
                var elm = result.First();
                count = Convert.ToInt32(elm.TotalRowCount);
                lstColumnDetail = _gridDataHelperRepository.GetProductsColumnDetails();
                lstFilterDetail = _gridDataHelperRepository.GetProductsFilterDetails();
            }
            objResp = new PagedResultDto<List<Product>>(PageIndex, PageSize, count, result.ToList(), lstColumnDetail, lstFilterDetail);
        }
        return objResp;
    }
    public async Task<List<ProductVariant>> GetProductVariants(int ProductId)
    {
        List<ProductVariant> lstProductVariant = new List<ProductVariant>();
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            if (ProductId > 0) param.Add("@ProductId", ProductId);
            var result = await con.QueryAsync<ProductVariant>("p_GET_ProductVariants", param, commandType: CommandType.StoredProcedure);
            lstProductVariant = result.ToList();
        }
        return lstProductVariant;
    }
    public async Task<Product> GetProductById(int ProductId)
    {
        Product objProduct = new Product();
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", ProductId);
            objProduct = await con.QueryFirstAsync<Product>("p_GET_Products", param, commandType: CommandType.StoredProcedure);
        }
        if (objProduct != null && objProduct.ProductId > 0)
        {
            objProduct.ProductVariants = new List<ProductVariant>();
            objProduct.ProductVariants = GetProductVariants(objProduct.ProductId).Result;
        }
        return objProduct;
    }
    public async Task<ProductVariant> GetProductVariantByProductId(int ProductVariantId)
    {
        ProductVariant objProductVariant = new ProductVariant();
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductVariantId", ProductVariantId);
            //param.Add("@ProductId", ProductId);
            objProductVariant = await con.QueryFirstOrDefaultAsync<ProductVariant>("p_GET_ProductVariantsById", param, commandType: CommandType.StoredProcedure, commandTimeout: 120);
        }
        return objProductVariant;
    }
    public async Task<int> AddUpdateProduct(Product objProduct)
    {
        int productId = 0;
        using (var con = _context.CreateConnection)
        {
            con.Open();
            using (var tran = con.BeginTransaction())
            {
                try
                {
                    DynamicParameters param = new DynamicParameters();
                    if (objProduct.ProductId > 0) param.Add("@ProductId", objProduct.ProductId);
                    if (!string.IsNullOrEmpty(objProduct.ProductName)) param.Add("@ProductName", objProduct.ProductName);
                    if (!string.IsNullOrEmpty(objProduct.UrlSlug)) param.Add("@UrlSlug", objProduct.UrlSlug);
                    param.Add("@CategoryId", objProduct.CategoryId);
                    if (!string.IsNullOrEmpty(objProduct.Description)) param.Add("@Description", objProduct.Description);
                    param.Add("@Price", objProduct.Price);
                    param.Add("@StockQuantity", objProduct.StockQuantity);
                    if (!string.IsNullOrEmpty(objProduct.Status)) param.Add("@Status", objProduct.Status);
                    param.Add("@Flag", objProduct.Flag);
                    productId = await con.ExecuteScalarAsync<int>("p_AUD_Products", param, transaction: tran, commandType: CommandType.StoredProcedure, commandTimeout: 120);
                    if(objProduct.Flag == 2){ productId = objProduct.ProductId;}
                    if(productId > 0)
                    {
                        foreach (var variant in objProduct.ProductVariants)
                        {
                            param = new DynamicParameters();
                            param.Add("@ProductId", productId);
                             if (variant.ProductVariantId > 0) param.Add("@ProductVariantId", variant.ProductVariantId);
                            if (!string.IsNullOrEmpty(variant.Color)) param.Add("@Color", variant.Color);
                            if (!string.IsNullOrEmpty(variant.Size)) param.Add("@Size", variant.Size);
                            if (!string.IsNullOrEmpty(variant.Price)) param.Add("@Price", variant.Price);
                            if (!string.IsNullOrEmpty(variant.StockQuantity)) param.Add("@StockQuantity", variant.StockQuantity);
                            param.Add("@Flag", objProduct.Flag);
                            var productVariantId = await con.ExecuteScalarAsync<int>("p_AUD_ProductVariant", param, transaction: tran, commandType: CommandType.StoredProcedure, commandTimeout: 120);
                        }
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    productId = 0;
                    tran.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        return productId;
    }
    public async Task<bool> DeleteProduct(int ProductId)
    {
        bool result = false;
        using (var con = _context.CreateConnection)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@ProductId", ProductId);
            param.Add("@Status", "inactive");
            param.Add("@Flag", 3);
            var _result = await con.ExecuteScalarAsync<int>("p_AUD_Products", param, commandType: CommandType.StoredProcedure);
            if (_result > 0) { result = true; }
        }
        return result;
    }
}