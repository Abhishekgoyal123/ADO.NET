using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.AspNetCore.Mvc.Routing;
using System.Diagnostics;

namespace MVC_1.CustomFilters
{
    public class LogRequestAttribute : ActionFilterAttribute
    {
        private void LogRequest(string currentState, RouteData route)
        {
            string controller = route.Values["controller"].ToString();
            string action = route.Values["action"].ToString();
            string logMessage = $"Current State of Execution is {currentState} in {action} action method of {controller} controller";
            Debug.WriteLine(logMessage);

        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
           
            LogRequest("OnActionExecuting", context.RouteData);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
        }

    }
}
