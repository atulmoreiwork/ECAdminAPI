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
            objColumnDetail.IsDisplayOnGrid = false;
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
            objColumnDetail.IsDisplayOnGrid = false;
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
            objColumnDetail.IsDisplayOnGrid = false;
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

            //OrderName
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "orderName";
            objColumnDetail.DisplayName = "OrderName";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "orderName";
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

            //TotalAmount
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "totalAmount";
            objColumnDetail.DisplayName = "Total Amount";
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

            //DiscountAmount
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "discountAmount";
            objColumnDetail.DisplayName = "Discount Amount";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "discountAmount";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //GrossAmount
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "grossAmount";
            objColumnDetail.DisplayName = "Gross Amount";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "grossAmount";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //ShippingAmount
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "shippingAmount";
            objColumnDetail.DisplayName = "Shipping Amount";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "shippingAmount";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);

            //NetAmount
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "netAmount";
            objColumnDetail.DisplayName = "Net Amount";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "netAmount";
            objColumnDetail.filter.FilterFrom = string.Empty;
            objColumnDetail.filter.FilterTo = string.Empty;
            lstColumnDetail.Add(objColumnDetail);


            //Status
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
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
            objColumnDetail.IsDisplayOnGrid = false;
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
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "paymentType";
            objColumnDetail.DisplayName = "Payment Type";
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

            //PaymentTransactionId
            objColumnDetail = new ColumnsDetails();
            objColumnDetail.filter = new FilterConfig();
            objColumnDetail.IsDisplayOnGrid = false;
            objColumnDetail.Name = "paymentTransactionId";
            objColumnDetail.DisplayName = "Payment TransactionId";
            objColumnDetail.Html = false;
            objColumnDetail.HtmlName = string.Empty;
            objColumnDetail.Type = "cs";
            objColumnDetail.IsSorting = true;
            objColumnDetail.filter.IsFiltering = true;
            objColumnDetail.filter.FilterInputType = "input";
            objColumnDetail.filter.FilterType = "cs";
            objColumnDetail.filter.FilterName = "paymentTransactionId";
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

            //OrderName
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "orderName";
            objFilterDetail.Name = "orderName";
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

            //DiscountAmount
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "discountAmount";
            objFilterDetail.Name = "discountAmount";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);


            //GrossAmount
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "grossAmount";
            objFilterDetail.Name = "grossAmount";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //ShippingAmount
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "shippingAmount";
            objFilterDetail.Name = "shippingAmount";
            objFilterDetail.Value = "";
            objFilterDetail.Type = "cs";
            lstFilterDetails.Add(objFilterDetail);

            //NetAmount
            objFilterDetail = new FilterDetails();
            objFilterDetail.ColId = "netAmount";
            objFilterDetail.Name = "netAmount";
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
}