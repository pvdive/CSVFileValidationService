using FileValidationService.APIFilters;
using FileValidationService.Models;
using FormatValidator;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FileValidationService.Controllers
{
    public class ValidationController : ApiController
    {

        [HttpPost]
        [ResponseType(typeof(string))]
        [ValidateModel]
        [ValidateFilePath]
        [ValidateFileExtension]
        public HttpResponseMessage Validate([FromBody] RequestModel requestModel)
        {
            HttpResponseMessage response = null;
            string message = string.Empty;
            try
            {

                List<RowValidationError> errors = new List<RowValidationError>();
                Validator validator = Validator.FromJson(System.IO.File.ReadAllText(requestModel.configPath));
                FileSourceReader source = new FileSourceReader(requestModel.filePath);

                foreach (RowValidationError current in validator.Validate(source))
                {
                    errors.Add(current);
                }
                if (errors.Count > 0)
                {
                    message = JsonConvert.SerializeObject(errors);
                }
                else
                { message = "File Validated successfully"; }


            }
            catch (Exception ex)
            {

                message = ex.Message;
            }

            response = Request.CreateResponse<string>(HttpStatusCode.OK, message);
            return response;
        }

    }
}