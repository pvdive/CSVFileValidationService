using FileValidationService.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FileValidationService.APIFilters
{
    public class ValidateFileExtensionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            var configPath = ((RequestModel)actionContext.ActionArguments["requestModel"]).configPath;
            var dataFilePath = ((RequestModel)actionContext.ActionArguments["requestModel"]).filePath;
            if (Path.GetExtension(configPath).ToLower() != ".json")
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.ExpectationFailed, "Configuration file should be .json file");
            }
            if (Path.GetExtension(dataFilePath).ToLower() != ".csv")
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                   HttpStatusCode.ExpectationFailed, "Data file should be .csv file");
            }
        }
    }
}