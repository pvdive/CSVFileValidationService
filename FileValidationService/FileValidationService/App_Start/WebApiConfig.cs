using FileValidationService.APIFilters;
using System.Web.Http;

namespace FileValidationService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
           
            config.Filters.Add(new ValidateModelAttribute());
            config.Filters.Add(new ValidateFilePathAttribute());
            config.Filters.Add(new ValidateFileExtensionAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
