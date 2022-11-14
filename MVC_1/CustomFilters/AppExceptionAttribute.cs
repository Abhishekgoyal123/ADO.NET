using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
namespace MVC_Apps.CustomFilters
{
    public class AppExceptionAttribute : IExceptionFilter
    {
        private IModelMetadataProvider modelMetadataProvider;
        public AppExceptionAttribute(IModelMetadataProvider modelMetadataProvider)
        {
            this.modelMetadataProvider = modelMetadataProvider;
        }
        void IExceptionFilter.OnException(ExceptionContext context)
        {
            context.ExceptionHandled = false;
            string errorMsg = context.Exception.Message;
            ViewResult result = new ViewResult();
            if (context.Exception.GetType() == typeof(SqlException))
            {
                result.ViewName = "ErrorDB";
            }
            else
            {
                result.ViewName = "Error";
            }
            ViewDataDictionary viewData = new ViewDataDictionary(modelMetadataProvider, context.ModelState);
            viewData["Controller"] = context.RouteData.Values["controller"].ToString();
            viewData["Action"] = context.RouteData.Values["action"].ToString();
            viewData["Error"] = errorMsg;
            result.ViewData = viewData;
            context.Result = result;
        }
    }
}










