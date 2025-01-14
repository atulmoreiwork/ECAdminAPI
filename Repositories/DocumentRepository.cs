using Dapper;
using System.Data;
using System.Data.SqlClient;
using ECAdminAPI.Models;
namespace ECAdminAPI.Repositories;

public interface IDocumentRepository
{
    Task<List<Document>> GetDocuments(string AssociatedId="", string AssociatedType="");
    Task<PagedResultDto<List<Document>>> GetAllGetDocuments(string DocumentId, string AssociatedId, string AssociatedType, int PageIndex = 0, int PageSize = 0);
    Task<Document> GetDocumentById(int DocumentId);
    Task<int> AddUpdateDocument(Document objModel);
    Task<int> DeleteDocumentById(int DocumentId);
    Task<int> AddProductDocumentWithFile(int ProductId, IFormFile[] ImportFile);
}
public class DocumentRepository : IDocumentRepository
{
    private readonly DapperContext _context;
    private readonly IGridDataHelperRepository _gridDataHelperRepository;
    private readonly IConfiguration _configuration;
    public DocumentRepository(DapperContext context, IGridDataHelperRepository gridDataHelperRepository, IConfiguration configuration)
    {
        _context = context;
        _gridDataHelperRepository = gridDataHelperRepository;
        _configuration = configuration;
    }
    public async Task<List<Document>> GetDocuments(string AssociatedId="", string AssociatedType="")
    {
        var objResp = new List<Document>();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Documents";
            con.Open();
            DynamicParameters param = new DynamicParameters();
            if (!string.IsNullOrEmpty(AssociatedId)) param.Add("@AssociatedId", AssociatedId);
            if (!string.IsNullOrEmpty(AssociatedType)) param.Add("@AssociatedType", AssociatedType);
            var result = await con.QueryAsync<Document>(query, param, commandType: CommandType.StoredProcedure);
            objResp = result.ToList(); ;
        }
        return objResp;
    }
    public async Task<PagedResultDto<List<Document>>> GetAllGetDocuments(string DocumentId, string AssociatedId, string AssociatedType, int PageIndex = 0, int PageSize = 0)
    {
        var objResp = new PagedResultDto<List<Document>>();
        List<ColumnsDetails> lstColumnDetail = new List<ColumnsDetails>();
        List<FilterDetails> lstFilterDetail = new List<FilterDetails>();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Documents";
            DynamicParameters param = new DynamicParameters();
            if (!string.IsNullOrEmpty(DocumentId)) param.Add("@DocumentId", DocumentId);
            if (!string.IsNullOrEmpty(AssociatedId)) param.Add("@AssociatedId", AssociatedId);
            if (!string.IsNullOrEmpty(AssociatedType)) param.Add("@AssociatedType", AssociatedType);
            if (PageSize > 0) { param.Add("@PageSize", PageSize); } else { param.Add("@PageSize", null); }
            if (PageIndex > 0) { param.Add("@PageIndex", PageIndex); } else { param.Add("@PageIndex", null); }
            var result = await con.QueryAsync<Document>(query, param, commandType: CommandType.StoredProcedure);
            if (result == null) return null;
            int count = 0;
            if (result.Count() > 0)
            {
                var elm = result.First();
                count = Convert.ToInt32(elm.TotalRowCount);
                lstColumnDetail = _gridDataHelperRepository.GetDocumentsColumnDetails();
                lstFilterDetail = _gridDataHelperRepository.GetDocumentsFilterDetails();
            }
            objResp = new PagedResultDto<List<Document>>(PageIndex, PageSize, count, result.ToList(), lstColumnDetail, lstFilterDetail);
        }
        return objResp;
    }
    public async Task<Document> GetDocumentById(int DocumentId)
    {
        var objResp = new Document();
        using (var con = _context.CreateConnection)
        {
            string query = "p_GET_Documents";
            con.Open();
            DynamicParameters param = new DynamicParameters();
            param.Add("@DocumentId", DocumentId);
            var _result = await con.QueryAsync<Document>(query, param, commandType: CommandType.StoredProcedure);
            objResp = _result.FirstOrDefault();
        }
        return objResp;
    }
    public async Task<int> AddUpdateDocument(Document objModel)
    {
        int DocumentId = 0;
        using (var con = _context.CreateConnection)
        {

            string query = "p_AUD_Documents";
            con.Open();
            var param = new DynamicParameters();
            if (objModel.DocumentId > 0) param.Add("@DocumentId", objModel.DocumentId);
            if (objModel.AssociatedId > 0) param.Add("@AssociatedId", objModel.AssociatedId);
            if (!string.IsNullOrEmpty(objModel.DocumentType)) param.Add("@DocumentType", objModel.DocumentType);
            if (!string.IsNullOrEmpty(objModel.FileName)) param.Add("@FileName", objModel.FileName);
            if (!string.IsNullOrEmpty(objModel.FileUrl)) param.Add("@FileUrl", objModel.FileUrl);
            if (!string.IsNullOrEmpty(objModel.PhysicalFileUrl)) param.Add("@PhysicalFileUrl", objModel.PhysicalFileUrl);
            if (!string.IsNullOrEmpty(objModel.AssociatedType)) param.Add("@AssociatedType", objModel.AssociatedType);
            param.Add("@Flag", objModel.Flag);
            DocumentId = await con.QuerySingleAsync<int>(query, param, commandType: CommandType.StoredProcedure);
        }
        return DocumentId;
    }
    public async Task<int> DeleteDocumentById(int DocumentId)
    {
        int _documentId = 0;
        using (var con = _context.CreateConnection)
        {

            string query = "p_AUD_Documents";
            con.Open();
            var param = new DynamicParameters();
            param.Add("@DocumentId",DocumentId);
            param.Add("@Flag", 3);
            _documentId = await con.QuerySingleAsync<int>(query, param, commandType: CommandType.StoredProcedure);
        }
        return _documentId;
    }

    public async Task<int> AddProductDocumentWithFile(int ProductId, IFormFile[] ImportFile)
    {
        int DocumentId = 0;
        try
        {
            var contentFolderPath = _configuration["AppSettings:ContentFolderPath"];
            var baseUrl = _configuration["AppSettings:ContentURL"];
            string directoryPath = contentFolderPath + @"\Products\"+ ProductId;
            string baseFileUrl = baseUrl + @"/Products/"+ ProductId;
            if(!Directory.Exists(directoryPath)){ Directory.CreateDirectory(directoryPath);}
            string _guid = Convert.ToString(Guid.NewGuid()).Replace("-", string.Empty);
            foreach (var file in ImportFile)
            {
                var FileName =  _guid + "_" + file.FileName;
                var PhysicalFileUrl = directoryPath + @"\" + _guid + "_" + file.FileName;
                var FileUrl = baseFileUrl + "/" + _guid + "_" + file.FileName;
                await using (var stream = new FileStream(PhysicalFileUrl, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var DocumentType = FileTypeHelper.GetFileType(file.FileName);
                using (var con = _context.CreateConnection)
                {
                    string query = "p_AUD_Documents";
                    con.Open();
                    var param = new DynamicParameters();
                    if (ProductId > 0) param.Add("@AssociatedId", ProductId);
                    if (!string.IsNullOrEmpty(DocumentType)) param.Add("@DocumentType", DocumentType);
                    if (!string.IsNullOrEmpty(FileName)) param.Add("@FileName", FileName);
                    if (!string.IsNullOrEmpty(FileUrl)) param.Add("@FileUrl", FileUrl);
                    if (!string.IsNullOrEmpty(PhysicalFileUrl)) param.Add("@PhysicalFileUrl", PhysicalFileUrl);
                    param.Add("@AssociatedType", "Product");
                    param.Add("@Flag", 1);
                    DocumentId = await con.QuerySingleAsync<int>(query, param, commandType: CommandType.StoredProcedure);
                }
            }
        }
        catch(Exception ex)
        {
            DocumentId = 0;
            LoggerHelper.LogLocationWithException("DocumentRepository()->AddProductDocumentWithFile()->Error", ex);
        }      
        return DocumentId;
    }
}

