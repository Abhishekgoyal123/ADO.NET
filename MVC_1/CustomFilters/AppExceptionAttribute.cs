using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MVC_1.CustomFilters
{
    public class AppExceptionAttribute : IExceptionFilter
    {
        private IModelMetadataProvider modelMetadataProvider;

        public AppExceptionAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            this.modelMetadataProvider = modelMetadataProvider;
        }
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;

            string errorMessage = context.Exception.Message;

            ViewResult viewResult = new ViewResult();
            viewResult.ViewName = "Error";

            ViewDataDictionary viewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState);

            viewData["Controller"] = context.RouteData.Values["controller"].ToString();
            viewData["Action"] = context.RouteData.Values["action"].ToString();
            viewData["ErrorMessage"] = errorMessage;

            viewResult.ViewData = viewData;

            context.Result = viewResult;


        }
    }
}
