using System.Net;
using ECAdminAPI.Models;
using ECAdminAPI.Repositories;
using ECAdminAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IDocumentRepository _documentRepository;
    public DocumentController(ILoggerManager logger, IDocumentRepository documentRepository)
    {
        _logger = logger;
        _documentRepository = documentRepository;
    }

    [HttpGet("GetDocuments")]
    public async Task<APIResponse<List<Document>>> GetDocuments(string AssociatedId="", string AssociatedType="")
    {
        List<Document> lstDocument = new List<Document>();
        try
        {
            lstDocument = await _documentRepository.GetDocuments(AssociatedId,AssociatedType);
            return new APIResponse<List<Document>>(lstDocument, "Document retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Document => GetDocument =>", ex);
            return new APIResponse<List<Document>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("GetAllDocument")]
    public async Task<APIResponse<PagedResultDto<List<Document>>>> GetAllDocument([FromBody] GridFilter objFilter)
    {
        try
        {
            string DocumentId = string.Empty; string AssociatedId = string.Empty; string AssociatedType = string.Empty;
            if (objFilter == null)
            {
                ModelState.AddModelError("GridFilter", "Grid Filter object are null");
                return new APIResponse<PagedResultDto<List<Document>>>(HttpStatusCode.BadRequest, "Grid filter object is null", ModelState.AllErrors(), true);
            }
            if (objFilter != null && objFilter.Filter != null && objFilter.Filter.Count > 0)
            {
                var _filter = objFilter.Filter.Find(x => x.ColId.ToLower() == "documentid");
                if (_filter != null && !string.IsNullOrEmpty(_filter.Value)) { DocumentId = _filter.Value; }
                _filter = objFilter.Filter.Find(x => x.ColId.ToLower() == "associatedid");
                if (_filter != null && !string.IsNullOrEmpty(_filter.Value)) { AssociatedId = _filter.Value; }
                _filter = objFilter.Filter.Find(x => x.ColId.ToLower() == "associatedtype");
                if (_filter != null && !string.IsNullOrEmpty(_filter.Value)) { AssociatedType = _filter.Value; }
            }
            var lstCustomer = await _documentRepository.GetAllGetDocuments(DocumentId, AssociatedId, AssociatedType, objFilter.PageNumber, objFilter.PageSize);
            return new APIResponse<PagedResultDto<List<Document>>>(lstCustomer, "Documents retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Document => GetAllDocument =>", ex);
            return new APIResponse<PagedResultDto<List<Document>>>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("GetDocumentById")]
    public async Task<APIResponse<Document>> GetDocumentById(int DocumentId)
    {
        Document objDocument = new Document();
        try
        {
            if (DocumentId == 0)
            {
                ModelState.AddModelError("DocumentId", "Please provide documentId");
                return new APIResponse<Document>(HttpStatusCode.BadRequest, "Validation Error", ModelState.AllErrors(), true);
            }
            objDocument = await _documentRepository.GetDocumentById(DocumentId);
            return new APIResponse<Document>(objDocument, "Document retrived successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Document => GetDocumentById =>", ex);
            return new APIResponse<Document>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpPost("AddUpdateDocument")]
    public async Task<APIResponse<int>> AddUpdateDocument([FromBody] Document objDocument)
    {
        int result = 0;
        try
        {
            if (!ModelState.IsValid) 
            { 
                return new APIResponse<int>(HttpStatusCode.BadRequest,"Validation Error",ModelState.AllErrors(),true);
            }
            if (objDocument.DocumentId <= 0) { objDocument.Flag = 1; }
            else { objDocument.Flag = 2; }
            result = await _documentRepository.AddUpdateDocument(objDocument);
            string successMessage = "Document added successfully";
            if (objDocument.Flag == 2) { successMessage =  "Document updated successfully"; } 
            return new APIResponse<int>(result, successMessage);
        }
        catch (Exception ex)
        {
            _logger.LogLocationWithException("Document => AddUpdateDocument =>", ex);
            return new APIResponse<int>(HttpStatusCode.InternalServerError, "Internal server error: " + ex.Message);
        }
    }

    [HttpGet("DeleteDocumentById")]
    public async Task<APIResponse<int>> DeleteDocumentById(int DocumentId)
    {
        _logger.LogInfo("[CategoryController]|[DeleteDocumentById]|[Start] => DeleteDocumentById => DocumentId: " + DocumentId);
        if (DocumentId <= 0)
        {
            ModelState.AddModelError("DocumentId", "Please enter DocumentId");
            return new APIResponse<int>(HttpStatusCode.BadRequest,"Validation Error",ModelState.AllErrors(),true);
        }
        var result = await _documentRepository.DeleteDocumentById(DocumentId);
         string successMessage = "Document deleted successfully";
        return new APIResponse<int>(result, successMessage);
    }
}