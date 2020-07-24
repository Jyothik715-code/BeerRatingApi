using Jyothi.UserRatings.Api.Models;
using Jyothi.UserRatings.Api.Utilities;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Jyothi.UserRatings.Api.Filters
{
    /// <summary>
    /// Task # 3 - Custom filter to validate Task # 1 has valid email in username parameter
    /// </summary>
    public class CustomActionFilter : ActionFilterAttribute
    {
        /// <summary>
        /// This method will be executed before action is executed
        /// Validates username parameter and adds error message to Model State if invalid
        /// </summary>
        /// <param name="actionContext">Action Method Context</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var validateParameter = "userRatings";

            if (actionContext.ActionArguments == null
                || !actionContext.ActionArguments.ContainsKey(validateParameter))
                actionContext.ModelState.AddModelError(validateParameter, "userRatings is null or empty");

            if (actionContext.ActionArguments.ContainsKey(validateParameter))
            {
                //Cast input to model type to validate username property
                UserRatingsModel model = actionContext.ActionArguments[validateParameter] as UserRatingsModel;

                if (!RegexUtilities.IsValidEmail(model.Username))
                    actionContext.ModelState.AddModelError("userRatings.Username",
                        string.Format("Username must be a valid email. {0} is not a valid email.",
                        model.Username));
            }
        }
    }
}