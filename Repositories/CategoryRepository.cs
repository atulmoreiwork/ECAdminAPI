using Dapper;
using System.Data;
using System.Data.SqlClient;
using ECAdminAPI.Models;
namespace ECAdminAPI.Repositories;

public interface ICategoryRepository
{
    bool IsCategoryExists(string CategoryName, int CategoryId = 0);
    Task<List<Categories>> GetCategories();
    Task<PagedResultDto<List<Categories>>> GetAllCategories(string CategoryId, int PageIndex = 0, int PageSize = 0);
    Task<Categories> GetCategoryById(int CategoryId);
    Task<int> AddUpdateCategory(Categories objModel);
    Task<int> DeleteCategoryById(int CategoryId);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly DapperContext _context;
    private readonly IGridDataHelperRepository _gridDataHelperRepository;
    public CategoryRepository(DapperContext context, IGridDataHelperRepository gridDataHelperRepository)
    {
        _context = context;
        _gridDataHelperRepository = gridDataHelperRepository;
    }
    public bool IsCategoryExists(string CategoryName, int CategoryId = 0)
    {
        int CategoryExistId = 0;
        using (var con = _context.CreateConnection)
        {
            string query = "p_CHK_CategoryIsExist";
            con.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryName", CategoryName);
            if (CategoryId > 0) param.Add("@CategoryId", CategoryId);
            CategoryExistId = con.QuerySingle<int>(query, param, commandType: CommandType.StoredProcedure);
        }
        return CategoryExistId > 0 ? true : false;
    }
    public async Task<List<Categories>> GetCategories()
    {
        var objResp = new List<Categories>();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Categories";
            con.Open();
            DynamicParameters oParameters = new DynamicParameters();
            var result = await con.QueryAsync<Categories>(query, oParameters, commandType: CommandType.StoredProcedure);
            objResp = result.ToList(); ;
        }
        return objResp;
    }
    public async Task<PagedResultDto<List<Categories>>> GetAllCategories(string CategoryId, int PageIndex = 0, int PageSize = 0)
    {
        var objResp = new PagedResultDto<List<Categories>>();
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        List<FilterDetails> lstFilterDetail = new List<FilterDetails>();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Categories";
            DynamicParameters param = new DynamicParameters();
            if (!string.IsNullOrEmpty(CategoryId)) param.Add("@CategoryId", CategoryId);
            if (PageSize > 0) { param.Add("@PageSize", PageSize); } else { param.Add("@PageSize", null); }
            if (PageIndex > 0) { param.Add("@PageIndex", PageIndex); } else { param.Add("@PageIndex", null); }
            var result = await con.QueryAsync<Categories>(query, param, commandType: CommandType.StoredProcedure);
            if (result == null) return null;
            int count = 0;
            if (result.Count() > 0)
            {
                var elm = result.First();
                count = Convert.ToInt32(elm.TotalRowCount);
                lstColumnDetail = _gridDataHelperRepository.GetCategoriesColumnDetails();
                lstFilterDetail = _gridDataHelperRepository.GetCategoriesFilterDetails();
            }
            objResp = new PagedResultDto<List<Categories>>(PageIndex, PageSize, count, result.ToList(), lstColumnDetail, lstFilterDetail);
        }
        return objResp;
    }
    public async Task<Categories> GetCategoryById(int CategoryId)
    {
        var objResp = new Categories();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Categories";
            con.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryId", CategoryId);
            var _result = await con.QueryAsync<Categories>(query, param, commandType: CommandType.StoredProcedure);
            objResp = _result.FirstOrDefault();
        }
        return objResp;
    }
    public async Task<int> AddUpdateCategory(Categories objModel)
    {
        int CategoryId = 0;
        using (var con = _context.CreateConnection)
        {

            string query = "p_AUD_Categories";
            con.Open();
            var param = new DynamicParameters();
            if (objModel.CategoryId > 0) param.Add("@CategoryId", objModel.CategoryId);
            if (objModel.ParentCategoryId > 0) param.Add("@ParentCategoryId", objModel.ParentCategoryId);
            if (!string.IsNullOrEmpty(objModel.CategoryName)) param.Add("@CategoryName", objModel.CategoryName);
            if (!string.IsNullOrEmpty(objModel.Description)) param.Add("@Description", objModel.Description);
            if (!string.IsNullOrEmpty(objModel.UrlSlug)) param.Add("@UrlSlug", objModel.UrlSlug);
            if (!string.IsNullOrEmpty(objModel.Status)) param.Add("@Status", objModel.Status);
            param.Add("@Flag", objModel.Flag);
            CategoryId = await con.QuerySingleAsync<int>(query, param, commandType: CommandType.StoredProcedure);
        }
        return CategoryId;
    }
    public async Task<int> DeleteCategoryById(int CategoryId)
    {
        int _categoryId = 0;
        using (var con = _context.CreateConnection)
        {

            string query = "p_AUD_Categories";
            con.Open();
            var param = new DynamicParameters();
            param.Add("@CategoryId",CategoryId);
            param.Add("@Flag", 3);
            _categoryId = await con.QuerySingleAsync<int>(query, param, commandType: CommandType.StoredProcedure);
        }
        return _categoryId;
    }
}