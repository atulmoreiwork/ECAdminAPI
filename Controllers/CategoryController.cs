using System.Net;
using ECAdminAPI.Models;
using ECAdminAPI.Repositories;
using ECAdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly ICategoryRepository _categoryRepository;
    public CategoryController(ILoggerManager logger, ICategoryRepository categoryRepository)
    {
        _logger = logger;
        _categoryRepository = categoryRepository;
    }

    [HttpGet("GetCategories")]
    public async Task<APIResponse<List<Categories>>> GetCategories()
    {
        List<Categories> lstCategories = new List<Categories>();
        try
        {
            lstCategories = await _categoryRepository.GetCategories();
            return new APIResponse<List<Categories>>(lstCategories, "Categories retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Category => GetCategories =>", ex);
            return new APIResponse<List<Categories>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("GetAllCategories")]
    public async Task<APIResponse<PagedResultDto<List<Categories>>>> GetAllCategories([FromBody] GridFilter objFilter)
    {
        try
        {
            string CategoryId = string.Empty;
            if (objFilter == null)
            {
                ModelState.AddModelError("GridFilter", "Grid Filter object are null");
                return new APIResponse<PagedResultDto<List<Categories>>>(HttpStatusCode.BadRequest, "Grid filter object is null", ModelState.AllErrors(), true);
            }
            if (objFilter != null && objFilter.Filter != null && objFilter.Filter.Count > 0)
            {
                var _filter = objFilter.Filter.Find(x => x.ColId.ToLower() == "categoryid");
                if (_filter != null && !string.IsNullOrEmpty(_filter.Value)) { CategoryId = _filter.Value; }
            }
            var lstCustomer = await _categoryRepository.GetAllCategories(CategoryId, objFilter.PageNumber, objFilter.PageSize);
            return new APIResponse<PagedResultDto<List<Categories>>>(lstCustomer, "Customers retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Category => GetAllCategories =>", ex);
            return new APIResponse<PagedResultDto<List<Categories>>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("GetCategoryById")]
    public async Task<APIResponse<Categories>> GetCategoryById(int CategoryId)
    {
        Categories objCategories = new Categories();
        try
        {
            if (CategoryId == 0)
            {
                ModelState.AddModelError("CategoryId", "Please provide categoryId");
                return new APIResponse<Categories>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
            }
            objCategories = await _categoryRepository.GetCategoryById(CategoryId);
            return new APIResponse<Categories>(objCategories, "Category retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Category => GetCategoryById =>", ex);
            return new APIResponse<Categories>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("AddUpdateCategory")]
    public async Task<APIResponse<int>> AddUpdateCategory([FromBody] Categories objCategories)
    {
        int result = 0;
        try
        {
            if (!ModelState.IsValid) 
            { 
                return new APIResponse<int>(HttpStatusCode.BadRequest,"Validation Error",ModelState.AllErrors(),true);
            }
            bool categoryExist = _categoryRepository.IsCategoryExists(objCategories.CategoryName, objCategories.CategoryId);
            if (categoryExist)
            {
                ModelState.AddModelError("CategoryName", "Category name already exists");
                return new APIResponse<int>(HttpStatusCode.BadRequest,"Validation Error",ModelState.AllErrors(),true);
            }
            if (objCategories.CategoryId <= 0) { objCategories.Flag = 1; }
            else { objCategories.Flag = 2; }
            result = await _categoryRepository.AddUpdateCategory(objCategories);
            string successMessage = "Category added successfully";
            if (objCategories.Flag == 2) { successMessage =  "Category updated successfully"; } 
            return new APIResponse<int>(result, successMessage);
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Category => AddUpdateCategory =>", ex);
            return new APIResponse<int>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }
}