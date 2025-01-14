using ECAdminAPI.Models;
using ECAdminAPI.Services;

namespace ECAdminAPI.Repositories;
public interface IGridDataHelperRepository
{
    List<ColumnsDetails> GetCustomersColumnDetails();
    List<FilterDetails> GetCustomersFilterDetails();
    List<ColumnsDetails> GetCategoriesColumnDetails();
    List<FilterDetails> GetCategoriesFilterDetails();
    List<ColumnsDetails> GetProductsColumnDetails();
    List<FilterDetails> GetProductsFilterDetails();    
    List<ColumnsDetails> GetOrdersColumnDetails();
    List<FilterDetails> GetOrdersFilterDetails();
    List<ColumnsDetails> GetDocumentsColumnDetails();
    List<FilterDetails> GetDocumentsFilterDetails();
    List<ColumnsDetails> GetUsersColumnDetails();
    List<FilterDetails> GetUsersFilterDetails();
    List<ColumnsDetails> GetRolesColumnDetails();
    List<FilterDetails> GetRolesFilterDetails();
}

public class GridDataHelperRepository : IGridDataHelperRepository
{
    private readonly ILoggerManager _logger;
    public GridDataHelperRepository(ILoggerManager logger)
    {
        _logger = logger;
    }

    public List<ColumnsDetails> GetCustomersColumnDetails()
    {
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        ColumnsDetails objColumnDetail;
        try
        {

            //Sr. No.
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "row";
            objColumnDetail.DisplayName = "Sr. No.";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "row";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //First Name
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "firstName";
            objColumnDetail.DisplayName = "First Name";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "firstName";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Last Name
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "lastName";
            objColumnDetail.DisplayName = "Last Name";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "lastName";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Login Name
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "email";
            objColumnDetail.DisplayName = "Login Name";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "email";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //Action
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "action";
            objColumnDetail.DisplayName = "Action";
            objColumnDetail.Html = true;
            objColumnDetail.HtmlName = "Action";
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = false;
            objColumnDetail.filter.IsFiltering = false;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "action";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //customerId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "customerId";
            objColumnDetail.DisplayName = "customerId";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "customerId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetCustomersColumnDetails()->Error->", ex);
        }
        return lstColumnDetail;
    }
    public List<FilterDetails> GetCustomersFilterDetails()
    {
        List<FilterDetails> lstFilterDetails = new List<FilterDetails>();
        FilterDetails objFilterDetail;
        try
        {

            //Sr. No.
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "row";
            objFilterDetail.Name = "row";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

            //First Name
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "firstName";
            objFilterDetail.Name = "firstName";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //Last Name
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "lastName";
            objFilterDetail.Name = "lastName";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //Email
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "email";
            objFilterDetail.Name = "email";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);


            //customerId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "customerId";
            objFilterDetail.Name = "customerId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetCustomersFilterDetails()->Error->", ex);
        }
        return lstFilterDetails;
    }

    public List<ColumnsDetails> GetCategoriesColumnDetails()
    {
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        ColumnsDetails objColumnDetail;
        try
        {

            //Sr. No.
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "row";
            objColumnDetail.DisplayName = "Sr. No.";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "row";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Category Name
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "categoryName";
            objColumnDetail.DisplayName = "Category Name";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "categoryName";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Description
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "description";
            objColumnDetail.DisplayName = "Description";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "description";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Status
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "status";
            objColumnDetail.DisplayName = "Status";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "status";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //Action
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "action";
            objColumnDetail.DisplayName = "Action";
            objColumnDetail.Html = true;
            objColumnDetail.HtmlName = "Action";
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = false;
            objColumnDetail.filter.IsFiltering = false;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "action";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //ParentCategoryId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "parentCategoryId";
            objColumnDetail.DisplayName = "parentCategoryId";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "parentCategoryId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //categoryId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "categoryId";
            objColumnDetail.DisplayName = "categoryId";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "categoryId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetCategoriesColumnDetails()->Error->", ex);
        }
        return lstColumnDetail;
    }
    public List<FilterDetails> GetCategoriesFilterDetails()
    {
        List<FilterDetails> lstFilterDetails = new List<FilterDetails>();
        FilterDetails objFilterDetail;
        try
        {

            //Sr. No.
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "row";
            objFilterDetail.Name = "row";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

            //Category Name
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "categoryName";
            objFilterDetail.Name = "categoryName";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //Description
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "description";
            objFilterDetail.Name = "description";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //Status
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "status";
            objFilterDetail.Name = "status";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);


            //parentCategoryId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "parentCategoryId";
            objFilterDetail.Name = "parentCategoryId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

            //CategoryId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "categoryId";
            objFilterDetail.Name = "categoryId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetCategoriesFilterDetails()->Error->", ex);
        }
        return lstFilterDetails;
    }

    public List<ColumnsDetails> GetProductsColumnDetails()
    {
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        ColumnsDetails objColumnDetail;
        try
        {

            //Sr. No.
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "row";
            objColumnDetail.DisplayName = "Sr. No.";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "row";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //ProductName Name
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "productName";
            objColumnDetail.DisplayName = "Product Name";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "productName";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //Description
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "description";
            objColumnDetail.DisplayName = "Description";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "description";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //CategoryId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "categoryId";
            objColumnDetail.DisplayName = "Category Id";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "categoryId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Category
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "categoryName";
            objColumnDetail.DisplayName = "Type";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "categoryName";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //UrlSlug
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "urlSlug";
            objColumnDetail.DisplayName = "Url Slug";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "urlSlug";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Price
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "price";
            objColumnDetail.DisplayName = "Price";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "price";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //StockQuantity
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "stockQuantity";
            objColumnDetail.DisplayName = "Quantity";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "stockQuantity";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Status
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "status";
            objColumnDetail.DisplayName = "Status";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "status";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Variant
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "productVariantCount";
            objColumnDetail.DisplayName = "Variant";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "productVariantCount";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);
          
            //Action
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "action";
            objColumnDetail.DisplayName = "Action";
            objColumnDetail.Html = true;
            objColumnDetail.HtmlName = "Action";
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = false;
            objColumnDetail.filter.IsFiltering = false;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "action";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //ProductId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "productId";
            objColumnDetail.DisplayName = "productId";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "productId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetProductsColumnDetails()->Error->", ex);
        }
        return lstColumnDetail;
    }
    public List<FilterDetails> GetProductsFilterDetails()
    {
        List<FilterDetails> lstFilterDetails = new List<FilterDetails>();
        FilterDetails objFilterDetail;
        try
        {

            //Sr. No.
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "row";
            objFilterDetail.Name = "row";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

            //Product Name
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "productName";
            objFilterDetail.Name = "productName";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //description
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "description";
            objFilterDetail.Name = "description";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //categoryId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "categoryId";
            objFilterDetail.Name = "categoryId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            
            //categoryName
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "categoryName";
            objFilterDetail.Name = "categoryName";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //price
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "price";
            objFilterDetail.Name = "price";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //stockQuantity
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "stockQuantity";
            objFilterDetail.Name = "stockQuantity";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);


            //urlSlug
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "urlSlug";
            objFilterDetail.Name = "urlSlug";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //ProductVariantCount
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "productVariantCount";
            objFilterDetail.Name = "productVariantCount";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //CategoryId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "productId";
            objFilterDetail.Name = "productId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetCategoriesFilterDetails()->Error->", ex);
        }
        return lstFilterDetails;
    }
    
    public List<ColumnsDetails> GetOrdersColumnDetails()
    {
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        ColumnsDetails objColumnDetail;
        try
        {

            //Sr. No.
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "row";
            objColumnDetail.DisplayName = "Sr. No.";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "row";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Order Number
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "orderNumber";
            objColumnDetail.DisplayName = "Order Number";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "orderNumber";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //CustomerId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "customerId";
            objColumnDetail.DisplayName = "Customer Id";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "customerId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //CustomerName
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "customerName";
            objColumnDetail.DisplayName = "CustomerName";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "customerName";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //TotalAmount
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "totalAmount";
            objColumnDetail.DisplayName = "Total";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "totalAmount";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);
            

            //Status
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "status";
            objColumnDetail.DisplayName = "Status";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "status";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //PaymentStatus
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "paymentStatus";
            objColumnDetail.DisplayName = "Payment Status";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "paymentStatus";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //PaymentType
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "paymentType";
            objColumnDetail.DisplayName = "Payment Method";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "paymentType";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Action
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "action";
            objColumnDetail.DisplayName = "Action";
            objColumnDetail.Html = true;
            objColumnDetail.HtmlName = "Action";
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = false;
            objColumnDetail.filter.IsFiltering = false;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "action";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //OrderId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "orderId";
            objColumnDetail.DisplayName = "orderId";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "orderId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetProductsColumnDetails()->Error->", ex);
        }
        return lstColumnDetail;
    }
    public List<FilterDetails> GetOrdersFilterDetails()
    {
        List<FilterDetails> lstFilterDetails = new List<FilterDetails>();
        FilterDetails objFilterDetail;
        try
        {

            //Sr. No.
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "row";
            objFilterDetail.Name = "row";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

            //Order Number
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "orderNumber";
            objFilterDetail.Name = "orderNumber";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //customerName
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "customerName";
            objFilterDetail.Name = "customerName";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //CustomerId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "customerId";
            objFilterDetail.Name = "customerId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //TotalAmount
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "totalAmount";
            objFilterDetail.Name = "totalAmount";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //Ststus
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "status";
            objFilterDetail.Name = "status";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //paymentStatus
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "paymentStatus";
            objFilterDetail.Name = "paymentStatus";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //paymentType
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "paymentType";
            objFilterDetail.Name = "paymentType";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);
            

            //OrderId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "orderId";
            objFilterDetail.Name = "orderId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetOrdersFilterDetails()->Error->", ex);
        }
        return lstFilterDetails;
    }

    public List<ColumnsDetails> GetDocumentsColumnDetails()
    {
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        ColumnsDetails objColumnDetail;
        try
        {

            //Sr. No.
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "row";
            objColumnDetail.DisplayName = "Sr. No.";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "row";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //File Name
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "fileName";
            objColumnDetail.DisplayName = "File Name";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "fileName";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //File Url
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "fileUrl";
            objColumnDetail.DisplayName = "File Url";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "fileUrl";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Document Type
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "documentType";
            objColumnDetail.DisplayName = "Document Type";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "documentType";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //AssociatedId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "associatedId";
            objColumnDetail.DisplayName = "Associated Id";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "associatedId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            
            //AssociatedType
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "associatedType";
            objColumnDetail.DisplayName = "Associated Type";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "associatedType";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //Action
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "action";
            objColumnDetail.DisplayName = "Action";
            objColumnDetail.Html = true;
            objColumnDetail.HtmlName = "Action";
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = false;
            objColumnDetail.filter.IsFiltering = false;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "action";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //DocumentId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "documentId";
            objColumnDetail.DisplayName = "Document Id";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "documentId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetDocumentsColumnDetails()->Error->", ex);
        }
        return lstColumnDetail;
    }
    public List<FilterDetails> GetDocumentsFilterDetails()
    {
        List<FilterDetails> lstFilterDetails = new List<FilterDetails>();
        FilterDetails objFilterDetail;
        try
        {

            //Sr. No.
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "row";
            objFilterDetail.Name = "row";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

            //File Name
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "fileName";
            objFilterDetail.Name = "fileName";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //File Url
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "fileUrl";
            objFilterDetail.Name = "fileUrl";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //DocumentType
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "documentType";
            objFilterDetail.Name = "documentType";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //AssociatedType
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "associatedType";
            objFilterDetail.Name = "associatedType";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);


            //AssociatedId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "associatedId";
            objFilterDetail.Name = "associatedId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

            //DocumentId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "documentId";
            objFilterDetail.Name = "documentId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetDocumentsFilterDetails()->Error->", ex);
        }
        return lstFilterDetails;
    }

    public List<ColumnsDetails> GetUsersColumnDetails()
    {
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        ColumnsDetails objColumnDetail;
        try
        {

            //Sr. No.
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "row";
            objColumnDetail.DisplayName = "Sr. No.";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "row";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //User Name
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "userName";
            objColumnDetail.DisplayName = "User Name";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "userName";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //Login Name
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "email";
            objColumnDetail.DisplayName = "Email";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "email";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Status
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "status";
            objColumnDetail.DisplayName = "Status";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "status";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Action
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "action";
            objColumnDetail.DisplayName = "Action";
            objColumnDetail.Html = true;
            objColumnDetail.HtmlName = "Action";
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = false;
            objColumnDetail.filter.IsFiltering = false;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "action";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //userId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "userId";
            objColumnDetail.DisplayName = "userId";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "userId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetUsersColumnDetails()->Error->", ex);
        }
        return lstColumnDetail;
    }
    public List<FilterDetails> GetUsersFilterDetails()
    {
        List<FilterDetails> lstFilterDetails = new List<FilterDetails>();
        FilterDetails objFilterDetail;
        try
        {

            //Sr. No.
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "row";
            objFilterDetail.Name = "row";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

            //User Name
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "userName";
            objFilterDetail.Name = "userName";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //Email
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "email";
            objFilterDetail.Name = "email";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //Status
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "status";
            objFilterDetail.Name = "status";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);


            //AdminUserId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "userId";
            objFilterDetail.Name = "userId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetUsersFilterDetails()->Error->", ex);
        }
        return lstFilterDetails;
    }

    public List<ColumnsDetails> GetRolesColumnDetails()
    {
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        ColumnsDetails objColumnDetail;
        try
        {

            //Sr. No.
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "row";
            objColumnDetail.DisplayName = "Sr. No.";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "row";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //Role Name
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "roleName";
            objColumnDetail.DisplayName = "Role Name";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "roleName";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //Description
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "roleDescription";
            objColumnDetail.DisplayName = "Description";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "roleDescription";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //Action
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = true;
            objColumnDetail.Name = "action";
            objColumnDetail.DisplayName = "Action";
            objColumnDetail.Html = true;
            objColumnDetail.HtmlName = "Action";
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = false;
            objColumnDetail.filter.IsFiltering = false;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "action";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //roleId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "roleId";
            objColumnDetail.DisplayName = "roleId";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "num";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "num";
            objColumnDetail.filter.FilterName = "roleId";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetRolesColumnDetails()->Error->", ex);
        }
        return lstColumnDetail;
    }
    public List<FilterDetails> GetRolesFilterDetails()
    {
        List<FilterDetails> lstFilterDetails = new List<FilterDetails>();
        FilterDetails objFilterDetail;
        try
        {

            //Sr. No.
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "row";
            objFilterDetail.Name = "row";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

            //Role Name
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "roleName";
            objFilterDetail.Name = "roleName";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //RoleDescription
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "roleDescription";
            objFilterDetail.Name = "roleDescription";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);


            //RoleId
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "roleId";
            objFilterDetail.Name = "roleId";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "num";
            lstFilterDetails.Add(objFilterDetail);

        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("GridDataHelperRepository->GetRolesFilterDetails()->Error->", ex);
        }
        return lstFilterDetails;
    }
}