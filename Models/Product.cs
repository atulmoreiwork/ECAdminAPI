
namespace ECAdminAPI.Models;
public class Product
{
    public int ProductId { get;set;}
    public string ProductName { get;set;}
    public string UrlSlug { get;set;}
    public int CategoryId { get;set;}
    public string Description { get;set;}
    public float Price {get;set;}
    public int StockQuantity { get;set;}
    public string Status { get;set;}   
    public string CategoryName { get;set;}   
    public string ProductVariantCount { get;set;}  
    public List<ProductVariant> ProductVariants { get; set; }
    public int Flag { get; set; }
    public string Row { get; set; }
    public string TotalRowCount { get; set; }
}

public class ProductVariant
{
    public int ProductVariantId { get;set;}
    public int ProductId { get;set;}
    public string Color { get;set;}
    public string Size { get;set;}
    public string Price { get;set;}
    public string StockQuantity { get;set;}
}