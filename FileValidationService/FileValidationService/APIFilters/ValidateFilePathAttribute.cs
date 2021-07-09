using FileValidationService.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FileValidationService.APIFilters
{
    public class ValidateFilePathAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            
            var configPath = ((RequestModel)actionContext.ActionArguments["requestModel"]).configPath;
            var dataFilePath = ((RequestModel)actionContext.ActionArguments["requestModel"]).filePath;
            if (!File.Exists(configPath))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound,"Configuration file not found");
            }
           else if (!File.Exists(dataFilePath))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.NotFound, "Data file not found");
            }
        }
    }
}