
using Newtonsoft.Json;

namespace ECAdminAPI.Models;
public class Product
{
    public int ProductId { get;set;}
    public string ProductName { get;set;}
    public string UrlSlug { get;set;}
    public int CategoryId { get;set;}
    public string Description { get;set;}
    public Double Price {get;set;}
    public int StockQuantity { get;set;}
    public string Status { get;set;}   
    public string CategoryName { get;set;}   
    public string ProductVariantCount { get;set;}  
    public IFormFile[] ImportFile { get; set; }
    public List<ProductVariant> ProductVariants { get; set; }
    public List<Document> Documents { get; set; }
    public int Flag { get; set; }
    public string Row { get; set; }
    public string TotalRowCount { get; set; }
}

public class ProductVariant
{
    [JsonProperty("productVariantId")]
    public int ProductVariantId { get;set;}

    [JsonProperty("productId")]
    public int ProductId { get;set;}
    
    [JsonProperty("color")]
    public string Color { get;set;}

    [JsonProperty("size")]
    public string Size { get;set;}

    [JsonProperty("price")]
    public string Price { get;set;}

    [JsonProperty("stockQuantity")]
    public string StockQuantity { get;set;}
}